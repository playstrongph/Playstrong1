using System.Collections;
using UnityEngine;

namespace Logic
{
    public class InitSkills : MonoBehaviour, IInitSkills
    {
        private IBattleSceneManager _battleSceneManager;

        private void Awake()
        {
            _battleSceneManager = GetComponent<IBattleSceneManager>();
        }
        
        public IEnumerator InitializeSkills()
        {
            var mainTeamHeroAsset = _battleSceneManager.BattleSceneSettings.PlayerTeamHeroesAsset;
            var enemyTeamHeroAsset = _battleSceneManager.BattleSceneSettings.EnemyTeamHeroesAsset;

            var mainBoardLocation = _battleSceneManager.MainPlayer.HeroesSkills.Transform;
            var enemyBoardLocation = _battleSceneManager.EnemyPlayer.HeroesSkills.Transform;

            var skillPanelPrefab = _battleSceneManager.BattleSceneSettings.SkillPanelPrefab;
            var skillObjectPrefab = _battleSceneManager.BattleSceneSettings.SkillObjectPrefab;
            var skillPreviewLocation = _battleSceneManager.BattleSceneSettings.SkillPreviewLocation;

            var logicTree = _battleSceneManager.GlobalTrees.MainLogicTree;

            logicTree.AddCurrent(_battleSceneManager.MainPlayer.InitializeHeroSkills.InitializeSkills(mainTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, mainBoardLocation,  skillPreviewLocation));
            logicTree.AddCurrent(_battleSceneManager.MainPlayer.CreateHeroSkillReferences.CreateReferences());
            
            logicTree.AddCurrent(_battleSceneManager.EnemyPlayer.InitializeHeroSkills.InitializeSkills(enemyTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, enemyBoardLocation, skillPreviewLocation));
            logicTree.AddCurrent(_battleSceneManager.EnemyPlayer.CreateHeroSkillReferences.CreateReferences());

            yield return null;
            logicTree.EndSequence();
            
        }
    
   
    }
}
