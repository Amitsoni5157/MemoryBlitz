using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText; 

    // Method to update score and check for additional points for consecutive pairs matched
    public void UpdateScore(int matches)
    {
        score += matches * 10; 
        scoreText.text = "Score: " + score.ToString(); 

        SaveAndLoad.Instance.SaveGame();
    }
    // Method to set the current score
    public void SetCurrentScore(int _score)
    {
        score = _score;
        scoreText.text = "Score: " + score.ToString(); 
    }

    // Method to get the current score
    public int GetCurrentScore()
    {
        scoreText.text = "Score: " + score.ToString(); 
        return score;
    }
    // Method to reset score and pairs matched
    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: 0"; 
    }
}
