using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeyframeElement : BaseField<float>
{
    public DragManipulator DragManipulator = null;

    public new class UxmlFactory : UxmlFactory<KeyframeElement, UxmlTraits> { }

    public KeyframeElement() : base(null, null)
    {
        var mainDragger = new VisualElement();
        mainDragger.AddToClassList("main-dragger");
        Add(mainDragger);
    }
}
