using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represent score controller.
public class ScoreController : PangElement,Inotify
{
    //Instantiate score and display last updated score on the screen.
    private void Start()
    {
        app.model.scoreModel.InitScore();
        app.view.scoreView.UpdateScore(app.model.scoreModel.GetScore().ToString());
    }

    //Get called when the player collects extra coins.
    //add new score to old score and update the score on the screen.
    public void OnNotification(string p_event_path, Object p_target, params object[] p_data)
    {
        if (p_event_path == PangNotification.CollectedExtraCoinGift)
        {
            app.model.scoreModel.AddToScore(10);
            app.view.scoreView.UpdateScore(app.model.scoreModel.GetScore().ToString());
        }
    }
}
