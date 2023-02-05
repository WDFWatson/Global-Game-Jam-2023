using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Heal")]
public class Heal : Effect
{
    public override void DoEffect(Outcome outcome, int effectValue)
    {
        outcome.casterHealthChange += effectValue;
    }
}
