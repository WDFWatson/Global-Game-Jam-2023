using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Effects/Plant")]
public class Plant : Effect
{
    public override void DoEffect(Outcome outcome, int effectValue)
    {
        outcome.numPlant += effectValue;
    }
}
