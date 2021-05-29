using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class GetSkillTargets : MonoBehaviour, IGetSkillTargets
    {
        private ITargetSkill _targetSkill;

        private IHero _thisHero;
        
        private List<IHero> _validTargets = new List<IHero>();
        
        private List<IHero> _enemyNormalHeroes = new List<IHero>();
        private List<IHero> _enemyTauntHeroes = new List<IHero>();
        private List<IHero> _enemyStealthHeroes = new List<IHero>();
        //New List Based on Allowed SkillTargets
        
        



    }
}
