using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangElement : MonoBehaviour
{
    public PangApplication app
    {
        get
        {
            return GameObject.FindObjectOfType<PangApplication>();
        }
    }
}

public class PangApplication : MonoBehaviour
{
    public PangModel model;
    public PangView view;
    public PangController controller;

    public void Notify(string p_event_path,Object p_target,params object[] p_data)
    {
        //Inotify[] controllerList = GetAllControllers();
        //foreach (PangController c in controllerList)
        //{
        //    c.OnNotification(p_event_path, p_target, p_data);
        //}
        controller.playerController.OnNotification(p_event_path, p_target, p_data);
        controller.timerController.OnNotification(p_event_path, p_target, p_data);
        controller.scoreController.OnNotification(p_event_path, p_target, p_data);
        controller.balloonFactoryController.OnNotification(p_event_path, p_target, p_data);
    }

    //public PangController[] GetAllControllers()
    //{
    //    //Inotify[] controllerList = GameObject.FindObjectsOfType<typeoInotify>();
    //    //print("Leng: " + controllerList.Length);
    //    //return controllerList;
    //}
}
