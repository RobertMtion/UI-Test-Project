using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimelineBrowserElement : VisualElement
{
    public new class UxmlFactory : UxmlFactory<TimelineBrowserElement, UxmlTraits> { }

    public TimelineBrowserElement()
    {
        AddToClassList("timeline-browser-element");

        var headerRow = new VisualElement();
        headerRow.AddToClassList("header-row");
        Add(headerRow);

        var headerText = new Label("Timelines");
        headerRow.Add(headerText);

        var createTimelineButton = new Button(OnCreateTimelineButtonClicked);
        createTimelineButton.AddToClassList("create-timeline-button");
        headerRow.Add(createTimelineButton);
    }

    private void OnCreateTimelineButtonClicked()
    {

    }
}
