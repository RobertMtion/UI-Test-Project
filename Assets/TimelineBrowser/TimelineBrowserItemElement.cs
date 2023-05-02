using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimelineBrowserItemElement : VisualElement
{
    private VisualElement nameHeader = null;
    private Button editButton = null;
    private Button previewButton = null;
    private Button deleteButton = null;

    public new class UxmlFactory : UxmlFactory<TimelineBrowserItemElement, UxmlTraits> { }

    public TimelineBrowserItemElement()
    {
        AddToClassList("timeline-browser-item-element");

        nameHeader = new Label("Name");
        nameHeader.AddToClassList("name-header");
        Add(nameHeader);

        editButton = new Button(OnEditButtonClicked);
        editButton.AddToClassList("edit-button");
        editButton.Add(new Label("Edit"));
        Add(editButton);

        previewButton = new Button(OnPreviewButtonClicked);
        previewButton.AddToClassList("preview-button");
        previewButton.Add(new Label("Preview"));
        Add(previewButton);

        deleteButton = new Button(OnDeleteButtonClicked);
        deleteButton.AddToClassList("delete-button");
        deleteButton.Add(new Label("Delete"));
        Add(deleteButton);
    }

    private void OnEditButtonClicked()
    {

    }

    private void OnPreviewButtonClicked()
    {

    }

    private void OnDeleteButtonClicked()
    {

    }
}
