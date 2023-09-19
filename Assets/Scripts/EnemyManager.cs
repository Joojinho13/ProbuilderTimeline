using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{   
    public GameObject Perseguido;
    public NavMeshAgent Perseguidor;

    public int Vidas = 10;

    void Start()
    {
        Perseguidor = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Vidas < 1)
        {
            Destroy (this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Perseguidor.destination = Perseguido.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
       if (Perseguidor.remainingDistance < 1 && Perseguidor.hasPath)
        {
            other.GetComponent<CharacterControllerScript>().Vidas -= 1;
        } 
    }
}