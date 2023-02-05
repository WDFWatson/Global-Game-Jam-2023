using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Effects/Fire")]
public class Fire : Effect
{
    public override void DoEffect(Outcome outcome, int effectValue)
    {
        outcome.numFire += effectValue;
    }
}
