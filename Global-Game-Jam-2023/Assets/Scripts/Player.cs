using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    public TextMeshProUGUI healthDisplay;

    public List<RootData> deck;
    
    public int health;

    public int initialHealth;

    public Spell spell;

    public Hand hand;

    private void Start()
    {
        health = initialHealth;
        healthDisplay.text = "You: " + health;
    }

    public void ModifyHealth(int change)
    {
        health += change;
        healthDisplay.text = "You: " + health;
    }
    
    
}
