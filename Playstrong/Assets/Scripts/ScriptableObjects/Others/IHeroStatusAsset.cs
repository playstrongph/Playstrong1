using System.Collections;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.Others
{
    public interface IHeroStatusAsset
    {

        void StatusAction(IHeroLogic heroLogic);
        void InitializeTurnController(ITurnController turnController);

        void RemoveFromActiveHeroesList(ITurnController turnController, Object heroTimer);

        IEnumerator EndHeroTurn(IHeroLogic heroLogic);
        
       /*//Cleanup
       IEnumerator HeroUsingSkill(ISkill skill);

       IEnumerator HeroUsedSkillLastTurn(ISkill skill);*/
    }
}