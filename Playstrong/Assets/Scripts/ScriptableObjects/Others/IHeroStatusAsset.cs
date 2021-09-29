﻿using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.Others
{
    public interface IHeroStatusAsset
    {

        void StatusAction(IHeroLogic heroLogic);
        void InitializeTurnController(ITurnController turnController);

        void RemoveFromActiveHeroesList(ITurnController turnController, Object heroTimer);

        IEnumerator EndHeroTurn(IHeroLogic heroLogic);

    }
}