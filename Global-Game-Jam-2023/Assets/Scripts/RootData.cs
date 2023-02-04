using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RootData : ScriptableObject
{
    public string cardName;

    public string rootDescriptionAttack;
    public List<EffectData> rootEffectAttack;
    
    public string affixDescriptionAttack;
    public List<EffectData> affixEffectAttack;
    
    public string rootDescriptionDefense;
    public List<EffectData> rootEffectDefense;
    
    public string affixDescriptionDefense;
    public List<EffectData> affixEffectDefense;
}
