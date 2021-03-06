using System.Collections;
using Interfaces;
using ScriptableObjects.AnimationSOscripts;
using ScriptableObjects.Enums.SkillStatus;

public interface ISkillAttack
{
    int AdditionalAttackDamage { get; set; }
    IEnumerator StartSkillAttack(IHero thisHero, IHero targetHero, ISingleOrMultiAttackTypeAsset attackTargetType, IGameAnimations attackAnimation, float visualDelay);
}