using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Inotify
{
     void OnNotification(string p_event_path, Object p_target, params object[] p_data);
}
