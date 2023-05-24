using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayManager : MonoBehaviour
{
    [SerializeField] GameObject finishedCanvas;
    [SerializeField] TMP_Text finishedText;

    [SerializeField] GravityController gravityController;
    [SerializeField] CountDown countDown;

    [SerializeField] int level;

    [SerializeField] UnityEvent OnStart;

    bool gameOver=false;
    public bool GameOver1 { get => gameOver;}
    

    private bool stopTimer;

    private void Start()
    {
        OnStart.Invoke();
        gravityController.SetActiveCallibration(false);
        gameOver=false;
    }

    public void GameOver()
    {
        finishedText.text = "You Failed";
        finishedCanvas.SetActive(true);
        gravityController.SetActiveCallibration(false);
        gameOver=true;
        
    }

    public void PlayerWin()
    {
        finishedText.text = "You Win";
        finishedCanvas.SetActive(true);
        var checkLevelPlayerprefs = PlayerPrefs.GetInt("LevelDone");
        if (checkLevelPlayerprefs < level)
        {
            PlayerPrefs.SetInt("LevelDone", level);
        }
    }



    [SerializeField] TMP_Text TimerText;
    [SerializeField] int SetWaktu = 10;
    float sec;


    void SetText()
    {
        int Detik = SetWaktu % 60;
        TimerText.text = Detik.ToString("00");
    }

    private void Update()
    {
        if (countDown.isCounting == true || stopTimer==true)
        {
            return;
        } else{
            gravityController.SetActiveCallibration(true);
            SetText();
            sec += Time.deltaTime;

            if (sec >= 1)
            {
                SetWaktu--;
                sec = 0;
            }

            if (SetWaktu == 0)
            {
                GameOver();
            }
        }
    }

    public void StopTimer(bool value){
        stopTimer=value;
    }    
    
    
}
