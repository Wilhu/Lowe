using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RespawnBox : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject cameraObject;
    private GameObject[] respawns;
    public GameObject[] reverse;
    private List<float> respawnpositions;
    //private List<float> sortedRespawnPositions;
    public int ClosestSpawn = 0;
    public int slot = 0;
    PlayerHealth m_health;
    playerMovement playerMovement;
    CameraFollow cameraFollow;
    public int fallDamage = 1;
    public GameObject FadeBlack;
    void Start()
    {
        respawnpositions = new List<float>();
        respawns = GameObject.FindGameObjectsWithTag("respawn");
        m_health = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<playerMovement>();
        cameraFollow = cameraObject.GetComponent<CameraFollow>();


       /* foreach(GameObject respawn in respawns)
        {
            respawnpositions.Add(respawn.transform.position.x);

            for(int i = 0; i<respawns.Length;i++)
            {
                if(respawn.transform.position.x<reverse[i].transform.position.x)
                {

                } 
            } 
        }*/

        reverse = Enumerable.Reverse(respawns).ToArray();
        for(int i = 0; i<respawnpositions.Count;i++)
        {
            Debug.Log(respawns[i]);
        }  
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,transform.position.y,0f);
        if(reverse[slot].transform.position.x < player.transform.position.x)
        {
            ClosestSpawn = slot;
            if(slot<reverse.Length-1)
            {
                slot++;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player")
        {
            SoundManager.PlaySound("pit_fall");
            AudioSource.PlayClipAtPoint(SoundManager.pitFall, new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z));
            StartCoroutine(FadeBlack.GetComponent<FadeBlack>().ScreenFadeBlack());
            //player.transform.position = reverse[ClosestSpawn].transform.position;
            //m_health.pHealth = m_health.pHealth-fallDamage;
            //StartCoroutine(playerMovement.DamageFlash());
            //StartCoroutine(FadeBlack.GetComponent<FadeBlack>().ScreenFadeBlack(false));
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag =="Player")
        {
            player.transform.position = reverse[ClosestSpawn].transform.position;
            cameraFollow.ResetCamera();
            m_health.pHealth = m_health.pHealth-fallDamage;
            //SoundManager.PlaySound("respawn_jiggle");
            //AudioSource.PlayClipAtPoint(SoundManager.respawnJiggle, new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z));
            StartCoroutine(playerMovement.DamageFlash());
            StartCoroutine(FadeAfterTime(0.5f));
            //StartCoroutine(FadeBlack.GetComponent<FadeBlack>().ScreenFadeBlack(false));
        }
        
    }

    IEnumerator FadeAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(FadeBlack.GetComponent<FadeBlack>().ScreenFadeBlack(false));
        AudioSource.PlayClipAtPoint(SoundManager.respawnJiggle, new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z));
    }

}
