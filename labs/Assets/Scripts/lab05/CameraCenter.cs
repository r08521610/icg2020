﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    int m_SelectedIndex = 0;
    [SerializeField] Camera[] m_Cameras = new Camera[2];
    // Start is called before the first frame update
    void Start()
    {
        SelectCamera (m_SelectedIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.C))
        {
            NextCamera();
        }
    }

    void NextCamera ()
    {
        m_SelectedIndex++;
        m_SelectedIndex = m_SelectedIndex % m_Cameras.Length;

        SelectCamera (m_SelectedIndex);
    }

    void SelectCamera (int index)
    {
        for (int i = 0; i < m_Cameras.Length; i++)
        {
            m_Cameras [i].enabled = i == index;
        }
    }
}
