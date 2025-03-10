using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public int score = 0;
    public Text scoreText; 
    public GUISkin layout;              
    GameObject theBall;                 
    public static int PlayerScore1 = 0; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene("InicialScene");
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.skin.label.normal.textColor = Color.white;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(Screen.width / 3 - 215 - 18, 180, 500, 200), "YOUR SCORE: " + GameManager.PlayerScore1);
    }
}