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

        public override void StartTurnStatusEffect(IHero hero)
        {
            InitializeValues(hero);

            LogicTree.AddCurrent(StartSkillAction());
        }

        public override IEnumerator StartSkillAction()
        {
           var skillAction = SkillAction;
           LogicTree.AddCurrent(skillAction.StartAction(Hero, Hero));

           LogicTree.EndSequence();
           yield return null;
        }
        
        



        












    }
}
