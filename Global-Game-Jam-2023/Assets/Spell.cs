using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public List<EffectData> rootEffect;

    public List<EffectData> affixEffects;

    private void Awake()
    {
        rootEffect = null;
        affixEffects = new List<EffectData>();
    }

    public void AddCard(RootData cardToAdd)
    {
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
        rootEffect = null;
        affixEffects.Clear();
    }
}
