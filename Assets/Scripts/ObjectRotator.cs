using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("The speed and direction of the rotation")]
    public Vector3 rotationSpeed = new Vector3(0, 50, 0);

    // Update is called once per frame
    void Update()
    {
        // Rotates the object based on the speed vector provided
        // Time.deltaTime ensures the rotation is smooth and independent of frame rate
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}