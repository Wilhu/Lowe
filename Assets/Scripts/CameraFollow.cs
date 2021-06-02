using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    public float SmoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        float dist = Vector3.Distance(transform.position, target.position);
        Debug.Log(dist);
        transform.position = Vector3.SmoothDamp(transform.position,target.position, ref velocity, SmoothTime);
        
    }

    public void ResetCamera()
    {
        this.transform.position = target.position;
    }

}
