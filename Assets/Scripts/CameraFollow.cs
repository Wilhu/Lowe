using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    public float SmoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position,target.position, ref velocity, SmoothTime);
    }

}
