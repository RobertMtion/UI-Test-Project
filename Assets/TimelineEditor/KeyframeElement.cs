using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeyframeElement : VisualElement
{
    private VisualElement dragger = null;

    public KeyframeElement()
    {
        AddToClassList("keyframe-element");
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
