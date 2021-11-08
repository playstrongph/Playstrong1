using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseSpeedBasicAction", menuName = "SO's/BasicActions/I/IncreaseSpeedBasicAction")]
    
    public class IncreaseSpeedBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int flatSpeed;
        [SerializeField] private int percentSpeed;

        private int _speedChange;
        
       
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            SetChangeSpeedValue(targetHero);
            
            var newSpeedValue = targetHero.HeroLogic.HeroAttributes.Speed + _speedChange;
            
            targetHero.HeroLogic.SetHeroSpeed.SetSpeed(newSpeedValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var newSpeedValue = targetHero.HeroLogic.HeroAttributes.Speed - _speedChange;
            
            targetHero.HeroLogic.SetHeroSpeed.SetSpeed(newSpeedValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        
        

        private void SetChangeSpeedValue(IHero hero)
        {
            var baseSpeed = hero.HeroLogic.HeroAttributes.BaseSpeed;
            var percentChange = Mathf.FloorToInt(percentSpeed * baseSpeed/100);
            _speedChange = flatSpeed + percentChange;
        }











    }
}
