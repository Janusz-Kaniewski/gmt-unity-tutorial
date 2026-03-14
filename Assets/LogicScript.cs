using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public int highScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverScreen;
    private BirdScript birdScript;
    private bool isHighScoreSaved = false;

    private AudioSource audio;
    public AudioClip getPointSound;

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = $"Score: {playerScore.ToString()}";
        audio.PlayOneShot(getPointSound);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToTileScreen()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        audio = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("highscore"))
        {
            highScore = PlayerPrefs.GetInt("highscore");
            highScoreText.text = $"High score: {highScore}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!birdScript.isBirdAlive && playerScore > highScore && !isHighScoreSaved)
        {
            PlayerPrefs.SetInt("highscore", playerScore);
            PlayerPrefs.Save();
            isHighScoreSaved = true;
        }
    }
}
