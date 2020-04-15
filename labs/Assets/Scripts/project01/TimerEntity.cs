using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerEntity : MonoBehaviour
{
    bool m_IsStopped = true;
    public Text timerUI;
    float GAME_DURATION = 3 * 60;
    float m_Time = 3 * 60;
    public float time { get {return m_Time;} }
    // Start is called before the first frame update
    void OnEnable()
    {
        Reset();
        m_IsStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_IsStopped)
        {
            m_Time -= Time.deltaTime;
            UpdateUI ();
        }
    }

    void UpdateUI ()
    {
        var minutes = m_Time / 60;
        var seconds = m_Time % 60;
        var fraction = (m_Time * 100) % 100;

        timerUI.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
    }

    public void Stop ()
    {
        m_IsStopped = true;
    }

    public void Reset ()
    {
        m_Time = GAME_DURATION;
    }
}
