using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour
{
    //float t;
    //private void Update()
    //{
    //    Action<float> action = (maxTime) =>
    //    {
    //        if (t < maxTime)
    //        {
    //            t += Time.deltaTime;
    //        };
    //    };
    //    action(10);
    //    Debug.Log(t);

    //}
    //Å¸ÀÌ¸Ó
    //    HashSet<TimeAgent> timeHashSet;

    //    private void Update()
    //    {
    //        foreach (var time in timeHashSet)
    //        {
    //            time.update.Invoke(time);
    //            time.time += Time.deltaTime;
    //            if (time.time >= time.timer)
    //            {
    //                time.remove();
    //                timeHashSet.Remove(time);
    //            }
    //        }
    //    }

    //    public void AddTime(TimeAgent agent)
    //    {
    //        timeHashSet.Add(agent);
    //    }
    //}

    //public class TimeAgent
    //{
    //    public Action<TimeAgent> update;
    //    public Action remove;
    //    public float time;
    //    public float timer;

    //    public TimeAgent(Action<TimeAgent> update, Action remove, float timer)
    //    {
    //        this.update = update;
    //        this.remove = remove;
    //        this.timer = timer;
    //    }
}