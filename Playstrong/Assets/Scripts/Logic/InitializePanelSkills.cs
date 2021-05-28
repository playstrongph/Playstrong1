using System.Collections;
using Interfaces;
using References;
using UnityEngine;
using Visual;

namespace Logic
{
    public class InitializePanelSkills : MonoBehaviour, IInitializePanelSkills
    {
        
        private IPlayer _player;
        private int _index;
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;


        private void Awake()
        {
            _player = GetComponent<IPlayer>();
            _index = 0;
        }
        private void Start()
        {
            _logicTree = _player.GlobalTrees.MainLogicTree;
            _visualTree = _player.GlobalTrees.MainVisualTree;
        }

        

        public IEnumerator InitializeSkills(ITeamHeroesAsset teamHeroesAsset, GameObject skillPanelPrefab, 
            GameObject skillObjectPrefab, Transform boardLocation, Transform skillPreviewLocation)
        {
            
            //Create Hero SkillPanel for each Hero
            foreach (var heroAssetSO in teamHeroesAsset.TeamHeroes())
            {
                var heroAsset = heroAssetSO as IHeroAsset;
                var skillPanelObject = Instantiate(skillPanelPrefab, boardLocation);
                
                CreateSkillPanel(skillPanelObject, boardLocation, heroAssetSO);
                CreateHeroSkills(heroAsset, skillObjectPrefab, skillPanelObject, skillPreviewLocation);

                //Hide Panel Skills after loading
                skillPanelObject.SetActive(false);
            }

            yield return null;
            _logicTree.EndSequence();
        }


        private void CreateHeroSkills(IHeroAsset heroAsset, GameObject skillObjectPrefab, GameObject skillPanelObject, Transform skillPreviewLocation)
        {
            foreach (var heroSkill in heroAsset.GetHeroSkills())
            {
                var skillObject = Instantiate(skillObjectPrefab, skillPanelObject.transform);
                skillObject.transform.SetParent(skillPanelObject.transform);
                skillObject.transform.SetAsLastSibling();
                skillObject.name = heroSkill.name;
                skillPanelObject.GetComponent<ISkillsPanel>().SkillList.Add(skillObject);

                var skillVisualReferences = 
                    skillObject.GetComponent<ISkill>().SkillVisual;
                var skillLogicReferences = skillObject.GetComponent<ISkill>().SkillLogic;
                var skillPreviewVisual = skillObject.GetComponent<ISkill>().SkillPreviewVisual;
                skillPreviewVisual.PreviewTransform.position = skillPreviewLocation.localPosition;

                var skill = heroSkill as IHeroSkillAsset;
                    
                skillLogicReferences.LoadSkillAttributes.LoadSkillAttributesFromAsset(skill);
                skillVisualReferences.LoadSkillVisuals.LoadSkillVisualsFromSkillAsset(skill);
                skillPreviewVisual.LoadSkillPreviewVisuals.LoadSkillPreviewVisualsFromAsset(skill);
                    
            }
        }

        private void CreateSkillPanel(GameObject skillPanelObject, Transform boardLocation, ScriptableObject heroAssetSO)
        {
            skillPanelObject.transform.SetParent(boardLocation);
            skillPanelObject.transform.SetAsLastSibling();
            skillPanelObject.name = heroAssetSO.name + "Skills";
            _player.PanelSkills.List.Add(skillPanelObject);
        }




    }
}
