using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private TextMeshPro spellText; 
        
    public List<EffectData> rootEffect;

    public List<EffectData> affixEffects;

    private void Awake()
    {
        affixEffects = new List<EffectData>();
        ClearSpell();
    }

    public void AddCard(RootData cardToAdd)
    {
        spellText.text += cardToAdd.cardName.ToUpper();
        if (rootEffect == null)
        {
            rootEffect = TurnManager.i.isDefensePhase ? cardToAdd.rootEffectDefense : cardToAdd.rootEffectAttack;
        }
        else
        {
            affixEffects.AddRange(TurnManager.i.isDefensePhase ? cardToAdd.affixEffectDefense : cardToAdd.affixEffectAttack);
        }
    }

    public void ClearSpell()
    {
        spellText.text = "";
        rootEffect = null;
        affixEffects.Clear();
    }
}
