using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represent time controller.
public class TimerController : PangElement
{
    //Update time on screen, and notify controllers when time is finish.
    private void Update()
    {
        if (!app.model.TimerModel.IsTimeOut())
        {
            if (app.model.TimerModel.GetSeconds() >= 10)
                app.view.timerView.SetText(app.model.TimerModel.GetMinutes() + " : " + app.model.TimerModel.GetSeconds());
            else
                app.view.timerView.SetText(app.model.TimerModel.GetMinutes() + " : 0" + app.model.TimerModel.GetSeconds());
            app.model.TimerModel.CountDown(Time.deltaTime);
        }
        else
        {
            app.Notify(PangNotification.TimeOut, null);
            GameUIController.instance.GameOver();
        }

    }

    public void OnNotification(string p_event_path, Object p_target, params object[] p_data)
    {

    }
}
