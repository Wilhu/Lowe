using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeBlack : MonoBehaviour
{
    public GameObject BlackScreen;

    public IEnumerator ScreenFadeBlack(bool fadeToBlack = true, int fadeSpeed = 3)
    {
        Color objectColor = BlackScreen.GetComponent<Image>().color;
        float fadeAmount;

        if(fadeToBlack)
        {
            while(BlackScreen.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r,objectColor.g,objectColor.b, fadeAmount);
                BlackScreen.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else
        {
            while(BlackScreen.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r,objectColor.g,objectColor.b, fadeAmount);
                BlackScreen.GetComponent<Image>().color = objectColor;
                yield return null;
            }
            //yield return new WaitForSeconds(2f);
        }
    }
}

