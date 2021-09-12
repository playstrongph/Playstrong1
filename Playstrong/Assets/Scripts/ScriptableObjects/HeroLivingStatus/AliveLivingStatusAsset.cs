using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.HeroLivingStatus
{
    [CreateAssetMenu(fileName = "AliveLivingStatus", menuName = "SO's/HeroLivingStatus/AliveLivingStatus")]
    public class AliveLivingStatusAsset : LivingStatusAsset
    {
        
        /// <summary>
        /// If the target hero is alive, this will call the initiator's DoAction Method
        /// </summary>
        public override void ReceiveHeroAction(IHeroAction heroAction, IHero initiator, IHero recipient)
        {
            initiator.HeroLogic.HeroLivingStatus.DoHeroAction(heroAction, initiator, recipient);
           
        }
        
        public override void ReceiveHeroAction(IBasicActionAsset basicAction, IHero initiator, IHero recipient)
        {
            initiator.HeroLogic.HeroLivingStatus.DoHeroAction(basicAction, initiator, recipient);
           
        }
        
        /// <summary>
        /// If the initiator hero is alive, this will call the initiator's TargetHero method
        /// </summary>
        public override void DoHeroAction(IHeroAction heroAction, IHero initiator, IHero recipient)
        {
            var logicTree = recipient.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(heroAction.ActionTarget(initiator, recipient));

        }
        
        public override void DoHeroAction(IBasicActionAsset basicAction, IHero initiator, IHero recipient)
        {
            var logicTree = recipient.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(basicAction.TargetAction(initiator, recipient));

        }
        
        public override void ReceiveHeroAction(IHeroAction heroAction, IHero target,  float value)
        {
            target.HeroLogic.HeroLivingStatus.DoHeroAction(heroAction, target, value);
           
        }
        
        public override void ReceiveHeroAction(IBasicActionAsset basicAction, IHero target,  float value)
        {
            target.HeroLogic.HeroLivingStatus.DoHeroAction(basicAction, target, value);
           
        }
        
        public override void DoHeroAction(IHeroAction heroAction, IHero target,  float value)
        {
            var logicTree = target.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(heroAction.ActionTarget(target,value));

        }
        
        public override void DoHeroAction(IBasicActionAsset basicAction, IHero target,  float value)
        {
            var logicTree = target.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(basicAction.TargetAction(target,value));

        }
        
        
        




    }
}
