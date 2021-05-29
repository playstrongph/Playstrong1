using System.Collections;
using GameSettings;
using Interfaces;
using References;
using UnityEngine;
using Visual;

namespace Logic
{
    public class InitializeHeroSkills : MonoBehaviour, IInitializeHeroSkills
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
            foreach (var heroAssetSO in teamHeroesAsset.TeamHeroes())
            {
                var heroAsset = heroAssetSO as IHeroAsset;
                var skillPanelObject = Instantiate(skillPanelPrefab, boardLocation);

                CreateSkillPanel(skillPanelObject, boardLocation, heroAssetSO);
                CreateHeroSkills(heroAsset, skillObjectPrefab, skillPanelObject, skillPreviewLocation);

                //Hide SkillPanel after Initializing
                skillPanelObject.SetActive(false);


            }

            yield return null;
            _logicTree.EndSequence();
        }


        private void CreateSkillPanel(GameObject skillPanelObject, Transform boardLocation, ScriptableObject heroAssetSO)
        {
            skillPanelObject.transform.SetParent(boardLocation);
            skillPanelObject.transform.SetAsLastSibling();
            skillPanelObject.name = heroAssetSO.name + "Skills";
            _player.HeroesSkills.List.Add(skillPanelObject);
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

                var heroSkillComponent = skillObject.GetComponent<ISkill>();
                heroSkillComponent.SkillName = heroSkill.name;

                var skillVisualReferences = heroSkillComponent.SkillVisual;
                var skillLogicReferences = heroSkillComponent.SkillLogic;
                    
                var skillPreviewVisual = heroSkillComponent.SkillPreviewVisual;
                skillPreviewVisual.PreviewTransform.position = skillPreviewLocation.localPosition;

                var skillAsset = heroSkill as IHeroSkillAsset;
                    
                skillLogicReferences.LoadSkillAttributes.LoadSkillAttributesFromAsset(skillAsset);
                
                skillLogicReferences.SkillAttributes.SkillType.SkillCooldownDisplay(skillVisualReferences.CooldownText);
                skillLogicReferences.SkillAttributes.SkillType.SkillCooldownDisplay(skillPreviewVisual.Cooldown);

                skillVisualReferences.LoadSkillVisuals.LoadSkillVisualsFromSkillAsset(skillAsset);
                skillPreviewVisual.LoadSkillPreviewVisuals.LoadSkillPreviewVisualsFromAsset(skillAsset);

            }
        }




    }
}
