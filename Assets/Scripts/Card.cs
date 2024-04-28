using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int cardId;
    public Sprite cardImage; // Image for this card
    public Sprite cardBackImage;  // Image for the back face of the card

    public bool isFlipped = false;
    public bool isMatched = false; // New field to track whether the card is matched
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
           /* m_FlipAnimation.Play("FlipAnim");
            Invoke("GetFrontSprite", 0.2f);*/
           // Flip();
             GetComponent<Image>().sprite = cardImage; // Show front image
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

    public void Match()
    {
        //  Debug.Log("Match The Card");
        this.gameObject.SetActive(false);
        isMatched = true; // Mark the card as matched
    }
    private void ShowBack()
    {
        m_FlipAnimation.Play("FlipAnim");
        GetComponent<Image>().sprite = cardBackImage; // Show back image
    }
}
