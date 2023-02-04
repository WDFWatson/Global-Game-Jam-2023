using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICharacter
{
    public int initialHealth;
    
    public int health;

    public void ModifyHealth(int change)
    {
        health += change;
    }
}
