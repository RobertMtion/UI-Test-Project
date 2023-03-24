using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrackElement : VisualElement
{
    public TrackElement()
    {
        AddToClassList("timeline-track");
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
}
