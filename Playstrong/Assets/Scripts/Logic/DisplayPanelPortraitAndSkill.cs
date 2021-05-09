using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Visual;

public class DisplayPanelPortraitAndSkill : MonoBehaviour
{
    private ITargetHeroPreview _targetHeroPreview;
    private IPanelHeroPortrait _panelHeroPortrait;
    private IPanelHeroSkills _panelHeroSkills;

    [SerializeField]
    private GameObject _displayedPortrait;
    
    [SerializeField]
    private GameObject _displayedSkill;

    private void Awake()
    {
        _targetHeroPreview = GetComponent<ITargetHeroPreview>();
    }

    public void OnMouseDown()
    {
      
        _panelHeroPortrait = _targetHeroPreview.Hero.PanelHeroPortrait;
        _panelHeroSkills = _targetHeroPreview.Hero.PanelHeroSkills;
        
        _panelHeroPortrait.Portrait.SetActive(true);
        _panelHeroSkills.PanelSkills.SetActive(true);

        _displayedPortrait = _panelHeroPortrait.Portrait;
        _displayedSkill = _panelHeroSkills.PanelSkills;
    }
}
