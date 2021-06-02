using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
{
    [CreateAssetMenu(fileName = "SkillStatusReady", menuName = "SO's/Scriptable Enums/Skill Status/Skill Status Ready")]
    public class SkillStatusReadyAsset : ScriptableObject, ISkillStatus
    {

        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        private ITurnController _turnController;

        public void StatusAction(ISkillLogic skillLogic)
        {
            _logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            _visualTree = skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            _turnController = skillLogic.Skill.Hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            
            //SetReady
        }
        
        
        
        



    }
}
