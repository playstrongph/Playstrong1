using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    [CreateAssetMenu(fileName = "SetLifeBasicAction", menuName = "SO's/BasicActions/SetLifeBasicAction")]
    
    public class SetLifeBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int setLife = 1;
        public override IEnumerator TargetAction(IHero targetHero)
        {
            Debug.Log("Set Life Basic Action");
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            targetHero.HeroLogic.SetHeroHealth.SetHealth(setLife);
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
