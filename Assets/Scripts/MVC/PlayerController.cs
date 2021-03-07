using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represents Player controller
public class PlayerController : PangElement
{

    //Update player position.
    private void Start()
    {
        app.model.playerModel.playerPosition = app.view.playerView.transform.position;
    }

    //Get called when a player wants to move
    public void OnNotification(string p_event_path, Object p_target, params object[] p_data)
    {
        if (p_event_path == PangNotification.PlayerMoveLeft)
        {
            app.model.playerModel.MovePlayerLeft(Time.deltaTime);
            app.view.playerView.SetPosition(app.model.playerModel.playerPosition);
            app.view.playerView.SetRotation(app.model.playerModel.rotation);
            app.model.playerModel.isMovableRight = true;
            if(app.model.playerModel.isMovableLeft)
                app.view.playerView.SetRunAnimation(true);
        }
        else if (p_event_path == PangNotification.PlayerMoveRight)
        {
            app.model.playerModel.MovePlayerRight(Time.deltaTime);
            app.view.playerView.SetPosition(app.model.playerModel.playerPosition);
            app.view.playerView.SetRotation(app.model.playerModel.rotation);
            app.model.playerModel.isMovableLeft = true;
            if (app.model.playerModel.isMovableRight)
                app.view.playerView.SetRunAnimation(true);
        }
        else if (p_event_path == PangNotification.PlayerHitLeftBorder)
        {
            app.model.playerModel.isMovableLeft = false;
            app.model.playerModel.isMovableRight = true;
            app.view.playerView.SetRunAnimation(false);
        }
        else if (p_event_path == PangNotification.PlayerHitRightBorder)
        {
            app.model.playerModel.isMovableRight = false;
            app.model.playerModel.isMovableLeft = true;
            app.view.playerView.SetRunAnimation(false);
        }
        if (p_event_path == PangNotification.ShootPullet)
        {
            app.model.playerModel.Shoot();
            print("Shoot");
        }
        if(p_event_path == PangNotification.TimeOut)
        {
            print("TimeOut");
        }

    }

}
