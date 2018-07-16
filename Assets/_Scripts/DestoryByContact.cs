//#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playExplosion;
    public int scoreValue;
    private GameController gameController;

	// Use this for initialization
	void Start () {
        GameObject go = GameObject.FindWithTag("GameController");
        if (go != null)
            gameController = go.GetComponent<GameController>();
        else
            Debug.Log("找不到tag为GameController的对象");
            if (gameController == null)
            Debug.Log("找不到脚本GameController.cs");
                }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other) {
        //print(other.gameObject);

        if (other.tag != "Boundary")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.AddScore(scoreValue);
            if (other.tag == "Player")
            {
                Instantiate(playExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            }
        }
    }
}
//