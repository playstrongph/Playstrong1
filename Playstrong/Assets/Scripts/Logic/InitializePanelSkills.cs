using System.Collections;
using Interfaces;
using References;
using UnityEngine;
using Visual;

namespace Logic
{
    public class InitializePanelSkills : MonoBehaviour, IInitializePanelSkills
    {
        
        private IHeroesListReference _heroesList;
        private int _index;

        private void Awake()
        {
            _heroesList = GetComponent<IHeroesListReference>();
            _index = 0;
        }

        public IEnumerator InitializeSkills(ITeamHeroesAsset teamHeroesAsset, GameObject skillPanelPrefab, 
            GameObject skillObjectPrefab, Transform boardLocation, Transform skillPreviewLocation, ICoroutineTree tree)
        {
            foreach (var heroAssetSO in teamHeroesAsset.TeamHeroes())
            {
                var skillPanelObject = Instantiate(skillPanelPrefab, boardLocation);
                skillPanelObject.transform.SetParent(boardLocation);
                skillPanelObject.transform.SetAsLastSibling();
                skillPanelObject.name = heroAssetSO.name + "Skills";
                _heroesList.PanelSkillsList.HeroList.Add(skillPanelObject);
                
                
                var heroAsset = heroAssetSO as IHeroAsset;
                
                foreach (var heroSkill in heroAsset.GetHeroSkills())
                {
                    var skillObject = Instantiate(skillObjectPrefab, skillPanelObject.transform);
                    skillObject.transform.SetParent(skillPanelObject.transform);
                    skillObject.transform.SetAsLastSibling();
                    skillObject.name = heroSkill.name;
                    skillPanelObject.GetComponent<ISkillsList>().SkillList.Add(skillObject);

                    var skillVisualReferences = 
                        skillObject.GetComponent<ISkillPrefab>().SkillVisualReferences;
                    var skillLogicReferences = skillObject.GetComponent<ISkillPrefab>().SkillLogic;
                    var skillPreviewVisual = skillObject.GetComponent<ISkillPrefab>().SkillPreviewVisual;
                    skillPreviewVisual.PreviewTransform.position = skillPreviewLocation.localPosition;

                    var skill = heroSkill as IHeroSkillAsset;
                    
                    skillLogicReferences.LoadSkillAttributes.LoadSkillAttributesFromAsset(skill);
                    skillVisualReferences.LoadSkillVisuals.LoadSkillVisualsFromSkillAsset(skill);
                    skillPreviewVisual.LoadSkillPreviewVisuals.LoadSkillPreviewVisualsFromAsset(skill);
                    
                }


            }

            yield return null;
            tree.EndSequence();
        }




    }
}
