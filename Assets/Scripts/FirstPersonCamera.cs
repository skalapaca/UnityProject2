using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float xRotation = 0;
    public float yRotation = 0;
    public float xSpeed = 10f;
    public float ySpeed = 10f;
    public float maxLookUpAngle = 85f;
    public float maxLooKDownAngle = -85f;
    public Transform cameraTransform;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void AdjustRotation(float xDelta, float yDelta)
    {
        xDelta *= xSpeed * Time.deltaTime;
        yDelta *= ySpeed * Time.deltaTime;
        yRotation += xDelta;
        xRotation -= yDelta;
        // limit the rotation of the camera
        xRotation = Mathf.Clamp(xRotation, maxLooKDownAngle, maxLookUpAngle);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}