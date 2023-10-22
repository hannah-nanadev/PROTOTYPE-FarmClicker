using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;

    // Awake is called on object initialisation.
    void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        
    }
}
