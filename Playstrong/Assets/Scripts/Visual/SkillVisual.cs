using System;
using Interfaces;
using Logic;
using References;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
    public class SkillVisual : MonoBehaviour, ISkillVisual
    {
        [SerializeField] [RequireInterface(typeof(ISkill))]
        private Object _skill;

        public ISkill Skill => _skill as ISkill;

        [SerializeField] private Canvas _skillCanvas;
        public Canvas SkillCanvas => _skillCanvas;

        [SerializeField] private GameObject _skillGlow;
        public GameObject SkillGlow => _skillGlow;

        [SerializeField] private Image _skillGraphic;
        public Image SkillGraphic => _skillGraphic;

        [SerializeField] private TextMeshProUGUI _cooldownText;
        public TextMeshProUGUI CooldownText => _cooldownText;

        private ILoadSkillVisuals _loadSkillVisuals;
        public ILoadSkillVisuals LoadSkillVisuals => _loadSkillVisuals;

        private ISkillCooldownVisual _skillCooldownVisual;
        public ISkillCooldownVisual SkillCooldownVisual => _skillCooldownVisual;

        [SerializeField] private GameObject _fightingSpirit;
        public GameObject FightingSpirit => _fightingSpirit;
        
        [SerializeField] private TextMeshProUGUI _fightingSpiritText;
        public TextMeshProUGUI FightingSpiritText => _fightingSpiritText;

        private void Awake()
        {
            _loadSkillVisuals = GetComponent<ILoadSkillVisuals>();
            _skillCooldownVisual = GetComponent<ISkillCooldownVisual>();
        }
    }
}
