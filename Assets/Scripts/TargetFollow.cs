using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    public Transform followTransform;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = followTransform.position;
    }
}