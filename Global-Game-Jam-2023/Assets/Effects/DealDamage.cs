using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Effects/DealDamage")]
public class DealDamage : Effect
{
    public override void DoEffect(Outcome outcome, int effectValue)
    {
        outcome.attackDamage += effectValue;
    }
}
