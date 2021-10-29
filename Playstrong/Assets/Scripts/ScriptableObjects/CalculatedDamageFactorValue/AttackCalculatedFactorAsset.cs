﻿using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    [CreateAssetMenu(fileName = "AttackFactor", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/AttackFactor")]
    public class AttackCalculatedFactorAsset : CalculatedFactorValueAsset
    {

        public override float GetCalculatedValue()
        {
            var attackFactor = 0;
            
            //Damage Taken Factor
            if (CalculationHeroBasis != null)
                attackFactor = Mathf.CeilToInt(CalculationHeroBasis.HeroLogic.HeroAttributes.Attack * percentFactor / 100f);

            return attackFactor;
        }
       
    }
}
