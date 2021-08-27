using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.AnimationSOscripts;
using ScriptableObjects.HeroLivingStatus;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "ResurrectHero", menuName = "SO's/SkillActions/ResurrectHero")]
    
    public class ResurrectActionAsset : SkillActionAsset
    {
        
        [SerializeField]
        [RequireInterface(typeof(IHeroLivingStatusAsset))]
        private ScriptableObject _heroAliveStatus;
        
        [SerializeField]
        [RequireInterface(typeof(IGameAnimations))]
        private Object _resurrectAnimation;
        private IGameAnimations ResurrectAnimation => _resurrectAnimation as IGameAnimations;
        private IHeroLivingStatusAsset HeroAliveStatus => _heroAliveStatus as IHeroLivingStatusAsset;
        
        public override IEnumerator ActionTarget(IHero thisHero, float dummyValue)
        {
            Debug.Log("Resurrect Action Target");
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(ResurrectActions(thisHero));
            
            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator ResurrectActions(IHero hero)
        {
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //SetHeroAliveStatus
            logicTree.AddCurrent(SetHeroAliveStatus(hero));

            //RegisterSkills
            logicTree.AddCurrent(RegisterSkills(hero));
            
            //EnableHeroTurns
            logicTree.AddCurrent(EnableHeroTurns(hero)); 

            //Visual
            //Reset Hero Attributes
            logicTree.AddCurrent(ResetHeroAttributes(hero));

            //Show Hero Visuals
            logicTree.AddCurrent(ShowHeroVisuals(hero));
            
            //Hero Resurrect Animation
            logicTree.AddCurrent(ResurrectHeroAnimation(hero));

            //DestroyAllStatusEffects
            logicTree.AddCurrent(DestroyAllStatusEffects(hero));
            
            Debug.Log("ResurrectAction");

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator SetHeroAliveStatus(IHero hero)
        {
            hero.HeroLogic.HeroLivingStatus = HeroAliveStatus;

            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator DestroyAllStatusEffects(IHero hero)
        {
            var buffs = hero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            var debuffs = hero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;

            foreach (var buff in buffs)
            {
                buff.RemoveStatusEffect.RemoveEffect(hero);
            }
            
            foreach (var debuff in debuffs)
            {
                debuff.RemoveStatusEffect.RemoveEffect(hero);
            }
            
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator RegisterSkills(IHero hero)
        {
            var heroSkillsReference = hero.HeroSkills.Skills;
            var heroSkillsObjects = heroSkillsReference.GetComponent<ISkillsPanel>().SkillList;

            foreach (var skillObject in heroSkillsObjects)
            {
                var skill = skillObject.GetComponent<ISkill>();
                skill.SkillLogic.SkillAttributes.SkillEffect.RegisterSkillEffect(skill);
            }
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;

        }
        
        private IEnumerator EnableHeroTurns(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            UpdateLivingAndDeadHeroLists(hero);
            //UpdateActiveHeroesList(IHero hero);

            logicTree.EndSequence();
            yield return null;

        }
        
        private void UpdateLivingAndDeadHeroLists(IHero hero)
        {
            var deadHeroes = hero.LivingHeroes.Player.DeadHeroes.HeroesList;
            var livingHeroes = hero.LivingHeroes.HeroesList;
            
            GameObject deadHeroGameObject = null;
            foreach (var heroGameObject in deadHeroes)
            {
                if (heroGameObject.GetComponent<IHero>() == hero)
                    deadHeroGameObject = heroGameObject;
            }

            deadHeroes.Remove(deadHeroGameObject);
            livingHeroes.Add(deadHeroGameObject);
        }
        
        private IEnumerator ResetHeroAttributes(IHero hero)
        {
            var heroAttributes = hero.HeroLogic.HeroAttributes;
            var heroLogic = hero.HeroLogic;

            //Only displayed in Hero Preview
            heroAttributes.Chance = heroAttributes.BaseChance;

            heroLogic.SetHeroAttack.SetAttack(heroAttributes.BaseAttack);
            heroLogic.SetHeroHealth.SetHealth(heroAttributes.BaseHealth);
            heroLogic.SetHeroArmor.SetArmor(heroAttributes.BaseArmor);
            heroLogic.SetHeroSpeed.SetSpeed(heroAttributes.BaseSpeed);
            heroLogic.HeroTimer.ResetHeroTimer();
            
            //TODO: Also reset Other Attributes
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;

        }
        
        private IEnumerator ShowHeroVisuals(IHero hero)
        {
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            visualTree.AddCurrent(ShowVisuals(hero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator ShowVisuals(IHero hero)
        {
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;
            
            hero.TargetHero.TargetVisual.TargetCanvas.enabled = true;
            hero.TargetHero.HeroBoxCollider.enabled = true;
            hero.HeroVisual.HeroCanvas.enabled = true;
            
            
            visualTree.EndSequence();
            yield return null;
        }
        
        
        
        private IEnumerator ResurrectHeroAnimation(IHero hero)
        {
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;

            //Delay for hero dies animation to resolve
            //visualTree.AddCurrentWait(2.5f,visualTree);
            
            visualTree.AddCurrent(ResurrectAnimation.StartAnimation(hero));
            
            //TEMP
            //visualTree.AddCurrentWait(2.5f,visualTree);
            //visualTree.AddCurrent(ShowHeroCanvas(hero));

            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }
        
        //TEMP
        private IEnumerator ShowHeroCanvas(IHero hero)
        {
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;
            
            //TODO - fix in ResurrectHeroAnimation
            hero.HeroVisual.HeroCanvas.enabled = true;

            visualTree.EndSequence();
            yield return null;
        }
        
        
        
        








    }
}
