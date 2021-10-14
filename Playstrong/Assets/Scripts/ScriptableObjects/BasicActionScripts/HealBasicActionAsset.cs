using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "HealBasicAction", menuName = "SO's/BasicActions/HealBasicAction")]
    
    public class HealBasicActionAsset : BasicActionAsset
    {
        /// <summary>
        /// Heal Amount can be a Fixed Value set in the Modifier SO
        /// or, it can be set in script
        /// </summary>
        /*[SerializeField] [RequireInterface(typeof(IModifier))]
        private ScriptableObject _healAmount;

        public IModifier HealAmount => _healAmount as IModifier;*/

        [SerializeField] private float healMultiplier;

        public override IEnumerator TargetAction(IHero targetHero)
        {
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
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var visualTree = targetHero.CoroutineTreesAsset.MainVisualTree;
            
            
            visualTree.AddCurrent(HealVisual(targetHero));

            var newHealth = targetHero.HeroLogic.HeroAttributes.Health + Mathf.FloorToInt(healMultiplier* targetHero.HeroLogic.HeroAttributes.BaseHealth);
            targetHero.HeroLogic.SetHeroHealth.SetHealth(newHealth);

            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator HealVisual(IHero targetHero)
        {
            var visualTre = targetHero.CoroutineTreesAsset.MainVisualTree;
            targetHero.DamageEffect.ShowDamage(Mathf.FloorToInt(healMultiplier* targetHero.HeroLogic.HeroAttributes.BaseHealth));

            visualTre.EndSequence();
            yield return null;
        }



      


    }
}
