using ScriptableObjectArchitecture;
using System;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    [Header("Left Axis")]
    [SerializeField] private Vector2Reference leftStickAxis = default(Vector2Reference);
    [SerializeField] private GameEvent leftStickAxisTriggered = default(GameEvent);
    
    [Header("Right Axis")]
    [SerializeField] private Vector2Reference rightStickAxis = default(Vector2Reference);
    [SerializeField] private GameEvent rightStickAxisTriggered = default(GameEvent);
    
    private void Update()
    {
        CheckingVerticalLeftStick();
        CheckingHorizontalLeftStick();
        CheckingVerticalRightStick();
        CheckingHorizontalRightStick();
    }

    #region Left Stick Functions

    private void CheckingHorizontalLeftStick()
    {
        float horizontalLeftStickAxisValue = Input.GetAxisRaw(Global.HorizontalLeftStickAxis);
        if (Math.Abs(horizontalLeftStickAxisValue) > Global.Tolerance)
            HorizontalLeftStickActions(horizontalLeftStickAxisValue);
    }

    private void HorizontalLeftStickActions(float value)
    {
        leftStickAxis.Value = new Vector2(value, leftStickAxis.Value.y);
        leftStickAxisTriggered.Raise();
    }

    private void CheckingVerticalLeftStick()
    {
        float verticalLeftStickAxisValue = Input.GetAxisRaw(Global.VerticalLeftStickAxis);
        if (Math.Abs(verticalLeftStickAxisValue) > Global.Tolerance)
            VerticalLeftStickActions(verticalLeftStickAxisValue);
    }

    private void VerticalLeftStickActions(float value)
    {
        leftStickAxis.Value = new Vector2(leftStickAxis.Value.x, value);
        leftStickAxisTriggered.Raise();
    }

    #endregion

    #region Right Stick Functions

    private void CheckingHorizontalRightStick()
    {
        float horizontalRightStickAxisValue = Input.GetAxisRaw(Global.HorizontalRightStickAxis);
        if (Math.Abs(horizontalRightStickAxisValue) > Global.Tolerance)
            HorizontalRightStickActions(horizontalRightStickAxisValue);
    }

    private void HorizontalRightStickActions(float value)
    {
        rightStickAxis.Value = new Vector2(value, rightStickAxis.Value.y);
        rightStickAxisTriggered.Raise();
    }

    private void CheckingVerticalRightStick()
    {
        float verticalRightStickAxisValue = Input.GetAxisRaw(Global.VerticalRightStickAxis);
        if (Math.Abs(verticalRightStickAxisValue) > Global.Tolerance)
            VerticalRightStickActions(verticalRightStickAxisValue);
    }

    private void VerticalRightStickActions(float value)
    {
        rightStickAxis.Value = new Vector2(rightStickAxis.Value.x, value);
        rightStickAxisTriggered.Raise();
    }

    #endregion
}
