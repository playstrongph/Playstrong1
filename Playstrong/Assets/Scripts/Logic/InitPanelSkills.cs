using System.Collections;
using UnityEngine;

namespace Logic
{
    public class InitPanelSkills: MonoBehaviour, IInitPanelSkills
    {

        private IBattleSceneManager _battleSceneManager;
        private void Awake()
        {
            _battleSceneManager = GetComponent<IBattleSceneManager>();
            
        }
        
        public IEnumerator InitializePanelSkills()
        {
            var mainTeamHeroAsset = _battleSceneManager.BattleSceneSettings.PlayerTeamHeroesAsset;
            var enemyTeamHeroAsset = _battleSceneManager.BattleSceneSettings.EnemyTeamHeroesAsset;

            var mainBoardLocation = _battleSceneManager.MainPlayer.PanelSkills.Transform;
            var enemyBoardLocation = _battleSceneManager.EnemyPlayer.PanelSkills.Transform;
            
            
            var skillPanelPrefab = _battleSceneManager.BattleSceneSettings.SkillPanelPrefab;
            var skillObjectPrefab = _battleSceneManager.BattleSceneSettings.SkillObjectPrefab;
            var skillPreviewLocation = _battleSceneManager.BattleSceneSettings.PanelSkillPreviewLocation;
            var logicTree = _battleSceneManager.GlobalTrees.MainLogicTree;

            logicTree.AddCurrent(_battleSceneManager.MainPlayer.InitializePanelSkills.InitializeSkills(mainTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, mainBoardLocation, skillPreviewLocation));
            logicTree.AddCurrent(_battleSceneManager.MainPlayer.CreatePanelSkillReferences.CreateReferences());

            logicTree.AddCurrent(_battleSceneManager.EnemyPlayer.InitializePanelSkills.InitializeSkills(enemyTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, enemyBoardLocation, skillPreviewLocation));
            logicTree.AddCurrent(_battleSceneManager.EnemyPlayer.CreatePanelSkillReferences.CreateReferences());
            
            logicTree.AddCurrent(_battleSceneManager.MainPlayer.PanelSkills.ReferenceHeroesSkills());
            logicTree.AddCurrent(_battleSceneManager.EnemyPlayer.PanelSkills.ReferenceHeroesSkills());

            logicTree.AddCurrent(_battleSceneManager.MainPlayer.PanelSkills.DisablePanelSkillTargetVisual());
            logicTree.AddCurrent(_battleSceneManager.EnemyPlayer.PanelSkills.DisablePanelSkillTargetVisual());
            
            

            yield return null;
            logicTree.EndSequence();
            
        }
    }
}