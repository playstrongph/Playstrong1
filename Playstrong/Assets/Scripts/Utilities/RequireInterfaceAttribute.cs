using UnityEngine;

namespace Assets.Scripts.Utilities
{
    /// <summary>
    /// Attribute that require implementation of the provided interface.
    /// </summary>
    public class RequireInterfaceAttribute : PropertyAttribute
    {
        // Interface type.
        public System.Type requiredType { get; private set; }

        /// <summary>
        /// Requiring implementation of the <see cref="T:Assets.Scripts.Utilities.RequireInterfaceAttribute"/> interface.
        /// </summary>
        /// <param name="type">Interface type.</param>
        public RequireInterfaceAttribute(System.Type type)
        {
            this.requiredType = type;
        }
    }
}