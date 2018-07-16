//#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System .Serializable]
public class Boundary
{
    public float xMin=-6.0f, xMax=6.0f, zMin=-4.0f, zMax=14.0f;
}

public class PlayerController : MonoBehaviour {

    public float fireRate = 0.5f;
    public GameObject shot;
    public Transform shotSpawn;
    private float nextFire=0f;
    public Boundary boundary;
    public float speed = 5f;
    public float tilt = 4.0f;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

	}
    void FixedUpdate() {
        float moveHorizonal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //用上面水平方向的（x轴）和垂直方向（z轴）输入一个Vector3变量，作为刚体速度；
        Vector3 movement = new Vector3(moveHorizonal, 0.0f, moveVertical);
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) { 
        rb.velocity = movement * speed;
            rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f, Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
        }
        rb.rotation = Quaternion.Euler(0, 0,  rb.velocity.x * -tilt);
	}
   
    


}
//#endif