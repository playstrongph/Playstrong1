using System;
using System.Collections;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "IncreaseBaseAttackAllAllies", menuName = "SO's/SkillActions/IncreaseBaseAttackAllAlliesAsset")]
    
    public class IncreaseBaseAttackAllAlliesAsset : SkillActionAsset
    {

        [SerializeField] private float percentIncrease;
        
        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
           InitializeValues(thisHero, targetHero);

           AllAlliesBaseAttackIncrease(thisHero);
            
           LogicTree.EndSequence();
           yield return null;

        }

        private void AllAlliesBaseAttackIncrease(IHero thisHero)
        {
            var allyHeroObjects = thisHero.LivingHeroes.HeroesList;

            foreach (var allyHeroObject in allyHeroObjects)
            {
                var allyHero = allyHeroObject.GetComponent<IHero>();

                var amountIncrease = Mathf.FloorToInt(allyHero.HeroLogic.HeroAttributes.HeroAssetAttack * percentIncrease);
                
                allyHero.HeroLogic.HeroAttributes.BaseAttack += amountIncrease;
                allyHero.HeroLogic.HeroAttributes.Attack += amountIncrease;

                var attackValue = allyHero.HeroLogic.HeroAttributes.Attack;
                allyHero.HeroVisual.AttackVisual.SetAttackText(attackValue.ToString());

            }
            
        }



        



      


    }
}
