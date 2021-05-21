using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RespawnBox : MonoBehaviour
{
    [SerializeField] Transform player;
    private GameObject[] respawns;
    private GameObject[] reverse;
    private List<float> respawnpositions;
    //private List<float> sortedRespawnPositions;
    private int ClosestSpawn = 0;
    void Start()
    {/*
        respawnpositions = new List<float>();
        respawns = GameObject.FindGameObjectsWithTag("respawn");
        foreach(GameObject respawn in respawns)
        {
            respawnpositions.Add(respawn.transform.position.x);

            for(int i = 0; i<respawns.Length;i++)
            {
                if(respawn.transform.position.x<reverse[i].transform.position.x)
                {

                }
            }
        }

        //reverse = Enumerable.Reverse(respawns).ToArray();
        for(int i = 0; i<reverse.Length;i++)
        {
            Debug.Log(reverse[i]);
        }  */
    }
    void Update()
    {
        transform.position = new Vector3(player.position.x,transform.position.y,0f);

      /*  if(player.transform.position.x > respawnpositions[ClosestSpawn+1])
        {
            
        } */
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player")
        {
            player.position = reverse[ClosestSpawn].transform.position;
        }
    }
}
