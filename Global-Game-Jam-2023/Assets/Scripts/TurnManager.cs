using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
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
        if (spell.rootEffect != null)
        {
            foreach (EffectData effectData in spell.rootEffect)
            {
                effectData.effect.DoEffect(outcome, effectData.effectValue);
            }
            foreach (EffectData effectData in spell.affixEffects)
            {
                effectData.effect.DoEffect(outcome, effectData.effectValue);
            }
        }
        
        return outcome;
    }
    
    public void ResolveSpells()
    {
        Spell attackSpell;
        Spell defenseSpell;
        bool isPlayerAttack = isDefensePhase && isEnemyTurn || !isDefensePhase && !isEnemyTurn;
        if (isPlayerAttack)
        {
            attackSpell = player.spell;
            defenseSpell = enemy.spell;
        }
        else
        {
            attackSpell = enemy.spell;
            defenseSpell = player.spell;
        }

        Outcome attackOutcome = GenerateOutcome(attackSpell);
        Outcome defenseOutcome = GenerateOutcome(defenseSpell);

        int damage = attackOutcome.attackDamage - defenseOutcome.defenseValue;
        if (damage < 0)
        {
            damage = 0;
        }

        if (isPlayerAttack)
        {
            enemy.ModifyHealth(-damage);
        }
        else
        {
            player.ModifyHealth(-damage);
        }
    }

    public void Proceed()
    {
        if (isDefensePhase)
        {
            ResolveSpells();
            enemy.spell.ClearSpell();
            player.spell.ClearSpell();
        }
        else
        {
            isEnemyTurn = !isEnemyTurn;
        }
        isDefensePhase = !isDefensePhase;
        
        Debug.Log(isEnemyTurn ? "Enemy" : "Player");
        Debug.Log(isDefensePhase ? "Defense" : "Attack");
        
        if (isEnemyTurn)
        {
            enemy.SelectCards();
        }
        else
        {
            foreach (Card card in player.hand.cards)
            {
                card.displayDefense = isDefensePhase;
                card.UpdateText();
            }
        }
        
    }
}
