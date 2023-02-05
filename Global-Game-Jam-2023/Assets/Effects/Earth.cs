using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Effects/Earth")]
public class Earth : Effect
{
    public override void DoEffect(Outcome outcome, int effectValue)
    {
        outcome.numEarth += effectValue;
    }
}
