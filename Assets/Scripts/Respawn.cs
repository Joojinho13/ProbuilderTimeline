using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnValue;

    void Update()
    {
        if(player.transform.position.y < spawnValue)
        {
            player.GetComponent<CharacterControllerScript>().enabled = false;
           player.transform.position = spawnPoint.position;
            player.GetComponent<CharacterControllerScript>().enabled = true;

           Debug.Log("respawnou");
        }
    }

    
}
