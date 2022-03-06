using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mod Info", menuName = "EverhoodModding/ModInfo")]
public class MyModInfo : ScriptableObject
{
    public enum BattleType
    {
        Vanilla, Loopable, KillMode, KillModeAndLoopable
    }

    public string battleName;
    public string authorName;
    public Sprite Banner;
    public BattleType battleType;
}
