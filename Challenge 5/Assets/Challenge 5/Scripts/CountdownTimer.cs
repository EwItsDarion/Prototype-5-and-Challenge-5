using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public Text countdownText;
    private GameManagerX gameManager;


    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerX>();
    }
    private void Update()
    {

        if (timeRemaining > 0)
        {

            timeRemaining -= Time.deltaTime;


            int displayTime = Mathf.RoundToInt(timeRemaining);

            countdownText.text = "Time: " + displayTime.ToString();


            if (timeRemaining <= 0)
            {

                gameManager.GameOver();
            }
        }
    }


}