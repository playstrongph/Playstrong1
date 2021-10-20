using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DragAttackAction", menuName = "SO's/SkillActions/DragAttackAction")]
    
    public class DragAttackActionAsset : SkillActionAsset
    {
        
        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
           InitializeValues(thisHero, targetHero);

           //LogicTree.AddCurrent(thisHero.HeroLogic.BasicAttack.StartAttack(thisHero, targetHero));

           LogicTree.EndSequence();
           yield return null;

        }

        



        



      


    }
}
