using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText; // Reference to UI text element to display score

    // Method to update score and check for additional points for consecutive pairs matched
    public void UpdateScore(int matches)
    {
        score += matches * 5; // Add 5 points for each pair matched
        score += matches > 1 ? 10 : 0; // Additional 5 points for consecutive pair matched
        scoreText.text = "Score: " + score.ToString(); // Update UI score text
    }
    // Method to set the current score
    public void SetCurrentScore(int _score)
    {
        score = _score;
        // You might also want to update the UI to display the new score here
    }

    // Method to get the current score
    public int GetCurrentScore()
    {
        scoreText.text = "Score: " + score.ToString(); // Update UI score text
        return score;
    }
    // Method to reset score and pairs matched
    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: 0"; // Reset UI score text
    }
}
