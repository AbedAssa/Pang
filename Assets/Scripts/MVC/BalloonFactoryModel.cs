using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represent Balloon factory model class.
//Contain all data needed for factoring new balloons.
public class BalloonFactoryModel : PangElement
{
    [SerializeField]
    private GameObject balloon;
    
    public GameObject GetBalloonPrefab()
    {
        return balloon;
    }

}
