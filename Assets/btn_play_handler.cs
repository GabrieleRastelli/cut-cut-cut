using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_play_handler : MonoBehaviour
{
    public void onClickRestart()
    {
        GameController.gameover = false;
        GameController.StartTime = Time.time;
        GameController.totalNumberOfCut = 0;
        SceneManager.LoadScene(0);
    }
}
