using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    Controls controls;

    public delegate void LeftClickEvent(Vector2 position);
    public event LeftClickEvent OnLeftClick;

    void Awake()
    {
        controls = new Controls();    
    }

    private void Start()
    {
        controls.Camera.Move.performed += ctx => CameraMove();
        controls.Mouse.Left.canceled += ctx => LeftClick();
    }

    private void OnEnable()
    {
        controls.Camera.Move.Enable();
        controls.Mouse.Enable();
    }

    private void LeftClick()
    {
        OnLeftClick?.Invoke(GetMousePosition());
    }

    public Vector2 GetMousePosition()
    {
        return controls.Mouse.MousePosition.ReadValue<Vector2>();
    }

    public void CameraMove()
    {

    }
   



}
