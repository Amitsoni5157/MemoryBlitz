using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CardLayoutController cardLayoutController;    
    public GameObject ModePanel;


    // Method to change the mode to 2x2
    public void SetMode2x2()
    {
        cardLayoutController.ChangeLayoutSize(new Vector2Int(2, 2));
        ToogleModePanel(false);
    }

    // Method to change the mode to 2x3
    public void SetMode2x3()
    {
        cardLayoutController.ChangeLayoutSize(new Vector2Int(2, 3));
        ToogleModePanel(false);
    }

    // Method to change the mode to 5x6
    public void SetMode5x6()
    {
        cardLayoutController.ChangeLayoutSize(new Vector2Int(5, 6));
        ToogleModePanel(false);
    }

    private void ToogleModePanel(bool value)
    {
        ModePanel.SetActive(value);
    }
}
