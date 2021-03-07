using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represent Ballon factory view class.
public class BalloonFactoryView : PangElement
{
    //This function instantiate new balloons on scene.
    //parameters:
    //      balloon:The balloon to instantiate.
    //      scale: scale of the new balloon.
    //      size: the size number of the balloon.
    public void InstantiateNewBallon(GameObject balloon,Vector3 position,Vector3 scale,int size)
    {
       GameObject obj = Instantiate(balloon,position,transform.rotation,transform);
       obj.transform.localScale = scale;
       obj.GetComponent<Balloon>().balloonSize = size;
    }

    //Instantiate balloon.
    //parameters:
    //      balloon: the balloon prefab to instantiate.
    public void InstantiateFirstBalloon(GameObject balloon)
    {
        Instantiate(balloon);
    }
}
