using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    GameManager game;
    InputManager input;
    Camera cam;


    private void Awake()
    {
        game = GetComponent<GameManager>();
        input = GetComponent<InputManager>();
        cam = Camera.main;
    }

    private void OnEnable()
    {
        input.OnLeftClick += HandleInput;
        HandleInput(Vector2.zero);

    }

    private void HandleInput(Vector2 position)
    {
        Vector3 worldPosition = cam.ScreenToViewportPoint(position);
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(position), Vector2.zero);
        if (hit.collider != null)
        {
            IClickable IClickableObject = hit.collider.gameObject.GetComponent<IClickable>();
            if (IClickableObject != null)
            {
                IClickableObject.OnClick();
            }

        }
    }

}
