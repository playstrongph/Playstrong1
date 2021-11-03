using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseBaseHealth", menuName = "SO's/BasicActions/DecreaseBaseHealth")]
    
    public class DecreaseBaseHealthBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int flatHealth;
        [SerializeField] private int percentHealth;

        private int _changeHealthValue;
        
        public override IEnumerator StartAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //Bypass living hero check
            logicTree.AddCurrent(TargetAction(targetHero));
            
            logicTree.EndSequence();
            yield return null;

        }
        
        public override IEnumerator StartAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //Bypass living hero check
            logicTree.AddCurrent(TargetAction(thisHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;

        }

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var currentHealth = targetHero.HeroLogic.HeroAttributes.Health;
         
            SetChangeHealthValue(targetHero);

            targetHero.HeroLogic.HeroAttributes.BaseHealth -= _changeHealthValue;
            
            //Cap the minimum base health to 1
            targetHero.HeroLogic.HeroAttributes.BaseHealth = Mathf.Max(targetHero.HeroLogic.HeroAttributes.BaseHealth, 1);
            
            var newBaseHealthValue = targetHero.HeroLogic.HeroAttributes.BaseHealth;
            
            if(currentHealth > newBaseHealthValue)
                targetHero.HeroLogic.SetHeroHealth.SetHealth(newBaseHealthValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var currentHealth = targetHero.HeroLogic.HeroAttributes.Health;
            
            SetChangeHealthValue(targetHero);

            targetHero.HeroLogic.HeroAttributes.BaseHealth -= _changeHealthValue;
            
            //Cap the minimum base health to 1
            targetHero.HeroLogic.HeroAttributes.BaseHealth = Mathf.Max(targetHero.HeroLogic.HeroAttributes.BaseHealth, 1);
            
            var newBaseHealthValue = targetHero.HeroLogic.HeroAttributes.BaseHealth;
            
            if(currentHealth > newBaseHealthValue)
                targetHero.HeroLogic.SetHeroHealth.SetHealth(newBaseHealthValue);

            logicTree.EndSequence();
            yield return null;
        }


        private void SetChangeHealthValue(IHero hero)
        {
            var baseHealth = hero.HeroLogic.HeroAttributes.BaseHealth;
            _changeHealthValue = Mathf.FloorToInt((float)baseHealth * percentHealth/100) + flatHealth;
        }

      










    }
}
