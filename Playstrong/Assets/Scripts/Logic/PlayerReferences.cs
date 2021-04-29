using System;
using System.Collections;
using Interfaces;
using References;
using ScriptableObjects;
using UnityEngine;
using Utilities;

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

        private IHeroesListReference _heroesListReference;
        public IHeroesListReference HeroesListReference => _heroesListReference;

        private void Awake()
        {
            _initializePlayerHeroes = GetComponent<IInitializePlayerHeroes>();
            _initializeHeroSkills = GetComponent<IInitializeHeroSkills>();
            _heroesListReference = GetComponent<IHeroesListReference>();

        }
    }
}
