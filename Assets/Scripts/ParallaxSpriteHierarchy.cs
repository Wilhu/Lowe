using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxSpriteHierarchy : ParallaxSprite
{
    public override void GetSpriteWidth()
    {
        length = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

}
