using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represent time model.
public class TimerModel : PangElement
{
    //Time for level.
    [SerializeField]
    private float timeRemaning = 60f;

    public void CountDown(float time)
    {
        timeRemaning -= time;
    }

    public bool IsTimeOut()
    {
        return timeRemaning <= 0.9f ? true : false; 
    }

    public float GetMinutes()
    {
        return Mathf.FloorToInt(timeRemaning / 60);
    }

    public float GetSeconds()
    {
        return Mathf.FloorToInt(timeRemaning % 60);
    }
}
