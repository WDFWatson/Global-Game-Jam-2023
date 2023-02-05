using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Effects/Wind")]
public class Wind : Effect
{
    public override void DoEffect(Outcome outcome, int effectValue)
    {
        outcome.numWind += effectValue;
    }
}
