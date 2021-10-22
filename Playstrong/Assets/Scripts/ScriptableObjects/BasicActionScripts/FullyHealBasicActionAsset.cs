using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "FullyHealBasicAction", menuName = "SO's/BasicActions/FullyHealBasicAction")]
    
    public class FullyHealBasicActionAsset : BasicActionAsset
    {
       

        public override IEnumerator TargetAction(IHero targetHero)
        {
            Debug.Log("Fully Heal Basic Action 1arg");
            
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
           var targetHealChance = targetHero.HeroLogic.OtherAttributes.HealChance;
           var targetHealResistance = targetHero.HeroLogic.OtherAttributes.HealResistance;
           var randomValue = Random.Range(1f, 100f);
           var netHealChance = targetHealChance - targetHealResistance;
           
           netHealChance = Mathf.Clamp(netHealChance,0, 100);

           if(randomValue <= netHealChance)
               logicTree.AddCurrent(HealCoroutine(targetHero));
           
           logicTree.EndSequence();
           yield return null;

        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {
            Debug.Log("Fully Heal Basic Action 2args");
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var targetHealChance = targetHero.HeroLogic.OtherAttributes.HealChance;
            var targetHealResistance = targetHero.HeroLogic.OtherAttributes.HealResistance;
            var randomValue = Random.Range(1f, 100f);
            var netHealChance = targetHealChance - targetHealResistance;
           
            netHealChance = Mathf.Clamp(netHealChance,0, 100);

            if(randomValue <= netHealChance)
                logicTree.AddCurrent(HealCoroutine(targetHero));
           
            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator HealCoroutine(IHero targetHero)
        {
            Debug.Log("Fully Heal Coroutine");
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var visualTree = targetHero.CoroutineTreesAsset.MainVisualTree;
            var currentHealth = targetHero.HeroLogic.HeroAttributes.Health;
            var baseHealth = targetHero.HeroLogic.HeroAttributes.BaseHealth;
            var healAMount = Mathf.Max(0, baseHealth - currentHealth);
            
            visualTree.AddCurrent(HealVisual(targetHero));

            var newHealth = targetHero.HeroLogic.HeroAttributes.Health + Mathf.FloorToInt(healAMount);
            
            targetHero.HeroLogic.SetHeroHealth.SetHealth(newHealth);

            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator HealVisual(IHero targetHero)
        {
            var visualTre = targetHero.CoroutineTreesAsset.MainVisualTree;
            var currentHealth = targetHero.HeroLogic.HeroAttributes.Health;
            var baseHealth = targetHero.HeroLogic.HeroAttributes.BaseHealth;
            var healAMount = Mathf.Max(0, baseHealth - currentHealth);
            
            targetHero.DamageEffect.ShowDamage(healAMount);

            visualTre.EndSequence();
            yield return null;
        }



      


    }
}
