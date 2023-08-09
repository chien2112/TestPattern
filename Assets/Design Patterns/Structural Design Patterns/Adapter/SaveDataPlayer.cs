using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SaveDataPlayer
{
    void Save(SaveType type, PlayerStats playerStat);
}
public enum SaveType
{
    PLAYERPREFS,
    SCRRIPTABLE,
    JSON,
    SERIALIZATION
}