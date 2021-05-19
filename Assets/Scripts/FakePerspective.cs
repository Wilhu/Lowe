using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePerspective : MonoBehaviour
{
		//Cached References
	[SerializeField] public float horizontalTilt = 0f;
	[SerializeField] public float verticalTilt = 0f;
		//Variables
  float pointX, pointY;
  Vector2 destinationPosition;
  Vector2 currentPosition;

  private void Start()
  {
    pointX = horizontalTilt;
    pointY = verticalTilt;
    currentPosition = new Vector2(horizontalTilt, verticalTilt);
    destinationPosition = new Vector2(currentPosition.x, currentPosition.y);
  }
    void Update()
  {
    
    currentPosition = Vector2.Lerp(currentPosition, destinationPosition, 0.01f);
    horizontalTilt = currentPosition.x;
    verticalTilt = currentPosition.y; 

    if (Input.GetButton("Fire1"))
    {
      Vector3 mousePos = Input.mousePosition;
      {
        pointX = ((mousePos.x/Screen.width - 0.5f) * 4);
        pointY = ((mousePos.y/Screen.height - 0.5f) * 6 + 0.2f);
        destinationPosition = new Vector2(-pointX, -pointY);
      }
    } 
  }
}
