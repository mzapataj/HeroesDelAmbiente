using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    Text timer_text;
    private float timer;
    public int  m, s;
    /*
    public Tiempo(Text timer_text)
    {
        this.timer_text = timer_text;
        timer = new System.Timers.Timer();
        timer.Interval = 1000;
        timer.Elapsed += OnTimeEvent;
    }*/
    public void Start()
    {
        timer_text = gameObject.GetComponent<Text>();
    }

    public void Update()
    {
        updateTime();
    }

    public void updateTime()
    {
        timer += Time.deltaTime;
        s = (int)(timer % 61);

        if (s == 60)
        {
            s = 0;
            m += 1;
        }
        timer_text.text = string.Format("{0}:{1}", m.ToString(), s.ToString().PadLeft(2,'0'));
    }

    /*
    private void OnTimeEvent(object sender, ElapsedEventArgs e)
    {

        
        Invoke(new Action(() =>
        {
            s += 1;
            if (s == 60)
            {
                s = 0;
                m += 1;
            }
            timer_text.text = string.Format("{0}:{1}",m.ToString(),s.ToString());
        }));
    }
    */
}
