using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICharacter
{
    public Spell spell;
    public List<RootData> deck;
    public List<RootData> hand;
    
    public int initialHealth;
    
    public int health;

    public void ModifyHealth(int change)
    {
        health += change;
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
