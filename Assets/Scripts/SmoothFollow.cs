using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{

    [SerializeField] Transform Target;
    public Vector3 Offset;
    // change this value to get desired smoothness
    //[SerializeField] float smoothTime = 0.3f;
    [SerializeField] float lerpFactor = 0.1f;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        transform.parent = null;
        Offset = transform.position - Target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = Target.position + Offset;
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpFactor);
    }
}
