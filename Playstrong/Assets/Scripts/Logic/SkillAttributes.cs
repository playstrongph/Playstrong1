using Interfaces;
using UnityEngine;

namespace Logic
{
    public class SkillAttributes : MonoBehaviour, ISkillAttributes
    {
        [SerializeField] private int _cooldown;

        public int Cooldown
        {
            get => _cooldown;
            set => _cooldown = value;
        }

        [SerializeField] private int _baseCooldown;

        public int BaseCooldown
        {
            get => _baseCooldown;
            set => _baseCooldown = value;
        }
        
        


    }
}
