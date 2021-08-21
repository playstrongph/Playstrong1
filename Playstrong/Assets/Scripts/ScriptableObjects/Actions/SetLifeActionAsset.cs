using System.Collections;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.Modifiers;
using ScriptableObjects.Others;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "SetLifeActionAsset", menuName = "SO's/SkillActions/SetLifeActionAsset")]
    
    public class SetLifeActionAsset : SkillActionAsset
    {
        [SerializeField] private int setLife;

       
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            setLife = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
           
            targetHero.HeroLogic.SetHeroHealth.SetHealth(setLife);
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
