using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager i;
    private void Awake()
    {
        if (i == null)
        {
            i = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool isDefensePhase = false;
    public bool isEnemyTurn = false;

    public Outcome GenerateOutcome(Spell spell)
    {
        Outcome outcome = new Outcome();
        foreach (EffectData effectData in spell.rootEffect)
        {
            effectData.Effect(outcome);
        }
        foreach (EffectData effectData in spell.affixEffects)
        {
            effectData.Effect(outcome);
        }
        return outcome;
    }
    
    public void ResolveOutcomes(Outcome attackOutcome, Outcome defenseOutcome)
    {
        
    }
}
