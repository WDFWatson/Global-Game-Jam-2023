using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Water")]
public class Water : Effect
{
    public override void DoEffect(Outcome outcome, int effectValue)
    {
        outcome.numWater += effectValue;
    }
}
