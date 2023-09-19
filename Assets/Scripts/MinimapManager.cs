using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour
{
    public Transform Player;
    public Vector3 CalculedPositon;
    
    void Start()
    {
        
    }

    void Update()
    {
        CalculedPositon = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
        transform.position = CalculedPositon;
    }
}
