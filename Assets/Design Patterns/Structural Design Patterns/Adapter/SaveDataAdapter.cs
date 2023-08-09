using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataAdapter : MonoBehaviour, SaveDataPlayer
{
    private UsingJson json;
    private UsingPlayerPrefs playerPrefs;
    private UsingScriptableObject scriptableObject;
    private UsingSerialization serialization;


    private void Start()
    {
        json = this.GetComponent<UsingJson>();
        playerPrefs = this.GetComponent<UsingPlayerPrefs>();
        scriptableObject = this.GetComponent<UsingScriptableObject>();
        serialization = this.GetComponent<UsingSerialization>();

    }
    public void Save(SaveType type, PlayerStats playerStat)
    {
        if(type == SaveType.JSON)
        {
            json.Save();
        }
        else if(type == SaveType.SCRRIPTABLE)
        {
            scriptableObject.Save();
        }
        else if(type == SaveType.PLAYERPREFS)
        {
            playerPrefs.Save();
        }
        else if(type == SaveType.SERIALIZATION)
        {
            serialization.Save();
        }
    }


}
