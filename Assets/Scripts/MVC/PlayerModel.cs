using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Represent player data.
public class PlayerModel : PangElement
{
    public float movingSpeed = 1f;
    public bool isMovableLeft = true;
    public bool isMovableRight = true;

    public Vector2 playerPosition;

    //Pullet to shoot.
    public GameObject pulletPrefab;

    public Vector3 rotation;

    //Move player to the left.
    //parameters:
    //      delta:fram time.
    public void MovePlayerLeft(float delta)
    {
        if (isMovableLeft)
        {
            playerPosition += new Vector2(-movingSpeed, 0f) * delta;
            rotation = new Vector3(0.0f, 180.0f, 0f);
        }   
    }

    //Move player to right.
    //parameters:
    //      delta: fram time
    public void MovePlayerRight(float delta)
    {
        if (isMovableRight)
        {
            playerPosition += new Vector2(movingSpeed, 0f) * delta;
            rotation = new Vector3(0.0f, 0.0f, 0f);
        }
    }

    //Instantiate a pullet on screen.
    public void Shoot()
    {
        Instantiate(pulletPrefab, playerPosition, pulletPrefab.transform.rotation);
    }

}
