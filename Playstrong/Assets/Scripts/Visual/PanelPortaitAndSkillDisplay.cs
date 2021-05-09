using UnityEngine;

namespace Visual
{
    public class PanelPortaitAndSkillDisplay : MonoBehaviour, IPanelPortaitAndSkillDisplay
    {
        [SerializeField] private GameObject _panelPortrait;

        public GameObject PanelPortrait
        {
            get { return _panelPortrait; }
            set { _panelPortrait = value; }
        }



        [SerializeField] private GameObject _panelSkills;

        public GameObject PanelSkills
        {
            get { return _panelSkills; }
            set { _panelSkills = value; }
        }




    }
}
