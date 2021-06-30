using System.Collections;
using System.Runtime.CompilerServices;
using Interfaces;
using ScriptableObjects.Actions;
using ScriptableObjects.SkillActions.BaseClassScripts;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Recovery", menuName = "SO's/Status Effects/Buffs/Recovery")]
    public class RecoveryAsset : StatusEffectAsset
    {
        [SerializeField]
        [RequireInterface(typeof(IHealActionAsset))]
        private ScriptableObject _healAction;

        private IHealActionAsset HealAction => _healAction as IHealActionAsset;
        
        [Header("Health Factor")]
        [SerializeField]
        private float _multiplier;
        
        private int _healAmount;

        public override void StartTurnStatusEffect(IHero hero)
        {
            
            InitializeValues(hero);
            
            _healAmount = Mathf.FloorToInt(hero.HeroLogic.HeroAttributes.BaseHealth * _multiplier);
            
            LogicTree.AddCurrent(SetHealAmount());
            LogicTree.AddCurrent(HealLogic());
         

        }

        private IEnumerator SetHealAmount()
        {
            HealAction.HealAmount.ModValue = _healAmount;
            
            LogicTree.EndSequence();
            yield return null;
        }

        private IEnumerator HealLogic()
        {
           
            var skillAction = HealAction as ISkillActionAsset;
            skillAction.Target(Hero, Hero.CoroutineTreesAsset);

            LogicTree.EndSequence();
            yield return null;
        }
        
        



        












    }
}
