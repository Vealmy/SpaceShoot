//#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    
    public float boltspeed = 7f;
   
    void Start()
    {
       
       
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = Vector3 .forward * boltspeed;

    }
    

}
//#endif
