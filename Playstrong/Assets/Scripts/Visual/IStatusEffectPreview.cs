using TMPro;
using UnityEngine.UI;

namespace Visual
{
    public interface IStatusEffectPreview
    {
        Image StatusEffectIcon { get; }
        TextMeshProUGUI StatusEffectName { get; }
        TextMeshProUGUI StatusEffectDescription { get; }

        ILoadStatusEffectPreview LoadStatusEffectPreview { get; }
    }
}