using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardLayoutController : MonoBehaviour
{
    [SerializeField]
    private GameObject _cardPrefab;
    [SerializeField]
    private Transform _container;
    [SerializeField]
    private Vector2Int _layoutSize;
    [SerializeField]
    private float _spacing = 10f;
    private List<Card> allCards = new List<Card>();

    void GenerateCards()
    {
        float containerWidth = _container.GetComponent<RectTransform>().rect.width;
        float containerHeight = _container.GetComponent<RectTransform>().rect.height;

        
        float cardWidth = (containerWidth - _spacing * (_layoutSize.x - 1)) / _layoutSize.x;
        float cardHeight = (containerHeight - _spacing * (_layoutSize.y - 1)) / _layoutSize.y;

        // Calculate starting position from top center
        float startX = -containerWidth / 2 + cardWidth / 2; 
        float startY = containerHeight / 2 - cardHeight / 2; 

        for (int row = 0; row < _layoutSize.y; row++)
        {
            for (int col = 0; col < _layoutSize.x; col++)
            {
                GameObject card = Instantiate(_cardPrefab, _container);
                allCards.Add(card.GetComponent<Card>());
                RectTransform cardRectTransform = card.GetComponent<RectTransform>();

                // Calculate position for the current card
                float xPos = startX + col * (cardWidth + _spacing); 
                float yPos = startY - row * (cardHeight + _spacing); 

                // Set position and size for the card
                cardRectTransform.localPosition = new Vector3(xPos, yPos, 0f); 
                cardRectTransform.sizeDelta = new Vector2(cardWidth, cardHeight); 
            }
        }
    }

    public List<Card> GetAllCards() 
    {
        return allCards;
    }

    // Method to change the layout size
    public void ChangeLayoutSize(Vector2Int newSize)
    {
        _layoutSize = newSize;
        GenerateCards(); 
    }
}
