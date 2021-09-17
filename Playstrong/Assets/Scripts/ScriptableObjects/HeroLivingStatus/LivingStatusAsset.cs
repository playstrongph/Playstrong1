using Interfaces;
using Logic;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace ScriptableObjects.HeroLivingStatus
{
    public class LivingStatusAsset : ScriptableObject, IHeroLivingStatusAsset
    {
        /// <summary>
        /// If the target hero is alive, this will call the initiator's DoAction Method
        /// </summary>
        public virtual void ReceiveHeroAction(IHeroAction heroAction, IHero initiator, IHero recipient)
        {
           
           
        }
        
      

        /// <summary>
        /// If the initiator hero is alive, this will call the initiator's TargetHero method
        /// </summary>
        public virtual void DoHeroAction(IHeroAction heroAction, IHero initiator, IHero recipient)
        {
           

        }
        
       
        
        
        /// <summary>
        /// For Buffs, you only need to check if the target is alive, since if the initiator is dead, the buff
        /// gets destroyed.
        /// </summary>
        public virtual void ReceiveHeroAction(IHeroAction heroAction, IHero target, float value)
        {
           
           
        }
        
      
        
        public virtual void DoHeroAction(IHeroAction heroAction, IHero target, float value)
        {
           

        }
        
      
        
        
        //Basic Actions
        
        public virtual void ReceiveHeroAction(IBasicActionAsset basicAction, IHero initiator, IHero recipient)
        {
           
           
        }
        public virtual void ReceiveHeroAction(IBasicActionAsset basicAction, IHero target, float value)
        {
           
           
        }
        
        public virtual void ReceiveHeroAction(IBasicActionAsset basicAction, IHero target)
        {
           
           
        }
        
        public virtual void DoHeroAction(IBasicActionAsset basicAction, IHero initiator, IHero recipient)
        {
           

        }

        public virtual void DoHeroAction(IBasicActionAsset basicAction, IHero target, float value)
        {
            
        }
        
        public virtual void DoHeroAction(IBasicActionAsset basicAction, IHero target)
        {
            
        }

        //TEST: Standard Actions
        public virtual void ReceiveHeroAction(IStandardActionAsset standardAction, IHero thisHero, IHero targetHero)
        { }
        
        public virtual void ReceiveHeroAction(IStandardActionAsset standardAction, IHero targetHero, float value)
        { }
        
        public virtual void ReceiveHeroAction(IStandardActionAsset standardAction, IHero targetHero)
        { }
        
        public virtual void DoHeroAction(IStandardActionAsset standardAction, IHero thisHero, IHero targetHero)
        { }
        
        public virtual void DoHeroAction(IStandardActionAsset standardAction, IHero targetHero, float value)
        { }
        
        public virtual void DoHeroAction(IStandardActionAsset standardAction, IHero targetHero)
        { }
    }
}
