using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

//Represent time view class.
public class TimerView : PangElement
{
    //Set text value to string
    //Gets the TMP_Text from this gameobject child.
    //parameters:
    //      stringTime: the time.
    public void SetText(string stringTime)
    {
        transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = stringTime;
    }
}
