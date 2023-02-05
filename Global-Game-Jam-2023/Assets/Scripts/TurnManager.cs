using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public float elementValue = 0.25f;
    [SerializeField] private GameObject resetSpell, castSpell, proceed;
    
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
        proceed.SetActive(false);
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

        if (attackOutcome.numFire > 0)
        {
            if (defenseOutcome.numPlant > 0)
            {
                attackOutcome.attackDamage = Mathf.RoundToInt(attackOutcome.attackDamage *
                                                              (1 + elementValue * (attackOutcome.numFire +
                                                                  defenseOutcome.numPlant)));
            }
            if (defenseOutcome.numWater > 0)
            {
                defenseOutcome.defenseValue = Mathf.RoundToInt(defenseOutcome.defenseValue *
                                                              (1 + elementValue * (attackOutcome.numFire +
                                                                  defenseOutcome.numWater)));
            }
        }
        if (attackOutcome.numPlant > 0)
        {
            if (defenseOutcome.numEarth > 0)
            {
                attackOutcome.attackDamage = Mathf.RoundToInt(attackOutcome.attackDamage *
                                                              (1 + elementValue * (attackOutcome.numPlant +
                                                                  defenseOutcome.numEarth)));
            }
            if (defenseOutcome.numFire > 0)
            {
                defenseOutcome.defenseValue = Mathf.RoundToInt(defenseOutcome.defenseValue *
                                                               (1 + elementValue * (attackOutcome.numPlant +
                                                                   defenseOutcome.numFire)));
            }
        }
        if (attackOutcome.numEarth > 0)
        {
            if (defenseOutcome.numWind > 0)
            {
                attackOutcome.attackDamage = Mathf.RoundToInt(attackOutcome.attackDamage *
                                                              (1 + elementValue * (attackOutcome.numEarth +
                                                                  defenseOutcome.numWind)));
            }
            if (defenseOutcome.numPlant > 0)
            {
                defenseOutcome.defenseValue = Mathf.RoundToInt(defenseOutcome.defenseValue *
                                                               (1 + elementValue * (attackOutcome.numEarth +
                                                                   defenseOutcome.numPlant)));
            }
        }
        if (attackOutcome.numWind > 0)
        {
            if (defenseOutcome.numWater > 0)
            {
                attackOutcome.attackDamage = Mathf.RoundToInt(attackOutcome.attackDamage *
                                                              (1 + elementValue * (attackOutcome.numWind +
                                                                  defenseOutcome.numWater)));
            }
            if (defenseOutcome.numEarth > 0)
            {
                defenseOutcome.defenseValue = Mathf.RoundToInt(defenseOutcome.defenseValue *
                                                               (1 + elementValue * (attackOutcome.numWind +
                                                                   defenseOutcome.numEarth)));
            }
        }
        if (attackOutcome.numWater> 0)
        {
            if (defenseOutcome.numFire > 0)
            {
                attackOutcome.attackDamage = Mathf.RoundToInt(attackOutcome.attackDamage *
                                                              (1 + elementValue * (attackOutcome.numWater +
                                                                  defenseOutcome.numFire)));
            }
            if (defenseOutcome.numWind > 0)
            {
                defenseOutcome.defenseValue = Mathf.RoundToInt(defenseOutcome.defenseValue *
                                                               (1 + elementValue * (attackOutcome.numWater +
                                                                   defenseOutcome.numWind)));
            }
        }
            
        int damage = attackOutcome.attackDamage - defenseOutcome.defenseValue;
        if (damage < 0)
        {
            damage = 0;
        }
        
        

        if (isPlayerAttack)
        {
            enemy.ModifyHealth(defenseOutcome.casterHealthChange-damage);
            player.ModifyHealth(attackOutcome.casterHealthChange);
        }
        else
        {
            player.ModifyHealth(defenseOutcome.casterHealthChange-damage);
            enemy.ModifyHealth(attackOutcome.casterHealthChange);
        }

        if (player.health <= 0)
        {
            PlayerManager.LoadDefeat();
        }

        if (enemy.health <= 0)
        {
            PlayerManager.LoadVictory();
        }
    }

    public void Proceed()
    {
        if (isDefensePhase)
        {
            ResolveSpells();
            enemy.spell.ClearSpell();
            player.spell.ClearSpell();
            player.StartTurn();
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
            resetSpell.SetActive(false);
            castSpell.SetActive(false);
            proceed.SetActive(true);
        }
        else
        {
            resetSpell.SetActive(true);
            castSpell.SetActive(true);
            proceed.SetActive(false);
            foreach (Card card in player.hand.cards)
            {
                card.displayDefense = isDefensePhase;
                card.UpdateText();
            }
        }
        
    }
}
