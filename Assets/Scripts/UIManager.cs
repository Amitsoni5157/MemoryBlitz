using UnityEngine;
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
    }

    // Method to change the mode to 2x3
    public void SetMode2x3()
    {
        cardLayoutController.ChangeLayoutSize(new Vector2Int(2, 3));
        ToogleModePanel(false);
        gameSetup.SetupCards(/*4*/);
    }

    // Method to change the mode to 5x6
    public void SetMode5x6()
    {
        cardLayoutController.ChangeLayoutSize(new Vector2Int(5, 6));
        ToogleModePanel(false);
        gameSetup.SetupCards(/*4*/);
    }

    private void ToogleModePanel(bool value)
    {
        ModePanel.SetActive(value);
    }
}
