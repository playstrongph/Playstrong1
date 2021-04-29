using System.Collections;
using Interfaces;
using References;
using UnityEngine;
using Visual;

namespace Logic
{
    public class InitializeHeroSkills : MonoBehaviour, IInitializeHeroSkills
    {
        
        private IHeroesListReference _heroesList;
        private int _index;

        private void Awake()
        {
            _heroesList = GetComponent<IHeroesListReference>();
            _index = 0;
        }

        public IEnumerator InitializeSkills(ITeamHeroesAsset teamHeroesAsset, GameObject skillPanelPrefab, 
            GameObject skillObjectPrefab, Transform boardLocation, ICoroutineTree tree)
        {
            foreach (var heroAssetSO in teamHeroesAsset.TeamHeroes())
            {
                var skillPanelObject = Instantiate(skillPanelPrefab, boardLocation);
                skillPanelObject.transform.SetParent(boardLocation);
                skillObjectPrefab.transform.SetAsFirstSibling();
                skillPanelObject.name = heroAssetSO.name + "Skills";
                _heroesList.HeroSkillsList.HeroList.Add(skillPanelObject);
                
                
                var heroAsset = heroAssetSO as IHeroAsset;
                
                foreach (var heroSkill in heroAsset.GetHeroSkills())
                {
                    var skillObject = Instantiate(skillObjectPrefab, skillPanelObject.transform);
                    skillObject.transform.SetParent(skillObjectPrefab.transform);
                    skillObject.transform.SetAsFirstSibling();
                    skillObject.name = heroSkill.name;
                    skillPanelObject.GetComponent<ISkillsList>().SkillList.Add(skillObject);

                    var skillVisualReferences = 
                        skillObject.GetComponent<ISkillObjectReferences>().SkillVisualReferences;
                    var skillLogicReferences = skillObject.GetComponent<ISkillObjectReferences>().SkillLogicReferences;
                    var skillPreviewVisual = skillObject.GetComponent<ISkillObjectReferences>().SkillPreviewVisual;

                    var skill = heroSkill as IHeroSkillAsset;
                    
                    skillVisualReferences.LoadSkillVisuals.LoadSkillVisualsFromSkillAsset(skill);
                    skillPreviewVisual.LoadSkillPreviewVisuals.LoadSkillPreviewVisualsFromAsset(skill);
                    skillLogicReferences.LoadSkillAttributes.LoadSkillAttributesFromAsset(skill);






                }


            }

            yield return null;
            tree.EndSequence();
        }




    }
}
