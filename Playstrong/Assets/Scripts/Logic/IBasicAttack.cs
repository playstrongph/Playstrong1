using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IBasicAttack: IHeroAction
    {
        //IEnumerator BasicAttackHero(IHero targetHero);

        void ModifyAttack(int attackModifier);
    }
}