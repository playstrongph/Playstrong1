﻿using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.SkillCondition.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillEffects
{
   
    [CreateAssetMenu(fileName = "SkillEffectAsset", menuName = "SO's/SkillEffect/SkillEffectAsset")]
    public class SkillEffectAsset : ScriptableObject, ISkillEffectAsset
    {

        public void UseSkillEffect(IHero hero)
        {
            foreach (var skillCondition in SkillConditionAssets )
            {
                skillCondition.Target(hero);
            }
        }

        [SerializeField] private List<Object> _skillConditionAssets = new List<Object>();

        public List<ISkillConditionAsset> SkillConditionAssets
        {
            get
            {
                var skillConditions = new List<ISkillConditionAsset>();
                foreach (var skillConditionAssetObject in _skillConditionAssets)
                {
                    var skillCondition = skillConditionAssetObject as ISkillConditionAsset;
                    skillConditions.Add(skillCondition);
                }

                return skillConditions;

            }
            
        }


    }
}
