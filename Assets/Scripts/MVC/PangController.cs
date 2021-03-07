using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represent all controllers in scene.
public class PangController : PangElement
{
    public PlayerController playerController;
    public TimerController timerController;
    public CollectableFactoryController factoryController;
    public ScoreController scoreController;
    public BalloonFactoryController balloonFactoryController;

}
