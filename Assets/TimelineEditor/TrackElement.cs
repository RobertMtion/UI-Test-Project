using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrackElement : VisualElement
{
    private VisualElement headerContainer = null;
    private VisualElement keyframeContainer = null;
    private List<KeyframeElement> keyframeElements = new List<KeyframeElement>();

    //TODO revisit this
    public float HeaderContainerWidth => headerContainer.resolvedStyle.width;
    public float KeyframeContainerWidth => keyframeContainer.resolvedStyle.width;

    public TrackElement()
    {
        AddToClassList("timeline-track");
        
        headerContainer = new VisualElement();
        headerContainer.AddToClassList("timeline-track-header-container");
        Add(headerContainer);
        
        keyframeContainer = new VisualElement();
        keyframeContainer.AddToClassList("timeline-track-keyframe-container");
        Add(keyframeContainer);
    }

    public void AddKeyframe(KeyframeElement keyframe)
    {
        keyframeContainer.Add(keyframe);
        keyframeElements.Add(keyframe);
    }
    
    public void RemoveKeyframe(KeyframeElement keyframe)
    {
        keyframeContainer.Remove(keyframe);
        keyframeElements.Remove(keyframe);
    }

    public void SetSelected(bool selected)
    {
        if (selected)
        {
            AddToClassList("selected");
        }
        else
        {
            RemoveFromClassList("selected");
        }
    }

    public List<float> GetKeyframeValues()
    {
        List<float> output = new List<float>();
        return output;
    }
}
