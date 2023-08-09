using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TestAdapter : MonoBehaviour
{
    TextMeshProUGUI txtName;
    TextMeshProUGUI txtHp;

    public PlayerStats playerStats;
    SaveDataPlayer saveData;
    public SaveDataAdapter adapter;
    public static int index;

    private void Start()
    {
        index = 0;
        saveData = adapter;
    }
    public void ButtonSave()
    {
        switch (index)
        {
            case 0:
                saveData.Save(SaveType.JSON, playerStats);
                break;
            case 1:
                saveData.Save(SaveType.SERIALIZATION, playerStats);
                break;
            case 2:
                saveData.Save(SaveType.PLAYERPREFS, playerStats);
                break;
            case 3:
                saveData.Save(SaveType.SCRRIPTABLE, playerStats);
                break;
        }
    }
}
