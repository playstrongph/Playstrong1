using System.Collections;
using System.Runtime.CompilerServices;
using Interfaces;
using Logic;
using ScriptableObjects.Actions;
using ScriptableObjects.Actions.BaseClassScripts;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Recovery", menuName = "SO's/Status Effects/Buffs/Recovery")]
    public class RecoveryAsset : StatusEffectAsset
    {
        [SerializeField] private float healthMultiplier;
        
        
        public override void StartTurnStatusEffect(IHero hero)
        {
            InitializeValues(hero);

            LogicTree.AddCurrent(RecoveryEffect());
        }

        private IEnumerator RecoveryEffect()
        {
            VisualTree.AddCurrent(HealVisual());

            var newHealth = Hero.HeroLogic.HeroAttributes.Health + Mathf.FloorToInt(healthMultiplier* Hero.HeroLogic.HeroAttributes.BaseHealth);
            
            Hero.HeroLogic.SetHeroHealth.SetHealth(newHealth);
            
            LogicTree.EndSequence();
            yield return null;
        }

        
            
        //TEMP - need to change animation to heal animation
        private IEnumerator HealVisual()
        {
            Hero.DamageEffect.ShowDamage(Mathf.FloorToInt(healthMultiplier* Hero.HeroLogic.HeroAttributes.BaseHealth));

            VisualTree.EndSequence();
            yield return null;
        }
















    }
}
