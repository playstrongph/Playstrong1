using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interfaces;
using Logic;
using ScriptableObjects;
using ScriptableObjects.Others;
using UnityEngine;
using Utilities;
using Visual;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


namespace References
{
    public class Hero : MonoBehaviour, IHero
    {

        [SerializeField] private string _heroName;

        public string HeroName
        {
            get => _heroName;
            set => _heroName = value;
        }

        [SerializeField] [RequireInterface(typeof(IHeroLogic))]
        private Object _heroLogic;
        public IHeroLogic HeroLogic => _heroLogic as IHeroLogic;
        
        [SerializeField] [RequireInterface(typeof(IHeroSkills))]
        private Object _heroSkills;

        public IHeroSkills HeroSkills => _heroSkills as IHeroSkills;
        
        [SerializeField] [RequireInterface(typeof(IHeroVisual))]
        private Object _heroVisual;
        public IHeroVisual HeroVisual => _heroVisual as IHeroVisual;
        
        [SerializeField]
        [RequireInterface(typeof(IHeroStatusEffects))]
        private Object _heroStatusEffects;
     
        public IHeroStatusEffects HeroStatusEffects => _heroStatusEffects as IHeroStatusEffects;
        
        
        [SerializeField] [RequireInterface(typeof(IStatusEffectsVisual))]
        private Object _statusEffectsVisual;
        public IStatusEffectsVisual StatusEffectsVisual => _statusEffectsVisual as IStatusEffectsVisual;
        
        [SerializeField] [RequireInterface(typeof(IHeroPreviewVisual))]
        private Object _heroPreviewVisual;
        public IHeroPreviewVisual HeroPreviewVisual => _heroPreviewVisual as IHeroPreviewVisual;

        [SerializeField] [RequireInterface(typeof(IHeroPortrait))]
        private Object _heroPortrait;

        public IHeroPortrait HeroPortrait => _heroPortrait as IHeroPortrait;
        
        [SerializeField] [RequireInterface(typeof(IPanelHeroPortrait))]
        private Object _panelHeroPortrait;

        public IPanelHeroPortrait PanelHeroPortrait => _panelHeroPortrait as IPanelHeroPortrait;
        
        [SerializeField] [RequireInterface(typeof(PanelHeroSkills))]
        private Object _panelHeroSkills;

        public PanelHeroSkills PanelHeroSkills => _panelHeroSkills as PanelHeroSkills;

        [SerializeField] [RequireInterface(typeof(ITargetHero))]
        private Object _targetHero;
        public ITargetHero TargetHero => _targetHero as ITargetHero;

        [SerializeField] [RequireInterface(typeof(ICoroutineTreesAsset))]
        private Object _coroutineTreeAsset;
        public ICoroutineTreesAsset CoroutineTreesAsset => _coroutineTreeAsset as ICoroutineTreesAsset;

        private Transform _heroTransfrom;
        public Transform HeroTransform => _heroTransfrom;

        private IDamageEffect _damageEffect;
        public IDamageEffect DamageEffect => _damageEffect;
        
        
        private ILivingHeroes _livingHeroes;
        public ILivingHeroes LivingHeroes => _livingHeroes;

        private IDeadHeroes _deadHeroes;
        public IDeadHeroes DeadHeroes => _deadHeroes;

        public List<IHero> AllAllyHeroes { get;} = new List<IHero>();
        
        public List<IHero> AllOtherAllyHeroes { get;} = new List<IHero>();


        private void Awake()
        {
            _heroTransfrom = this.transform;
            _damageEffect = GetComponentInChildren<IDamageEffect>();
            _livingHeroes = GetComponentInParent<ILivingHeroes>();
            //_deadHeroes = LivingHeroes.Player.DeadHeroes;

        }

        private void Start()
        {
            _deadHeroes = LivingHeroes.Player.DeadHeroes;
            GetAllLivingAllyHeroes();
            GetAllOtherLivingAllyHeroes();
        }

        public List<IHero> GetAllLivingAllyHeroes()
        {
            AllAllyHeroes.Clear();
            
            foreach (var heroObject in LivingHeroes.HeroesList)
            {
                var hero = heroObject.GetComponent<IHero>();
                AllAllyHeroes.Add(hero);
            }
            
            //Any reason not to randomize this here?
            return AllAllyHeroes;
        }
        
        public List<IHero> GetAllOtherLivingAllyHeroes()
        {
            AllOtherAllyHeroes.Clear();
            
            foreach (var heroObject in LivingHeroes.HeroesList)
            {
                var hero = heroObject.GetComponent<IHero>();
                
                if(hero != (IHero)this)
                    AllOtherAllyHeroes.Add(hero);
            }
            
            //Any reason not to randomize this here?
            return AllOtherAllyHeroes;
        }
        
        //this can be obsoleted if the 'Get' method gets randomized
        public void ShuffleAllLivingAllyHeroes()
        {
            AllAllyHeroes.Clear();
            
            foreach (var heroObject in LivingHeroes.HeroesList)
            {
                var hero = heroObject.GetComponent<IHero>();
                AllAllyHeroes.Add(hero);
            }
            ShuffleList(AllAllyHeroes);
        }
        
        //this can be obsoleted if the 'Get' method gets randomized
        public void ShuffleOtherLivingAllyHeroes()
        {
            AllOtherAllyHeroes.Clear();
            
            foreach (var heroObject in LivingHeroes.HeroesList)
            {
                var hero = heroObject.GetComponent<IHero>();
                //Debug.Log("Hero: " +hero.HeroName);
                
                if(hero != (IHero)this)
                    AllOtherAllyHeroes.Add(hero);
            }

            ShuffleList(AllOtherAllyHeroes);
        }
        
        
        
        private void ShuffleList(List<IHero> heroList)
        {
            //Randomize the List
            for (var i = 0; i < heroList.Count; i++) 
            {
                var temp = heroList[i];
                var randomIndex = Random.Range(i, heroList.Count);
                
                heroList[i] = heroList[randomIndex];
                heroList[randomIndex] = temp;
                
            }
            
           
            
        }
        
        
        
    }
}
