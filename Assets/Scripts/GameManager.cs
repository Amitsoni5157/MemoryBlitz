using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private List<Card> selectedCards = new List<Card>();
    private bool isCheckingMatch; // Flag to prevent multiple coroutine instances

    void Awake()
    {
        Instance = this;
    }

    public void OnCardClicked(Card card)
    {
        if (!selectedCards.Contains(card))
        {
            selectedCards.Add(card);
            if (selectedCards.Count >= 2)
            {
                StartCoroutine(CheckMatchAsync());
            }
        }
    }

    private IEnumerator CheckMatchAsync()
    {
        if (isCheckingMatch)
            yield break;

        isCheckingMatch = true;

        yield return new WaitForSeconds(0.65f); // Adjust delay as needed

        List<Card> matchedCards = new List<Card>();

        // Check for matches between adjacent pairs
        for (int i = 0; i < selectedCards.Count - 1; i += 2)
        {
            if (selectedCards[i].cardImage == selectedCards[i + 1].cardImage)
            {
                matchedCards.Add(selectedCards[i]);
                matchedCards.Add(selectedCards[i + 1]);
            }
        }

        if (matchedCards.Count > 0)
        {
            foreach (var matchedCard in matchedCards)
            {
                matchedCard.Match();
                selectedCards.Remove(matchedCard);
            }
        }
        else
        {
            StartCoroutine(FlipCardsBack());
        }

        isCheckingMatch = false;
    }

    IEnumerator FlipCardsBack()
    {
        yield return new WaitForSeconds(0.5f); // Adjust delay as needed
        foreach (var card in selectedCards)
        {
            card.Flip();
        }
        selectedCards.Clear();
    }
}
