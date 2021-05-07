using System.Collections;
using System.Collections.Generic;
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
        
        private IHeroPrefab _heroParent;

        private void Awake()
        {
            _player = GetComponent<IPlayer>();
            _index = 0;
        }

        public IEnumerator InitializeSkills(ITeamHeroesAsset teamHeroesAsset, GameObject skillPanelPrefab, 
            GameObject skillObjectPrefab, Transform boardLocation, Transform skillPreviewLocation, ICoroutineTree tree, List<GameObject> heroesList)
        {
            foreach (var heroAssetSO in teamHeroesAsset.TeamHeroes())
            {
                var skillPanelObject = Instantiate(skillPanelPrefab, boardLocation);
                //skillPanelObject.transform.SetParent(boardLocation);
                skillPanelObject.transform.SetAsLastSibling();
                skillPanelObject.name = heroAssetSO.name + "PanelSkills";
                //_player.PanelSkillsList.ThisList.Add(skillPanelObject);
                
                
                var heroAsset = heroAssetSO as IHeroAsset;
                
                //Test Start: Parent to Hero after Instantiating at the correct position
                _heroParent = heroesList[_index].GetComponent<IHeroPrefab>();
                skillPanelObject.transform.SetParent(_heroParent.Transform);
                _heroParent.PanelSkills = skillPanelObject.GetComponent<ISkillsList>();
                
                
                _index++;
                //Test End
                
                foreach (var heroSkill in heroAsset.GetHeroSkills())
                {
                    var skillObject = Instantiate(skillObjectPrefab, skillPanelObject.transform);
                    skillObject.transform.SetParent(skillPanelObject.transform);
                    skillObject.transform.SetAsLastSibling();
                    skillObject.name = heroSkill.name;
                    skillPanelObject.GetComponent<ISkillsList>().SkillList.Add(skillObject);

                    var skillVisualReferences = 
                        skillObject.GetComponent<ISkillPrefab>().SkillVisual;
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
