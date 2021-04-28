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
    public class SkillVisualReferences : MonoBehaviour, ISkillVisualReferences
    {
        [SerializeField] [RequireInterface(typeof(SkillObjectReferences))]
        private Object _skillObjectReferences;

        public ISkillObjectReferences SkillObjectReferences => _skillObjectReferences as ISkillObjectReferences;

        [SerializeField] private Canvas _skillCanvas;
        public Canvas SkillCanvas => _skillCanvas;

        [SerializeField] private GameObject _skillGlow;
        public GameObject SkillGlow => _skillGlow;

        [SerializeField] private Image _skillGraphic;
        public Image SkillGraphic => _skillGraphic;

        [SerializeField] private TextMeshProUGUI _cooldownText;
        public TextMeshProUGUI CooldownText => _cooldownText;




    }
}
