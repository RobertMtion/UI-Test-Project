using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeyframeDraggerElement : VisualElement
{
    private VisualElement mainBar = null;
    private List<KeyframeElement> keyframeElements = new List<KeyframeElement>();

    public new class UxmlFactory : UxmlFactory<KeyframeDraggerElement, UxmlTraits> { }

    public KeyframeDraggerElement()
    {
        // Main timeline bar
        mainBar = new VisualElement();
        mainBar.AddToClassList("main-bar");
        Add(mainBar);

        CreateNewKeyframeElement();
        //CreateNewKeyframeElement();
    }

    private void CreateNewKeyframeElement()
    {
        // Keyframe dragger
        var keyframe = new KeyframeElement();
        mainBar.Add(keyframe);

        keyframeElements.Add(keyframe);
        int keyframeIndex = keyframeElements.Count - 1;

        // Drag manipulator for each keyframe
        var dragManipulator = new DragManipulator(() => OnClickKeyframe(keyframe), () => OnDragKeyframe(keyframe));
        keyframe.AddManipulator(dragManipulator);
        keyframe.DragManipulator = dragManipulator;

        mainBar.Add(keyframe);
    }

    private void OnClickKeyframe(KeyframeElement keyframe)
    {
        var keyframeIndex = keyframeElements.IndexOf(keyframe);
    }

    private void OnDragKeyframe(KeyframeElement keyframe)
    {
        Vector2 newPosition = new Vector2(
            keyframe.DragManipulator.MouseStartPosition.x + keyframe.DragManipulator.MouseMovementDelta.x, 
            keyframe.transform.position.y);
        
        if (mainBar.transform.position)



        //keyframe.transform.position = new Vector2(100, 0);

        Debug.Log(keyframe.DragManipulator.lastMousePosition);

    }
}
