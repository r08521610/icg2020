using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project02
{
    public class CameraCenter : MonoBehaviour
    {

        private static CameraCenter _instance;
        public static CameraCenter Instance
        {
            get
            {
                if (_instance == null) _instance = new CameraCenter();
                return _instance;
            }
        }

        public GameObject m_GodViewCam;
        public GameObject m_SideViewCam;

        int m_CameraIndex = 0;
        [SerializeField] GameObject[] m_Cameras;

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy (this.gameObject);
            } else {
                _instance = this;
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown (KeyCode.RightArrow))
            {
                m_CameraIndex ++;
                m_CameraIndex = m_CameraIndex % m_Cameras.Length;
                SelectCamera (m_CameraIndex);
            }
            if (Input.GetKeyDown (KeyCode.LeftArrow))
            {
                m_CameraIndex --;
                m_CameraIndex = (m_Cameras.Length + m_CameraIndex) % m_Cameras.Length;
                SelectCamera (m_CameraIndex);
            }
        }

        void SelectCamera (int index)
        {
            for (int i = 0; i < m_Cameras.Length; i++)
            {
                m_Cameras [i].SetActive(i == index);
            }
        }

        public void TurnOnGodViewCam ()
        {
            m_SideViewCam.SetActive(false);
            m_GodViewCam.SetActive(true);
        }
        public void TurnOnSideViewCam ()
        {
            m_GodViewCam.SetActive(false);
            m_SideViewCam.SetActive(true);
        }
    }
}