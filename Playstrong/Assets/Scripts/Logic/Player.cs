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
    public class Player : MonoBehaviour, IPlayer
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
            get => _initializePanelPortraits as InitializePanelPortraits;
            private set => _initializePanelPortraits = value as Object;
        }

        [SerializeField] [RequireInterface(typeof(ICreatePanelPortraitReferences))]
        private Object _createPanelPortraitReferences;

        public ICreatePanelPortraitReferences CreatePanelPortraitReferences
        {
            get => _createPanelPortraitReferences as ICreatePanelPortraitReferences;
            private set => _createPanelPortraitReferences = value as Object;
        }

        [SerializeField] [RequireInterface(typeof(IInitializePanelSkills))]
        private Object _initializePanelSkils;

        public IInitializePanelSkills InitializePanelSkills
        {
            get => _initializePanelSkils as IInitializePanelSkills;
            set => _initializePanelSkils = value as Object;
        }

        [SerializeField] [RequireInterface(typeof(ICreatePanelSkillReferences))]
        private Object _createPanelSkillReferences;

        public ICreatePanelSkillReferences CreatePanelSkillReferences
        {
            get => _createPanelSkillReferences as ICreatePanelSkillReferences;
            set => _createPanelSkillReferences = value as Object;
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
            InitializePanelSkills = GetComponent<IInitializePanelSkills>();
            CreatePanelSkillReferences = GetComponent<ICreatePanelSkillReferences>();

        }
    }
}
