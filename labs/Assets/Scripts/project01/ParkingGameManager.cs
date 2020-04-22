using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum GameMode
{
    Single,
    Double
}

public class ParkingGameManager : MonoBehaviour
{
    bool m_IsGameStarting = false;
    GameMode m_Mode;
    public GameObject timer;
    public GameObject parkingRemainUI;
    public GameObject startScreen;
    public GameObject back2StartScreenBtn;
    public GameObject DoubleModeButton;
    public GameObject startScreenVCam;
    public GameObject gameOverScreen;
    public GameObject youWinScreen;
    public GameObject car;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (startScreen.activeSelf)
            {
                CreateSingleModeGame();
            }
            if (gameOverScreen.activeSelf || youWinScreen.activeSelf)
            {
                Back2StartScreen();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !startScreen.activeSelf)
        {
            Back2StartScreen();
        }

        if (ParkingGameGradingSystem.Instance.GetCurrentPoints() <= 0)
        {
            GameOver ();
        }
        if (timer.activeSelf && timer.GetComponent <TimerEntity> ().time <= 0)
        {
            YouWin ();
        }
    }

    public void CreateSingleModeGame ()
    {
        m_Mode = GameMode.Single;
        m_IsGameStarting = true;
        startScreen.SetActive(false);
        startScreenVCam.SetActive(false);
    }
    public void StartGame ()
    {
        back2StartScreenBtn.SetActive(true);
        timer.SetActive(true);
        parkingRemainUI.SetActive(true);
        car.GetComponent <CarEntity3D> ().enabled = false;
        car.GetComponent <CarEntity3D> ().enabled = true;
    }

    public void YouWin ()
    {
        back2StartScreenBtn.SetActive(false);
        m_IsGameStarting = false;
        youWinScreen.SetActive(true);
        timer.GetComponent <TimerEntity> ().Stop ();
        car.GetComponent <CarEntity3D> ().enabled = false;
    }
    public void GameOver ()
    {
        back2StartScreenBtn.SetActive(false);
        m_IsGameStarting = false;
        gameOverScreen.SetActive(true);
        timer.GetComponent <TimerEntity> ().Stop ();
        car.GetComponent <CarEntity3D> ().enabled = false;
    }
    public void StopGame ()
    {
        back2StartScreenBtn.SetActive(false);
        m_IsGameStarting = false;
        car.GetComponent <CarEntity3D> ().enabled = false;
        Back2StartScreen();
    }

    public void Back2StartScreen ()
    {
        startScreen.SetActive(true);
        startScreenVCam.SetActive(true);
        timer.SetActive(false);
        parkingRemainUI.SetActive(false);
        youWinScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        ParkingGameGradingSystem.Instance.Reset();
        car.GetComponent <CarEntity3D> ().enabled = true;
    }

    public void CreateDoubleModeGame ()
    {
        var text = DoubleModeButton.GetComponentInChildren <Text> ();
        text.text = "Wake up! You have no friends.";
        IEnumerator ChangeBack () {
            yield return new WaitForSeconds(5);
            text.text = "Double";
        }
        StartCoroutine (ChangeBack ());
    }
}
