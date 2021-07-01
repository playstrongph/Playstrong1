using Interfaces;
using Logic;

namespace ScriptableObjects.HeroLivingStatus
{
    public interface IHeroLivingStatusAsset
    {
        /// <summary>
        /// This should be the method called by all 'action' classes that implement IHeroAction
        /// Example: DragHeroAttack, AddBuff, DealDamage, etc. 
        /// </summary>
        void ReceiveHeroAction(IHeroAction heroAction, IHero initiator, IHero recipient);
        
        void DoHeroAction(IHeroAction heroAction, IHero recipient);
    }
}