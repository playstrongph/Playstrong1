using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "HealBasicAction", menuName = "SO's/BasicActions/H/HealBasicAction")]
    
    public class HealBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int flatHeal;      

        [SerializeField] private ScriptableObject healFactor;
        private ICalculatedFactorValueAsset HealFactor => healFactor as ICalculatedFactorValueAsset;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            Debug.Log("Heal Basic Action 1arg");
            
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
            //Debug.Log("Heal Basic Action 2args");
            
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
            //Debug.Log("Heal Coroutine");
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var visualTree = targetHero.CoroutineTreesAsset.MainVisualTree;
            var healAMount = HealFactor.GetCalculatedValue();
            
            visualTree.AddCurrent(HealVisual(targetHero));

            var newHealth = targetHero.HeroLogic.HeroAttributes.Health + Mathf.FloorToInt(healAMount) + flatHeal;
            targetHero.HeroLogic.SetHeroHealth.SetHealth(newHealth);

            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator HealVisual(IHero targetHero)
        {
            var visualTre = targetHero.CoroutineTreesAsset.MainVisualTree;
            var healAmount = HealFactor.GetCalculatedValue() + flatHeal;
            
            targetHero.DamageEffect.ShowDamage(Mathf.FloorToInt(healAmount));

            visualTre.EndSequence();
            yield return null;
        }



      


    }
}
