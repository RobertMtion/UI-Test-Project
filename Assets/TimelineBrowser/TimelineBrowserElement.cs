using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimelineBrowserElement : VisualElement
{
    private VisualElement timelineElementsContainer = null;

    public new class UxmlFactory : UxmlFactory<TimelineBrowserElement, UxmlTraits> { }

    public TimelineBrowserElement()
    {
        AddToClassList("timeline-browser-element");

        var headerRow = new VisualElement();
        headerRow.AddToClassList("header-row");
        Add(headerRow);

        var headerTitleContainer = new VisualElement();
        headerTitleContainer.AddToClassList("header-title-container");
        headerRow.Add(headerTitleContainer);

        var headerTitle = new Label("Timelines");
        headerTitleContainer.Add(headerTitle);

        var createTimelineButton = new Button(OnCreateTimelineButtonClicked);
        createTimelineButton.AddToClassList("create-timeline-button");
        headerRow.Add(createTimelineButton);

        timelineElementsContainer = new VisualElement();
        timelineElementsContainer.AddToClassList("timeline-elements-container");
        Add(timelineElementsContainer);


        //TODO only for testing remove after
        List<TimelineBrowserItemElement> timelineBrowserItemElements = new List<TimelineBrowserItemElement>();
        for (int i = 0; i < 10; ++i)
        {
            timelineBrowserItemElements.Add(new TimelineBrowserItemElement());
        }
        RefreshTimelines(timelineBrowserItemElements);
    }

    private void OnCreateTimelineButtonClicked()
    {

    }

    //TODO when bringing this to the main project change this to a data class and then make the browser elements in this function
    public void RefreshTimelines(List<TimelineBrowserItemElement> timelineElements)
    {
        timelineElementsContainer.Clear();
        foreach (var timelineElement in timelineElements)
        {
            timelineElementsContainer.Add(timelineElement);
        }
    }
}
