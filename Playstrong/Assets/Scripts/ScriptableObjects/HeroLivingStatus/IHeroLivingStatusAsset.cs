using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.StandardActions;

namespace ScriptableObjects.HeroLivingStatus
{
    public interface IHeroLivingStatusAsset
    {
        //HERO ACTIONS
        //TODO: Obsolete - to be replaced by basic actions in Refactoring
        void ReceiveHeroAction(IHeroAction heroAction, IHero initiator, IHero recipient);
        void ReceiveHeroAction(IHeroAction heroAction, IHero target,  float value);
        void DoHeroAction(IHeroAction heroAction, IHero initiator, IHero recipient);
        void DoHeroAction(IHeroAction heroAction, IHero target,  float value);

        //BASIC ACTIONS
        void ReceiveHeroAction(IBasicActionAsset basicAction, IHero initiator, IHero recipient);
        void ReceiveHeroAction(IBasicActionAsset basicAction, IHero target, float value);
        void ReceiveHeroAction(IBasicActionAsset basicAction, IHero target);
        
        void DoHeroAction(IBasicActionAsset basicAction, IHero target, float value);
        void DoHeroAction(IBasicActionAsset basicAction, IHero initiator, IHero recipient);
        void DoHeroAction(IBasicActionAsset basicAction, IHero target);

        //STANDARD ACTIONS 
        //TODO: May not be required - checking done at basic actions
        void ReceiveHeroAction(IStandardActionAsset standardAction, IHero initiator, IHero recipient);
        void ReceiveHeroAction(IStandardActionAsset standardAction, IHero target, float value);
        void ReceiveHeroAction(IStandardActionAsset standardAction, IHero targetHero);
        void DoHeroAction(IStandardActionAsset standardAction, IHero initiator, IHero recipient);
        void DoHeroAction(IStandardActionAsset standardAction, IHero target, float value);
        void DoHeroAction(IStandardActionAsset standardAction, IHero target);
        
    }
}