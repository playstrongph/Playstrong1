using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.StandardActions;

namespace ScriptableObjects.HeroLivingStatus
{
    public interface IHeroLivingStatusAsset
    {
        /// <summary>
        /// This should be the method called by all 'action' classes that implement IHeroAction
        /// Example: DragHeroAttack, AddBuff, DealDamage, etc. 
        /// </summary>
        void ReceiveHeroAction(IHeroAction heroAction, IHero initiator, IHero recipient);
        
        void DoHeroAction(IHeroAction heroAction, IHero initiator, IHero recipient);

        void ReceiveHeroAction(IHeroAction heroAction, IHero target,  float value);

        void DoHeroAction(IHeroAction heroAction, IHero target,  float value);
        
        //TEST - Standard Actions implementation
        void ReceiveHeroAction(IStandardActionAsset standardAction, IHero initiator, IHero recipient);

        void ReceiveHeroAction(IStandardActionAsset standardAction, IHero target, float value);

        void DoHeroAction(IStandardActionAsset standardAction, IHero initiator, IHero recipient);

        void DoHeroAction(IStandardActionAsset standardAction, IHero target, float value);
    }
}