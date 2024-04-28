using UnityEngine;
using System.Collections.Generic;

public class GameSetup : MonoBehaviour
{
    public Sprite[] cardImages; // Array of card images

    public List<Sprite> uniqueImages;
    public void SetupCards()
    {
        Card[] cards = FindObjectsOfType<Card>();
        int index = 0;

        int numberOfPairs = cards.Length / 2;

        // Create a list to store the unique images for this set of cards
        uniqueImages = new List<Sprite>();

        // Add pairs of unique images to the list
        for (int i = 0; i < numberOfPairs; i++)
        {
            // Generate a random index that's different from the previous one
            int prevIndex = index;
            do
            {
                index = Random.Range(0, cardImages.Length);
            } while (index == prevIndex);

            // Add each image twice for matching pairs
            uniqueImages.Add(cardImages[index]);
            uniqueImages.Add(cardImages[index]);

        }
        ShuffleList(uniqueImages);

        for (int i = 0; i < uniqueImages.Count; i++)
        {
            cards[i].SetImage(uniqueImages[i]);
            cards[i].cardId = i;
        }
    }


    // Shuffle the elements of a list
    void ShuffleList<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
