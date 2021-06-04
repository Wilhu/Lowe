using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
		//Cached References
	[SerializeField] public float parallaxMultiplier = 1f; 
	[SerializeField] public float parallaxRelativeVertical = 0f; 
	[SerializeField] public bool usePerspective = false;
    [SerializeField] public bool useRelativeStartPosition = false;

	public Camera cam; 
	public FakePerspective fakePerspective;

		//Variables
	public float startX, startY, camRelativePos, perspectiveX, perspectiveY;
	
    void Start()
    {
        CreatePerspective();
    }

    public virtual void CreatePerspective()
    {
        cam = Camera.main;
        
        if (useRelativeStartPosition)
        {
        startX = transform.position.x + (cam.transform.position.x   *  (1 - parallaxMultiplier));
        startY = transform.position.y + (cam.transform.position.y   * (1 - (parallaxMultiplier   * parallaxRelativeVertical)));
        }
        else
        {
            startX = transform.position.x;
            startY = transform.position.y;
        }
        fakePerspective = FindObjectOfType<FakePerspective>();
    }

    void Update()
    {
        UpdatePerspective();
    }

    public virtual void UpdatePerspective()
    {
        if (usePerspective)
        {
            perspectiveX = fakePerspective.horizontalTilt;
            perspectiveY = fakePerspective.verticalTilt;
        }
        else
        {
            perspectiveX = 0f;
            perspectiveY = 0f;
        }

        camRelativePos =    (cam.transform.position.x   * (1 - parallaxMultiplier));
        float dist =        (cam.transform.position.x   *  parallaxMultiplier                               +   (perspectiveX     * parallaxMultiplier));
        float height =      (cam.transform.position.y   * (parallaxMultiplier   * parallaxRelativeVertical) +   (perspectiveY     * parallaxMultiplier));
        transform.position = new Vector3(
            startX + dist, 
            startY + height, 
            transform.position.z);
    }
}
