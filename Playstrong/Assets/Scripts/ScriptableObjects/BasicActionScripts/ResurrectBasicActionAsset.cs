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
    [CreateAssetMenu(fileName = "ResurrectHeroBasicAction", menuName = "SO's/BasicActions/R/ResurrectHeroBasicAction")]
    
    public class ResurrectBasicActionAsset : BasicActionAsset
    {
        
        [SerializeField]
        [RequireInterface(typeof(IHeroLivingStatusAsset))]
        private ScriptableObject _heroAliveStatus;
        
        [SerializeField]
        [RequireInterface(typeof(IGameAnimations))]
        private Object _resurrectAnimation;
        private IGameAnimations ResurrectAnimation => _resurrectAnimation as IGameAnimations;
        private IHeroLivingStatusAsset HeroAliveStatus => _heroAliveStatus as IHeroLivingStatusAsset;

        public override IEnumerator StartAction(IHero hero)
        {
            Debug.Log("1 Resurrect Start Action " + hero.HeroName);
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;

            //Bypass Hero Alive Checking
            logicTree.AddCurrent(TargetAction(hero));

            logicTree.EndSequence();
            yield return null;

        }

        public override IEnumerator StartAction(IHero thisHero, IHero targetHero)
        {
            Debug.Log("2 Resurrect Start Action " +targetHero.HeroName);
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //Bypass Hero Alive Checking
            logicTree.AddCurrent(TargetAction(targetHero));
            
            logicTree.EndSequence();
            yield return null;

        }
        
        

        public override IEnumerator TargetAction(IHero hero)
        {
            Debug.Log("1 Resurrect Target Action " +hero.HeroName);
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;

            ResurrectHero(hero);
            
            logicTree.EndSequence();
            yield return null;

        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {
            Debug.Log("2 Resurrect Target Action " +targetHero.HeroName);
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            ResurrectHero(targetHero);
            
            logicTree.EndSequence();
            yield return null;

        }

        private void ResurrectHero(IHero thisHero)
        {
            Debug.Log("Resurrect Hero " +thisHero.HeroName);
            
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var resurrectChance = thisHero.HeroLogic.OtherAttributes.ResurrectChance;
            var resurrectResistance = thisHero.HeroLogic.OtherAttributes.ResurrectResistance;
            var netChance = resurrectChance - resurrectResistance;
            
            //var randomChance = Random.Range(1, 101);
            
            //TODO: This is what's causing the problem for skill Resurrect!
            if (netChance>=0)
            {
                //TEST
                logicTree.AddCurrent(ResurrectActions(thisHero));    
            }
        }

        private IEnumerator ResurrectActions(IHero hero)
        {
            Debug.Log("Resurrect HeroActions " +hero.HeroName);
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(SetHeroAliveStatus(hero));
            
            logicTree.AddCurrent(RegisterSkills(hero));

            logicTree.AddCurrent(EnableHeroTurns(hero));

            logicTree.AddCurrent(ResetHealthAndEnergy(hero));
         

            logicTree.AddCurrent(DestroyAllStatusEffects(hero));
            
            logicTree.AddCurrent(ResurrectHeroAnimation(hero));
            
            logicTree.AddCurrent(ShowHeroVisuals(hero));

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
        private IEnumerator RegisterSkills(IHero hero)
        {
            var heroSkillsReference = hero.HeroSkills.Skills;
            var heroSkillsObjects = heroSkillsReference.GetComponent<ISkillsPanel>().SkillList;

            foreach (var skillObject in heroSkillsObjects)
            {
                var skill = skillObject.GetComponent<ISkill>();
                skill.SkillLogic.SkillAttributes.SkillEffectAsset.RegisterSkillEffect(skill);
                //TEST
                skill.SkillLogic.SkillAttributes.SkillEffectAsset.RegisterSkillEffect(skill.Hero);
            }
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;

        }
        private IEnumerator EnableHeroTurns(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
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

            logicTree.EndSequence();
            yield return null;

        }
        private IEnumerator ResetHealthAndEnergy(IHero hero)
        {
            var heroAttributes = hero.HeroLogic.HeroAttributes;
            var heroLogic = hero.HeroLogic;

            //Only displayed in Hero Preview
            /*heroAttributes.Chance = heroAttributes.BaseChance;
            heroLogic.SetHeroAttack.SetAttack(heroAttributes.BaseAttack);
            heroLogic.SetHeroHealth.SetHealth(heroAttributes.BaseHealth);
            heroLogic.SetHeroArmor.SetArmor(heroAttributes.BaseArmor);
            heroLogic.SetHeroSpeed.SetSpeed(heroAttributes.BaseSpeed);
            heroLogic.HeroTimer.ResetHeroTimer();*/

            heroLogic.SetHeroHealth.SetHealth(heroAttributes.BaseHealth);
            heroLogic.HeroTimer.ResetHeroTimer();
            
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
        private IEnumerator ResurrectHeroAnimation(IHero hero)
        {
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;

            //Delay for hero dies animation to resolve
            visualTree.AddCurrentWait(0.5f,visualTree);
            
            visualTree.AddCurrent(ResurrectAnimation.StartAnimation(hero));

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
        
       

        //AUXILIARY METHODS
        private IEnumerator ShowVisuals(IHero hero)
        {
            Debug.Log("Resurrect ShowVisuals: " +hero.HeroName);
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;
            
            hero.TargetHero.TargetVisual.TargetCanvas.enabled = true;
            hero.TargetHero.HeroBoxCollider.enabled = true;
            hero.HeroVisual.HeroCanvas.enabled = true;
            
            
            visualTree.EndSequence();
            yield return null;
        }
        
       
        
       
        
      
        
        
        
        
        
      
        
        
       
       
        
        
        
        








    }
}
