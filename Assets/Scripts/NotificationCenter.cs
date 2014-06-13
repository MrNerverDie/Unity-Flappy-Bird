using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NotificationCenter : INotificationCenter
{
    private static INotificationCenter singleton;

    private event EventHandler GameOver;
    private event EventHandler ScoreAdd;

    private NotificationCenter()
        : base()
    {
        // 在这里添加需要分发的各种消息
        eventTable["GameOver"] = GameOver;
        eventTable["ScoreAdd"] = ScoreAdd;
    }

    public static INotificationCenter GetInstance()
    {
        if (singleton == null)
            singleton = new NotificationCenter();
        return singleton;
    }
}

public abstract class INotificationCenter
{

    protected Dictionary<string, EventHandler> eventTable;

    protected INotificationCenter()
    {
        eventTable = new Dictionary<string, EventHandler>();
    }

    public void PostNotification(string name)
    {
        this.PostNotification(name, null, EventArgs.Empty);
    }
    public void PostNotification(string name, object sender)
    {
        this.PostNotification(name, name, EventArgs.Empty);
    }
    public void PostNotification(string name, object sender, EventArgs e)
    {
        if (eventTable[name] != null)
        {
            eventTable[name](sender, e);
        }
    }

    public void AddEventHandler(string name, EventHandler handler)
    {
        eventTable[name] += handler;
    }
    public void RemoveEventHandler(string name, EventHandler handler)
    {
        eventTable[name] -= handler;
    }

}
