using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimelineElement : VisualElement
{
    private VisualElement mainBar = null;
    private TrackElement currentlySelectedTrackElement = null;
    List<TrackElement> trackElements = new List<TrackElement>();
    private KeyframeElement currentlySelectedKeyframe = null;
    private List<KeyframeElement> keyframeElements = new List<KeyframeElement>();
    private DragManipulator keyframeDragManipulator = null;

    //TODO remove after, only for testing
    private VisualElement buttonContainer = null;

    public new class UxmlFactory : UxmlFactory<TimelineElement, UxmlTraits> { }

    public TimelineElement()
    {
        // Main timeline bar
        mainBar = new VisualElement();
        mainBar.AddToClassList("timeline-main-bar");
        Add(mainBar);

        // Drag manipulator for keyframes
        keyframeDragManipulator = new DragManipulator(null, OnDragKeyframe);
        mainBar.AddManipulator(keyframeDragManipulator);

        ////////////////////////////////////////////////////////////
        // TEMP - Button container
        buttonContainer = new VisualElement();
        Add(buttonContainer);

        // Add track button
        var addTrackButton = new Button(CreateNewTrackElement);
        addTrackButton.Add(new Label("Add Track"));
        buttonContainer.Add(addTrackButton);

        // Delete selected track button
        var deleteTrackButton = new Button(DeleteSelectedTrackElement);
        deleteTrackButton.Add(new Label("Delete Track"));
        buttonContainer.Add(deleteTrackButton);

        // Add keyframe button
        var addKeyframeButton = new Button(CreateNewKeyframeElement);
        addKeyframeButton.Add(new Label("Add New Keyframe"));
        buttonContainer.Add(addKeyframeButton);

        // Delete selected keyframe button
        var deleteKeyframeButton = new Button(DeleteSelectedKeyframeElement);
        deleteKeyframeButton.Add(new Label("Delete Selected Keyframe"));
        buttonContainer.Add(deleteKeyframeButton);
    }

    public List<float> GetKeyframeValues()
    {
        List<float> output = new List<float>();
        foreach (var keyframeElement in keyframeElements)
        {
            //TODO calculate the 
        }

        return output;
    }

    private void CreateNewTrackElement()
    {
        var trackElement = new TrackElement();
        trackElement.SetSelected(false);
        trackElement.RegisterCallback<MouseDownEvent>(OnMouseDownTrack);
        trackElements.Add(trackElement);
        mainBar.Add(trackElement);
    }

    private void DeleteSelectedTrackElement()
    {
        if (currentlySelectedTrackElement == null)
        {
            return;
        }

        mainBar.Remove(currentlySelectedTrackElement);
        currentlySelectedTrackElement = null;
    }

    private void CreateNewKeyframeElement()
    {
        if (currentlySelectedTrackElement == null)
        {
            return;
        }

        var keyframe = new KeyframeElement();
        keyframe.SetSelected(false);
        keyframe.RegisterCallback<MouseDownEvent>(OnMouseDownKeyframe);
        currentlySelectedTrackElement.Add(keyframe);
    }

    private void DeleteSelectedKeyframeElement()
    {
        if (currentlySelectedTrackElement == null || currentlySelectedKeyframe == null)
        {
            return;
        }

        currentlySelectedTrackElement.Remove(currentlySelectedKeyframe);
        currentlySelectedKeyframe = null;
    }

    private void OnMouseDownTrack(MouseDownEvent evt)
    {
        if (currentlySelectedTrackElement !=  null)
        {
            currentlySelectedTrackElement.SetSelected(false);
        }

        currentlySelectedTrackElement = evt.currentTarget as TrackElement;
        currentlySelectedTrackElement.SetSelected(true);
    }

    private void OnMouseDownKeyframe(MouseDownEvent evt)
    {
        if (currentlySelectedKeyframe != null)
        {
            currentlySelectedKeyframe.SetSelected(false);
        }

        currentlySelectedKeyframe = evt.currentTarget as KeyframeElement;
        currentlySelectedKeyframe.SetSelected(true);
    }

    private void OnDragKeyframe()
    {
        if (currentlySelectedKeyframe != null)
        {
            currentlySelectedKeyframe.style.left =
                keyframeDragManipulator.lastMousePosition.x - currentlySelectedKeyframe.resolvedStyle.width / 2f;
        }
    }
}
