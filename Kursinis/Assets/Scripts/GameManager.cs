using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    private int score = 0;
    private int lives = 4;
    public bool shake;
    public bool bossDefeated = false;
    private int YLocation = (int)(Screen.height * 0.5);
    private int XLocation = (int)(Screen.width * 0.2);


    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text livesText;

    void Update()
    {
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void ChangeScore(int difference)
    {
        score += difference;
    }


    public void SetScore(int number)
    {
        score = number;
    }

    public void UpdateLives()
    {
        if (lives < 1)
        {
            lives = 0;
            livesText.text = "Lives: " + lives;
            shake = false;
        }
        else
        {
            livesText.text = "Lives: " + lives;
        }
    }

    public void ChangeLives(float currentLives)
    {
        lives = (int) currentLives;
        
    }

    public int GetLives()
    {
        return lives;
    }

    void OnGUI()
    {
        if (lives <= 0 && !bossDefeated)
        {
            
            GUIStyle style = new GUIStyle();
            style.fontSize = 35;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(XLocation, YLocation, 300, 30), "Game over. Press R to play again. ", style);
        }
        if (bossDefeated)
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 35;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(Screen.width * 0.4f, YLocation, 300, 30), "You won!", style);
        }
    }
}
