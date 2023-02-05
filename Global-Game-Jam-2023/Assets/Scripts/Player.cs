using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : Character
{

    public TextMeshProUGUI healthDisplay;

    [SerializeField] private int numCardDraws = 1;
    
    public int health;

    public int initialHealth;

    public Spell spell;

    public Hand hand;

    private void Start()
    {
        deck = new List<RootData>(PlayerManager.i.deck);
        hand.AddCards(DrawCards(initialHand));
        discards = new List<RootData>();
        health = initialHealth;
        healthDisplay.text = "You: " + health;
    }

    public override void ModifyHealth(int change)
    {
        health += change;
        healthDisplay.text = "You: " + health;
    }

    public void StartTurn()
    {
        foreach (var card in hand.playedCards)
        {
            discards.Add(card.root);
            Destroy(card.gameObject);
        }
        hand.playedCards.Clear();
        
        var draws = DrawCards(numCardDraws);
        hand.AddCards(draws);
    }
    
    
    
    
}
