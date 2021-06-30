using ScriptableObjects.Modifiers;

namespace ScriptableObjects.Actions
{
    public interface IHealActionAsset
    {
        IModifier HealAmount { get; }
    }
}