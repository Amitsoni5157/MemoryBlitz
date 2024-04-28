using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private List<Card> selectedCards = new List<Card>();
   
    public ScoreManager scoreManager;

    private DateTime _lastMatchTime;

    private float _comboSecondThreshold = 1;
    private int _currentCombo = 0;

    public GameModes CurrentGameMode = GameModes.TwoByTwo;

    void Awake()
    {
        Instance = this;
    }

    public void OnCardClicked(Card card)
    {
        if (!selectedCards.Contains(card))
        {
            selectedCards.Add(card);
            if (selectedCards.Count == 2)
            {
                StartCoroutine(CheckMatchAsync());
            }
        }
    }

    private IEnumerator CheckMatchAsync()
    {
        
        for (int i = 0; i < selectedCards.Count - 1; i += 2)
        {
            if (selectedCards[i].cardImage.name == selectedCards[i + 1].cardImage.name)
            {
                _currentCombo++;

                if (_currentCombo > 1) 
                {
                    TimeSpan diff = DateTime.Now.Subtract(_lastMatchTime);
                    Debug.Log(diff.Seconds);
                    if (diff.Seconds > _comboSecondThreshold) _currentCombo = 1;
                }
                
                selectedCards[i].Match();
                selectedCards[i + 1].Match();
                selectedCards.Clear();
                scoreManager.UpdateScore(_currentCombo);
                _lastMatchTime = DateTime.Now;
            }
            else
            {
                _currentCombo = 0;//reset combo
                StartCoroutine(FlipCardsBack());
            }
        }
        yield return null;
    }

    IEnumerator FlipCardsBack()
    {
        Card onecard = selectedCards[0];
        Card twocard = selectedCards[1];
        selectedCards.Clear();
        yield return new WaitForSeconds(0.5f); 
        onecard.Flip();
        twocard.Flip();
    }

    // Method to reset score and pairs matched
    public void ResetGame()
    {
        scoreManager.ResetScore();
    }

}
