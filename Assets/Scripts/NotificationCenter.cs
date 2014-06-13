using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class NotificationCenter {

    private NotificationCenter singleton;
    private Dictionary<string, Delegate> eventTable;


}
