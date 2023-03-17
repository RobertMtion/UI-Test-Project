using UnityEngine;
using UnityEngine.UIElements;

public class DragManipulator : Clickable
{
    private event System.Action onDrag;
    private Vector2 mouseStartPosition;
    private bool dragging = false;

    public bool Dragging => dragging;
    public Vector2 MouseStartPosition => mouseStartPosition;
    public Vector2 MouseMovementDelta => (lastMousePosition - mouseStartPosition);

    public DragManipulator(System.Action clickHandler, System.Action dragHandler) : base(clickHandler, 0, 10)
    {
        onDrag = dragHandler;
    }

    protected override void ProcessDownEvent(EventBase evt, Vector2 localPosition, int pointerId)
    {
        dragging = false;
        mouseStartPosition = localPosition;
        base.ProcessDownEvent(evt, localPosition, pointerId);
    }

    protected override void ProcessMoveEvent(EventBase evt, Vector2 localPosition)
    {
        dragging = true;
        onDrag?.Invoke();
        base.ProcessMoveEvent(evt, localPosition);
    }
}
