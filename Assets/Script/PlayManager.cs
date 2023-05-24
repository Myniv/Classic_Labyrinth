using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] GameObject finishedCanvas;
    [SerializeField] TMP_Text finishedText;

    int coin = 100; //TODO
    [SerializeField] int level;

    public void GameOver(){
        finishedText.text = "You Failed";
        finishedCanvas.SetActive(true);
    }

    public void PlayerWin(){
        finishedText.text = "You Win\nScore:" + GetScore();
        finishedCanvas.SetActive(true); 
        var checkLevelPlayerprefs = PlayerPrefs.GetInt("LevelDone");
        if(checkLevelPlayerprefs<level){
            PlayerPrefs.SetInt("LevelDone",level);
        }
    }

    private int GetScore(){
        return coin*10;
    }
}
