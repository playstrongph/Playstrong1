using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IBasicActionAsset
    {
        //StartActions
        IEnumerator StartAction(IHero thisHero, IHero targetHero);
        IEnumerator StartAction(IHero hero);
        IEnumerator StartAction(IHero hero, float value);
        
        
        
        //TargetActions
        IEnumerator TargetAction(IHero thisHero, IHero targetHero);
        IEnumerator TargetAction(IHero hero);
        IEnumerator TargetAction(IHero hero, float value);
        
        //UndoTargetActions - Parked
        //IEnumerator UndoTargetAction(IHero thisHero, IHero targetHero);
        //IEnumerator UndoTargetAction(IHero hero);
        //IEnumerator UndoTargetAction(IHero hero, float value);
    }
}