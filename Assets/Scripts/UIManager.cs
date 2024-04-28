using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CardLayoutController cardLayoutController;
    public GameSetup gameSetup;
    public GameObject ModePanel;


    // Method to change the mode to 2x2
    public void SetMode2x2()
    {
        cardLayoutController.ChangeLayoutSize(new Vector2Int(2, 2));
        ToogleModePanel(false);
        gameSetup.SetupCards(/*4*/);
        GameManager.Instance.CurrentGameMode = GameModes.TwoByTwo;
        SaveAndLoad.Instance.DeleteGameSavedData();
    }

    // Method to change the mode to 2x3
    public void SetMode2x3()
    {
        cardLayoutController.ChangeLayoutSize(new Vector2Int(2, 3));
        ToogleModePanel(false);
        gameSetup.SetupCards(/*4*/);
        GameManager.Instance.CurrentGameMode = GameModes.TwoByThree;
        SaveAndLoad.Instance.DeleteGameSavedData();
    }

    // Method to change the mode to 5x6
    public void SetMode5x6()
    {
        cardLayoutController.ChangeLayoutSize(new Vector2Int(5, 6));
        ToogleModePanel(false);
        gameSetup.SetupCards(/*4*/);
        GameManager.Instance.CurrentGameMode = GameModes.FiveBySix;
        SaveAndLoad.Instance.DeleteGameSavedData();
    }

    private void ToogleModePanel(bool value)
    {
        ModePanel.SetActive(value);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
