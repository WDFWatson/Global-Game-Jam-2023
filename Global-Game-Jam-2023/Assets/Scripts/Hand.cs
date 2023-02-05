using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Card cardPrefab;
    
    public Spell playerSpell;
    
    public float handTopHeight = -2f;
    [SerializeField] private float cardSlotWidth;

    public List<Card> cards;

    public List<Card> playedCards;
    // Start is called before the first frame update
    void Awake()
    {
        UpdateHandOrder();
    }

    // Update is called once per frame

    public void UpdateHandOrder()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            float horizontalPosition = cardSlotWidth * (i + 0.5f - cards.Count/2f);
            cards[i].originalPosition = new Vector2(horizontalPosition, -5);
            cards[i].transform.position = cards[i].originalPosition;
        }
    }

    public void AddCards(List<RootData> newRoots)
    {
        foreach (var newRoot in newRoots)
        {
            var newCard = Instantiate(cardPrefab) as Card;
            newCard.root = newRoot;
            cards.Add(newCard);
            
        }
        UpdateHandOrder();
    }

    public void ReturnPlayedCards()
    {
        foreach (Card card  in playedCards)
        {
            card.gameObject.SetActive(true);
        }
        cards.AddRange(playedCards);
        playedCards.Clear();
        UpdateHandOrder();
    }
    
    
}
