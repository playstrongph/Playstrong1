using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsPanel : MonoBehaviour, ISkillsPanel
{
    [SerializeField] private List<GameObject> _skillList = new List<GameObject>();
    public List<GameObject> SkillList => _skillList;
}
