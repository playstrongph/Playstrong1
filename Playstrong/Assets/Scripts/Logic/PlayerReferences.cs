using System;
using System.Collections;
using Interfaces;
using References;
using ScriptableObjects;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class PlayerReferences : MonoBehaviour, IPlayerReferences
    {
        [SerializeField] [RequireInterface(typeof(IPlayerControllerEnumAsset))]
        private ScriptableObject _playerControllerEnum;
        public IPlayerControllerEnumAsset PlayerControllerEnum => _playerControllerEnum as IPlayerControllerEnumAsset;
        
        [SerializeField] [RequireInterface(typeof(IPlayerTypeEnumAsset))]
        private ScriptableObject _playerTypeEnum;
        public IPlayerTypeEnumAsset PlayerTypeEnum => _playerTypeEnum as IPlayerTypeEnumAsset;

        private IInitializePlayerHeroes _initializePlayerHeroes;
        public IInitializePlayerHeroes InitializePlayerHeroes => _initializePlayerHeroes;

        private IInitializeHeroSkills _initializeHeroSkills;
        public IInitializeHeroSkills InitializeHeroSkills => _initializeHeroSkills;

        private ICreateHeroSkillReferences _createHeroSkillReferences;
        public ICreateHeroSkillReferences CreateHeroSkillReferences => _createHeroSkillReferences;

        private IInitializeHeroPortraits _initializeHeroPortraits;
        public IInitializeHeroPortraits InitializeHeroPortraits => _initializeHeroPortraits;

        private ICreateHeroPortraitReferences _createHeroPortraitReferences;
        public ICreateHeroPortraitReferences CreateHeroPortraitReferences => _createHeroPortraitReferences;

        [SerializeField] [RequireInterface(typeof(IInitializePanelPortraits))]
        private Object _initializePanelPortraits;

        public IInitializePanelPortraits InitializePanelPortraits
        {
            get { return _initializePanelPortraits as InitializePanelPortraits; }
            set { _initializePanelPortraits = value as Object; }
        }

        [SerializeField] [RequireInterface(typeof(ICreatePanelPortraitReferences))]
        private Object _createPanelPortraitReferences;

        public ICreatePanelPortraitReferences CreatePanelPortraitReferences
        {
            get { return _createPanelPortraitReferences as ICreatePanelPortraitReferences;}
            set { _createPanelPortraitReferences = value as Object;}
        }

        private void Awake()
        {
            _initializePlayerHeroes = GetComponent<IInitializePlayerHeroes>();
            _initializeHeroSkills = GetComponent<IInitializeHeroSkills>();
            _createHeroSkillReferences = GetComponent<ICreateHeroSkillReferences>();
            _initializeHeroPortraits = GetComponent<InitializeHeroPortraits>();
            _createHeroPortraitReferences = GetComponent<ICreateHeroPortraitReferences>();
            
            InitializePanelPortraits = GetComponent<IInitializePanelPortraits>();
            CreatePanelPortraitReferences = GetComponent<ICreatePanelPortraitReferences>();
        }
    }
}
