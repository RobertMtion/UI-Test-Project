using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimelineElement : VisualElement
{
    private VisualElement mainBar = null;
    private VisualElement timelineIndicatorContainer = null;
    private KeyframeElement currentlySelectedKeyframe = null;
    private TrackElement currentlySelectedTrackElement = null;
    private HashSet<TrackElement> trackElements = new HashSet<TrackElement>();
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

        // Timeline indicators
        timelineIndicatorContainer = new VisualElement();
        timelineIndicatorContainer.AddToClassList("timeline-indicator-container");
        mainBar.Add(timelineIndicatorContainer);

        var largeIndex = 6;
        var mediumIndex = 3;
        var numUnits = 10;
        for (int i = 0; i < largeIndex * numUnits + 1; ++i)
        {
            var verticalBarPadding = new VisualElement();
            verticalBarPadding.AddToClassList("timeline-indicator-padding");
            if (i != 0)
            {
                timelineIndicatorContainer.Add(verticalBarPadding);                
            }

            var verticalBar = new VisualElement();
            verticalBar.AddToClassList("timeline-indicator");
            if (i % largeIndex == 0)
            {
                verticalBar.AddToClassList("large");
            }
            else if (i % mediumIndex == 0)
            {
                verticalBar.AddToClassList("medium");
            }
            timelineIndicatorContainer.Add(verticalBar);
        }
        
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

    public List<List<float>> GetKeyframeValues()
    {
        var output = new List<List<float>>();
        
        /*
        foreach (var trackKeyframePair in trackElements)
        {
            var keyframeValues = new List<float>();
            foreach (var keyframe in trackKeyframePair.Value)
            {
                float percentageValue = keyframe.resolvedStyle.left / (mainBar.resolvedStyle.width - keyframe.resolvedStyle.width);
                keyframeValues.Add(percentageValue);
            }

            keyframeValues.Sort();
            output.Add(keyframeValues);
        }
        */

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

        trackElements.Remove(currentlySelectedTrackElement);
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
        currentlySelectedTrackElement.AddKeyframe(keyframe);
    }

    private void DeleteSelectedKeyframeElement()
    {
        if (currentlySelectedTrackElement == null || currentlySelectedKeyframe == null)
        {
            return;
        }

        //TODO this logic needs to be revisited
        currentlySelectedTrackElement.RemoveKeyframe(currentlySelectedKeyframe);
        currentlySelectedTrackElement.Remove(currentlySelectedKeyframe);
        currentlySelectedKeyframe = null;
    }

    private void OnMouseDownTrack(MouseDownEvent evt)
    {
        if (currentlySelectedTrackElement !=  null)
        {
            currentlySelectedTrackElement.SetSelected(false);
        }

        currentlySelectedTrackElement = evt.currentTarget as TrackElement;;
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
        if (currentlySelectedKeyframe == null || currentlySelectedTrackElement == null)
        {
            return;
        }
        
        var keyframeDesiredPosition = keyframeDragManipulator.lastMousePosition.x 
                                      - currentlySelectedTrackElement.HeaderContainerWidth 
                                      - currentlySelectedKeyframe.resolvedStyle.width / 2f;
        
        var maxDesiredPosition = currentlySelectedTrackElement.KeyframeContainerWidth - currentlySelectedKeyframe.resolvedStyle.width;
        currentlySelectedKeyframe.style.left = Mathf.Clamp(keyframeDesiredPosition, 0f, maxDesiredPosition);

        if (keyframeDesiredPosition > maxDesiredPosition)
        {
            //TODO if we want to do scrolling for larger widths
            //Debug.Log(keyframeDesiredPosition - maxDesiredPosition);
        }
    }
}
