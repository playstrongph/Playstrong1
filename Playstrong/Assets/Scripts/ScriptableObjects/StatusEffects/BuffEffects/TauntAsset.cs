using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Taunt", menuName = "SO's/Status Effects/Buffs/Taunt")]
    public class TauntAsset : StatusEffectAsset
    {
        [SerializeField]
        private float targetChanceValue = 100f;
        
        [Header("Additional Attributes")]
        [SerializeField] private ScriptableObject tauntTargetResistance;
        private IHeroAction TauntTargetResistance => tauntTargetResistance as IHeroAction;

        [SerializeField] private float tauntChance = 1000f;
        [SerializeField] private float tauntResistance = 101f;
        
        
        //local variables
        private List<IHero> allAllyHeroes = new List<IHero>();
        
        
        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero,tauntChance));
            ApplyTargetResistanceAllyHeroes(hero,tauntResistance);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero,-tauntChance));
            ApplyTargetResistanceAllyHeroes(hero,-tauntResistance);
          
        }

        private void ApplyTargetResistanceAllyHeroes(IHero hero, float value)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            GetAllAllyHeroes(hero);
            foreach (var allyHero in allAllyHeroes)
            {
                logicTree.AddCurrent(TauntTargetResistance.StartAction(hero,value));
            }
        }
        
        //all allies - dead or living, in consideration for resurrect.
        private void GetAllAllyHeroes(IHero hero)
        {
            var livingAlliesObjects = hero.LivingHeroes.HeroesList;
            var deadAlliesObjects = hero.DeadHeroes.HeroesList;
            var allAllyHeroes = new List<IHero>();

            foreach (var livingAllyObject in livingAlliesObjects)
            {
                var ally = livingAllyObject.GetComponent<IHero>();
                allAllyHeroes.Add(ally);
            }
            
            foreach (var deadAllyObject in deadAlliesObjects)
            {
                var ally = deadAllyObject.GetComponent<IHero>();
                allAllyHeroes.Add(ally);
            }
        }












    }
}
