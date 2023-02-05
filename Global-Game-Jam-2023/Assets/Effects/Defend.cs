using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Defend")]
public class Defend : Effect
{
    public override void DoEffect(Outcome outcome, int effectValue)
    {
        outcome.defenseValue += effectValue;
    }
}
