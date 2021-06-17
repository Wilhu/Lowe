using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextSceneOnTrigger : MonoBehaviour
{
    public GameObject FadeBlack;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            StartCoroutine(FadeAfterTime(0.5f));
        }
    }

    private IEnumerator FadeAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(FadeBlack.GetComponent<FadeBlack>().ScreenFadeBlack());
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //AudioSource.PlayClipAtPoint(SoundManager.respawnJiggle, new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z));
    }


}
