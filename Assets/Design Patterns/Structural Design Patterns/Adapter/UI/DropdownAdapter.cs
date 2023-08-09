using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownAdapter : MonoBehaviour
{
    public void ChangeSaveType(int index)
    {
        switch (index)
        {
            case 0:
                TestAdapter.index = 0;
                break;
            case 1:
                TestAdapter.index = 1;
                break;
            case 2:
                TestAdapter.index = 2;
                break;
            case 3:
                TestAdapter.index = 3;
                break;
        }
    }
}
