using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represent ballon factory controller.
public class BalloonFactoryController : PangElement
{
    //Instantiate first balloon.
    private void Start()
    {
        app.view.balloonFactoryView.InstantiateFirstBalloon(app.model.BalloonFactoryModel.GetBalloonPrefab());
    }

    //Get called whenever there is a balloon on the scene that has been destroyed, this function call InstantiateNewBallon to instantiate
    //new ballon, and make the scale of it half of the balloon which destroyed, and update balloon size to less one.
    public void OnNotification(string p_event_path, Object p_target, params object[] p_data)
    {
        if(p_event_path == PangNotification.BalloonExplosion)
        {
            Balloon oldBalloon = (Balloon)p_target;
            if (oldBalloon.balloonSize > 0)
            {
                GameObject prefab = app.model.BalloonFactoryModel.GetBalloonPrefab();
                int OldBalloonSize = oldBalloon.balloonSize - 1;
                app.view.balloonFactoryView.InstantiateNewBallon(prefab, oldBalloon.transform.position, oldBalloon.transform.localScale / 2, OldBalloonSize);
                app.view.balloonFactoryView.InstantiateNewBallon(prefab, oldBalloon.transform.position, oldBalloon.transform.localScale / 2, OldBalloonSize);
            }
        }
    }
}
