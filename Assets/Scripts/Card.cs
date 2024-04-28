using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int cardId;
    public Sprite cardImage;
    public Sprite cardBackImage; 
    public int cardImageId;

    public bool isFlipped = false;
    public bool isMatched = false; 
    private Animator m_FlipAnimation;

    private void Start()
    {
        m_FlipAnimation = GetComponent<Animator>();
        Invoke("ShowBack", 1.2f);//ShowBack();
    }
    public void SetImage(Sprite image)
    {
        GetComponent<Image>().sprite = image;
        cardImage = image;
    }

    public void OnClick()
    {
        if (!isFlipped && !isMatched) // Check if the card is not already flipped or matched
        {
            Invoke("GetFrontSprite", 0.2f);
            Flip();
            GameManager.Instance.OnCardClicked(this);
        }
    }

    public void GetFrontSprite()
    {
        GetComponent<Image>().sprite = cardImage; // Show front image
        CancelInvoke("GetFrontSprite");
    }

    public void Flip()
    {
        m_FlipAnimation.Play("FlipAnim");
        if (isFlipped)
        {           
            GetComponent<Image>().sprite = cardImage; // Show front image
        }
        else
            ShowBack(); // Show back image
    }

    public async void Match()
    {
        //  Debug.Log("Match The Card");
        isMatched = true; // Mark the card as matched
        await Task.Delay(500);
        this.gameObject.SetActive(false);
        
    }
    private void ShowBack()
    {
        m_FlipAnimation.Play("FlipAnim");
        GetComponent<Image>().sprite = cardBackImage; // Show back image
    }

    public void HideCard()
    {
        this.gameObject.SetActive(false);
    }


}
