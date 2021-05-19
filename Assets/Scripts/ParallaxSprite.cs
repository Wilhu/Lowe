using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxSprite : Parallax
{
		//Cached References
	[SerializeField] public bool looping = false;

		//Variables
	public float length;

    public override void CreatePerspective()
    {
        base.CreatePerspective();
        GetSpriteWidth();
    }

    public virtual void GetSpriteWidth()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    public override void UpdatePerspective()
    {
        base.UpdatePerspective();
		if (looping)
		{
			if (camRelativePos > startX + length) startX += length;
			else if (camRelativePos < startX - length) startX -= length;
		}
    }
}
