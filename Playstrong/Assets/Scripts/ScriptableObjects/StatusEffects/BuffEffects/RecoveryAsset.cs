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
           
            var skillAction = HealAction as IHeroAction;
            
            //Note: Initiator and Target heroes are the same for Recovery
            LogicTree.AddCurrent(skillAction.StartAction(Hero, Hero));

            LogicTree.EndSequence();
            yield return null;
        }
        
        



        












    }
}
