//#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float WaveWait;
    public Text scoreText;
    public Text gameOverText;
    public Text RestartText;
    private bool restart;
    private bool gameOver;
    private int score;
   
    private Vector3 spawnPosition = Vector3.zero;
  
    private Quaternion spawnRotation;


	// Use this for initialization
	void Start () {
        gameOverText.text = "";
        RestartText.text = "";
        restart = false;
        gameOver = false;
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
	}

    void Update() {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
                
            }
        }
    }


    IEnumerator SpawnWaves() {
        
        yield return new WaitForSeconds(startWait);
        while (true) { for (int i = 0; i < hazardCount; i++)
            {
                if (gameOver) {
                    RestartText.text = "按【R】键重新开始";
                    restart = true;
                    break;
                }
                spawnPosition.x = Random.Range(-spawnValues.x, spawnValues.x);
                spawnPosition.z = spawnValues.z;
                spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(WaveWait);
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "得分:" + score;
    }
    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "游戏结束";
    }
}
//#endif