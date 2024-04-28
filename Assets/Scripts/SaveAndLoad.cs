using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public static SaveAndLoad Instance;
    [SerializeField]private GameObject _loadButton;

    [SerializeField]
    private CardLayoutController _cardLayout;

    [SerializeField]
    private GameSetup _gameSetup;

    void Awake()
    {
        Instance = this;
        string filePath = Path.Combine(Application.persistentDataPath, "gamestate.json");
        
        _loadButton.SetActive(File.Exists(filePath));
    }

    public void SaveGame()
    {
        List<Card> allCards = _cardLayout.GetAllCards();

        GameState tempGameState = new GameState();
        tempGameState.gameMode = GameManager.Instance.CurrentGameMode;
        tempGameState.score = GameManager.Instance.scoreManager.GetCurrentScore();
        foreach (var card in allCards)
        {
            CardState tempCardState = new CardState();
            tempCardState.cardId = card.cardId;
            tempCardState.isFlipped = card.isFlipped;
            tempCardState.isMatched = card.isMatched;
            tempCardState.imageId = card.cardImageId;

            tempGameState.cardStates.Add(tempCardState);

        }

        string json = JsonUtility.ToJson(tempGameState);
        string filePath = Path.Combine(Application.persistentDataPath, "gamestate.json");
        File.WriteAllText(filePath, json);
    }

    public void DeleteGameSavedData() 
    {
        string filePath = Path.Combine(Application.persistentDataPath, "gamestate.json");
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    public void LoadGame()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "gamestate.json");
        if (File.Exists(filePath))
        {
            string savedData = File.ReadAllText(filePath);
            GameState savedGameState = JsonUtility.FromJson<GameState>(savedData);

            switch (savedGameState.gameMode) 
            {
                case GameModes.TwoByTwo:
                    _cardLayout.ChangeLayoutSize(new Vector2Int(2, 2));
                    break;

                case GameModes.TwoByThree:
                    _cardLayout.ChangeLayoutSize(new Vector2Int(2, 3));
                    break;

                case GameModes.FiveBySix:
                    _cardLayout.ChangeLayoutSize(new Vector2Int(5,6));
                    break;
            }

            GameManager.Instance.CurrentGameMode = savedGameState.gameMode;

            List<Card> allCards = _cardLayout.GetAllCards();

            for (int i = 0; i < savedGameState.cardStates.Count; i++)
            {
                allCards[i].isFlipped = savedGameState.cardStates[i].isFlipped;
                allCards[i].isMatched = savedGameState.cardStates[i].isMatched;
                allCards[i].cardId = savedGameState.cardStates[i].cardId;
                allCards[i].cardImageId = savedGameState.cardStates[i].imageId;

                if (allCards[i].isMatched) allCards[i].HideCard();

                allCards[i].SetImage(_gameSetup.GetImageById(allCards[i].cardImageId));
            }
            GameManager.Instance.scoreManager.SetCurrentScore(savedGameState.score);

        }
    }
}

[System.Serializable]
public class GameState
{
    public int score;
    public GameModes gameMode;
    public List<CardState> cardStates = new List<CardState>();
}

[System.Serializable]
public class CardState
{
    public int cardId;
    public bool isFlipped;
    public bool isMatched;
    public int imageId;
}

public enum GameModes 
{
    TwoByTwo,
    TwoByThree,
    FiveBySix
}