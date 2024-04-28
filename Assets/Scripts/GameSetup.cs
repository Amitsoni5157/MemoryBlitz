using UnityEngine;
using System.Collections.Generic;

public class GameSetup : MonoBehaviour
{
    public Sprite[] cardImages;

    private List<UniqueImageInfo> uniqueImages;

    public Sprite GetImageById(int id) 
    {
        return cardImages[id];
    }

    public void SetupCards()
    {
        Card[] cards = FindObjectsOfType<Card>();
        int index = 0;

        int numberOfPairs = cards.Length / 2;

        
        uniqueImages = new List<UniqueImageInfo>();

        
        for (int i = 0; i < numberOfPairs; i++)
        {
            
            int prevIndex = index;
            do
            {
                index = Random.Range(0, cardImages.Length);
            } while (index == prevIndex);

           
            uniqueImages.Add(new UniqueImageInfo {sprite=cardImages[index], imageId = index });
            uniqueImages.Add(new UniqueImageInfo { sprite = cardImages[index], imageId = index });

        }
        ShuffleList(uniqueImages);

        for (int i = 0; i < uniqueImages.Count; i++)
        {
            cards[i].SetImage(uniqueImages[i].sprite);
            cards[i].cardId = i;
            cards[i].cardImageId = uniqueImages[i].imageId;
        }
    }




    
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


public class UniqueImageInfo 
{
    public Sprite sprite;
    public int imageId;
}

