using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : Character
{
    public int numCardDraws = 1;
    public TextMeshProUGUI healthDisplay;
    public Spell spell;
    public List<RootData> hand;
    
    public int initialHealth;
    
    public int health;

    private void Start()
    {
        hand = DrawCards(initialHand);
        discards = new List<RootData>();
        health = initialHealth;
        healthDisplay.text = "Enemy: " + health;
    }

    public override void ModifyHealth(int change)
    {
        health += change;
        healthDisplay.text = "Enemy: " + health;
    }

    public void SelectCards()
    {
        hand.AddRange(DrawCards(numCardDraws));
        int numPlays = Random.Range(1, Math.Max(hand.Count,3));
        for (int i = 0; i < numPlays; i++)
        {
            int selectionIndex = Random.Range(0, hand.Count-1);
            RootData selection = hand[selectionIndex];
            discards.Add(selection);
            hand.RemoveAt(selectionIndex);
            spell.AddCard(selection);
        }
    }
}
