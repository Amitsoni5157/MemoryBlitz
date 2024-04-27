using UnityEngine;
using UnityEngine.UI;

public class CardLayoutController : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform container;
    public Vector2Int layoutSize;
    public float spacing = 10f; // Adjust as needed

    void GenerateCards()
    {
        float containerWidth = container.GetComponent<RectTransform>().rect.width;
        float containerHeight = container.GetComponent<RectTransform>().rect.height;

        // Calculate card width and height considering spacing
        float cardWidth = (containerWidth - spacing * (layoutSize.x - 1)) / layoutSize.x;
        float cardHeight = (containerHeight - spacing * (layoutSize.y - 1)) / layoutSize.y;

        // Calculate starting position from top center
        float startX = -containerWidth / 2 + cardWidth / 2; // Calculate starting X position from left edge of the container
        float startY = containerHeight / 2 - cardHeight / 2; // Calculate starting Y position from top edge of the container

        for (int row = 0; row < layoutSize.y; row++)
        {
            for (int col = 0; col < layoutSize.x; col++)
            {
                GameObject card = Instantiate(cardPrefab, container);
                RectTransform cardRectTransform = card.GetComponent<RectTransform>();

                // Calculate position for the current card
                float xPos = startX + col * (cardWidth + spacing); // Adjust X position based on column and spacing
                float yPos = startY - row * (cardHeight + spacing); // Adjust Y position based on row and spacing

                // Set position and size for the card
                cardRectTransform.localPosition = new Vector3(xPos, yPos, 0f); // Set position
                cardRectTransform.sizeDelta = new Vector2(cardWidth, cardHeight); // Set size
            }
        }
    }

    // Method to change the layout size
    public void ChangeLayoutSize(Vector2Int newSize)
    {
        layoutSize = newSize;
        GenerateCards(); // Regenerate cards with the new layout size
    }
}
