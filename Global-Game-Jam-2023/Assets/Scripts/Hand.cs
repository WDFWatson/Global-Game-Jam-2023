using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float handTopHeight = -2f;
    [SerializeField] private float cardSlotWidth;

    public List<Card> cards;
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
    
}
