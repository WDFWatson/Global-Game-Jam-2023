using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectData : ScriptableObject
{
    public int effectValue;

    public abstract void Effect(Outcome outcome);
}
