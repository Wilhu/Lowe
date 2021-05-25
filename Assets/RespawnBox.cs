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
    public int ClosestSpawn = 0;
    public int NextSpawn;
    void Start()
    {
        respawnpositions = new List<float>();
        respawns = GameObject.FindGameObjectsWithTag("respawn");
        foreach(GameObject respawn in respawns)
        {
            respawnpositions.Add(respawn.transform.position.x);

            for(int i = 0; i<respawns.Length;i++)
            {
               /* if(respawn.transform.position.x<reverse[i].transform.position.x)
                {

                } */
            }
        }

        reverse = Enumerable.Reverse(respawns).ToArray();
        for(int i = 0; i<respawnpositions.Count;i++)
        {
            Debug.Log(respawnpositions[i]);
        }  
    }
    void Update()
    {
        transform.position = new Vector3(player.position.x,transform.position.y,0f);
        /*if(NextSpawn >= respawnpositions.Count-1)
        {
            NextSpawn = respawnpositions.Count-1;
        }
        else if(NextSpawn < respawnpositions.Count)
        {
            NextSpawn = ClosestSpawn + 1;
        } */
        if(player.transform.position.x > respawnpositions[ClosestSpawn] )
        {
            ClosestSpawn++;
            Debug.Log("++");
        }
        if(player.transform.position.x < respawnpositions[ClosestSpawn])
        {
            ClosestSpawn--;
            Debug.Log(respawnpositions.Count-1);
        }
        if(ClosestSpawn<0)
        {
            ClosestSpawn = 0;
            Debug.Log("nolla");
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player")
        {
            player.position = respawns[ClosestSpawn].transform.position;
        }
    }
}
