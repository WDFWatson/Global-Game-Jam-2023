using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour, ICharacter
{
    public TextMeshProUGUI healthDisplay;
    public Spell spell;
    public List<RootData> deck;
    public List<RootData> hand;
    
    public int initialHealth;
    
    public int health;

    private void Start()
    {
        health = initialHealth;
        healthDisplay.text = "Enemy: " + health;
    }

    public void ModifyHealth(int change)
    {
        health += change;
        healthDisplay.text = "Enemy: " + health;
    }

    public void SelectCards()
    {
        hand = new List<RootData>(deck);
        int numPlays = Random.Range(1, hand.Count);
        for (int i = 0; i < numPlays; i++)
        {
            int selectionIndex = Random.Range(0, hand.Count);
            RootData selection = hand[selectionIndex];
            hand.RemoveAt(selectionIndex);
            spell.AddCard(selection);
        }
        
    }
}
