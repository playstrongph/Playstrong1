using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "HealActionAsset", menuName = "SO's/SkillActions/HealActionAsset")]
    
    public class HealActionAsset : SkillActionAsset
    {
        /// <summary>
        /// Heal Amount can be a Fixed Value set in the Modifier SO
        /// or, it can be set in script
        /// </summary>
        /*[SerializeField] [RequireInterface(typeof(IModifier))]
        private ScriptableObject _healAmount;

        public IModifier HealAmount => _healAmount as IModifier;*/

        [SerializeField] private float healMultiplier;

        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
           InitializeValues(thisHero, targetHero);
           var targetHealChance = targetHero.HeroLogic.OtherAttributes.HealChance;
           var targetHealResistance = targetHero.HeroLogic.OtherAttributes.HealResistance;
           var randomValue = Random.Range(1f, 100f);
           var netHealChance = targetHealChance - targetHealResistance;
           
           netHealChance = Mathf.Clamp(netHealChance,0, 100);

           if(randomValue <= netHealChance)
              LogicTree.AddCurrent(HealCoroutine());
           
           LogicTree.EndSequence();
           yield return null;

        }

        private IEnumerator HealCoroutine()
        {
            VisualTree.AddCurrent(HealVisual());

            var newHealth = TargetHero.HeroLogic.HeroAttributes.Health + Mathf.FloorToInt(healMultiplier* TargetHero.HeroLogic.HeroAttributes.BaseHealth);
            TargetHero.HeroLogic.SetHeroHealth.SetHealth(newHealth);

            LogicTree.EndSequence();
            yield return null;
        }

        private IEnumerator HealVisual()
        {
            TargetHero.DamageEffect.ShowDamage(Mathf.FloorToInt(healMultiplier* TargetHero.HeroLogic.HeroAttributes.BaseHealth));

            VisualTree.EndSequence();
            yield return null;
        }



      


    }
}
