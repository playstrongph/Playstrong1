using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Curse", menuName = "SO's/Status Effects/Debuffs/Curse")]
    public class CurseAsset : StatusEffectAsset
    {
        [SerializeField] private int curseDamage = 0;
        [SerializeField] private float percentFactor = 10f;

        private IHero _hero;
        private ITurnController _turnController;

        private IHero _heroAttackedThisTurn;

        public override void ApplyStatusEffect(IHero thisHero)
        {
            _hero = thisHero;
            _turnController = _hero.LivingHeroes.Player.BattleSceneManager.TurnController;

            foreach (var hero in thisHero.AllAllyHeroes)
            {
                _turnController.TurnControllerEvents.EEndCombatTurn += DealCurseDamage;
                hero.HeroLogic.HeroEvents.EPostAttack += ComputeCurseDamage;
            }
        }
        
        public override void UnapplyStatusEffect(IHero thisHero)
        {
            _hero = thisHero;
            _turnController = _hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            
            foreach (var hero in thisHero.AllAllyHeroes)
            {
                _turnController.TurnControllerEvents.EEndCombatTurn -= DealCurseDamage;
                hero.HeroLogic.HeroEvents.EPostAttack -= ComputeCurseDamage;
            }

        }

        private void ComputeCurseDamage(IHero allyHero, IHero dummyHero)
        {
            var finalDamage = allyHero.HeroLogic.TakeDamage.FinalDamage;
            var floatCurseDamage = percentFactor * finalDamage / 100;

            _heroAttackedThisTurn = allyHero;
            
            //In case the hero receives more than 1 singleAttack in a turn
            curseDamage += Mathf.CeilToInt(floatCurseDamage);
            
            Debug.Log("Compute CurseDamage: " +curseDamage);

        }

        private void DealCurseDamage()
        {
            var logicTree = _hero.CoroutineTreesAsset.MainLogicTree;
            
            Debug.Log("Deal CurseDamage: " +curseDamage);
            if (curseDamage > 0)
                logicTree.AddCurrent(_heroAttackedThisTurn.HeroLogic.TakeDamage.TakeDirectDamage(curseDamage, 0, 0));

            curseDamage = 0;
        }








    }
}
