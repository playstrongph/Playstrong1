﻿using System;
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
        
        [SerializeField] [RequireInterface(typeof(IObjectList))]
        private Object _livingHeroes;
        public IObjectList LivingHeroes => _livingHeroes as IObjectList;
        
        [SerializeField] [RequireInterface(typeof(IObjectList))]
        private Object _deadHeroes;
        public IObjectList DeadHeroes => _deadHeroes as IObjectList;

        [SerializeField] [RequireInterface(typeof(IObjectList))]
        private Object _heroSkillsList;
        public IObjectList HeroSkillsList => _heroSkillsList as IObjectList;

        [SerializeField] [RequireInterface(typeof(IObjectList))]
        private Object _heroPortraitList;
        public IObjectList HeroPortraitList => _heroPortraitList as IObjectList;
        
        [SerializeField] [RequireInterface(typeof(IObjectList))]
        private Object _panelSkillsList;
        public IObjectList PanelSkillsList => _panelSkillsList as IObjectList;
        
        [SerializeField] [RequireInterface(typeof(IObjectList))]
        private Object _panelPortraitList;
        public IObjectList PanelPortraitList => _panelPortraitList as IObjectList;
        
        
        
        
        
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

        [RequireInterface(typeof(IInitializePanelPortraits))]
        private Object _initializePanelPortraits;

        public IInitializePanelPortraits InitializePanelPortraits
        {
            get => _initializePanelPortraits as InitializePanelPortraits;
            private set => _initializePanelPortraits = value as Object;
        }

        [RequireInterface(typeof(ICreatePanelPortraitReferences))]
        private Object _createPanelPortraitReferences;

        public ICreatePanelPortraitReferences CreatePanelPortraitReferences
        {
            get => _createPanelPortraitReferences as ICreatePanelPortraitReferences;
            private set => _createPanelPortraitReferences = value as Object;
        }

       [RequireInterface(typeof(IInitializePanelSkills))]
        private Object _initializePanelSkills;

        public IInitializePanelSkills InitializePanelSkills
        {
            get => _initializePanelSkills as IInitializePanelSkills;
            private set => _initializePanelSkills = value as Object;
        }

        [RequireInterface(typeof(ICreatePanelSkillReferences))]
        private Object _createPanelSkillReferences;

        public ICreatePanelSkillReferences CreatePanelSkillReferences
        {
            get => _createPanelSkillReferences as ICreatePanelSkillReferences;
            private set => _createPanelSkillReferences = value as Object;
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