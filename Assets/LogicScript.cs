using UnityEngine;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public TextMeshProUGUI scoreText;

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = $"Score: {playerScore.ToString()}";
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
