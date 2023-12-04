using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> Targets;

    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    private int score;
    public TextMeshProUGUI gameOverText;
    public bool gameActive;
    public Button gameOverButton;
    public GameObject titleScreen;


    public void startGame(int difficulty)
    {
        spawnRate /= difficulty;
        gameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        updateScore(0);
        titleScreen.SetActive(false);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }


    IEnumerator SpawnTarget()
    {
        while (gameActive) { 
            //wait 1 second
            yield return new WaitForSeconds(spawnRate);
            //pick a random number in index between 0 and number of prefabs
            int index = Random.Range(0, Targets.Count);
            //spawn prefab at index
            Instantiate(Targets[index]);



        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverButton.gameObject.SetActive(true);
        gameActive = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
