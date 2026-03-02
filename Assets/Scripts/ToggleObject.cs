using UnityEngine;
using UnityEngine.InputSystem; // Add this line!

public class ToggleObject : MonoBehaviour
{
    public GameObject targetObject;

    void Update()
    {
        // New System syntax for "Was the E key pressed this frame?"
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (targetObject != null)
            {
                targetObject.SetActive(!targetObject.activeSelf);
            }
        }
    }
}