using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCam : MonoBehaviour
{
    public GameObject MCamera;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVector = this.transform.position - MCamera.transform.position;

        transform.rotation = Quaternion.LookRotation(targetVector, Vector3.up);
    }
}
