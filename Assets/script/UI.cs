using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Sprite[] lives;
    public Image currentLife;
    public Sprite buttonXClicked;
    public Image buttonX;
    public GameObject menuPause;
    public GameObject menuLose;

    public Text faseText;
    public GameObject faseObject;
    public GameObject blackScreen;

    public GameObject victory;


    public void updateLives(int life)
    {
        currentLife.sprite = lives[life];
    }

    public void cursorOff(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void cursorOn()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; ;
    }

    public void gamePause()
    {
        menuPause.SetActive(true);
        cursorOn();
        pause();
        Player.isPause = true;
    }
    public void gamePlay()
    {
        menuPause.SetActive(false);
        cursorOff();
        play();
        Player.isPause = false;
    }
    public void lose()
    {
        menuLose.SetActive(true);
        pause();
        cursorOn();
        Player.isPause = true;
    }

    public void pause()
    {
        Time.timeScale = 0;
    }

    public void play()  {
        Time.timeScale = 1;
    }

    public void currentTextFase(int fase)
    {
        faseText.text = "Fase " + fase;
    }

    public void currentFaseOff()
    {
        faseObject.SetActive(false);
    }
    public void currentfaseOn()
    {
        faseObject.SetActive(true);
    }

    public void victoryOn()
    {
        victory.SetActive(true);
    }
    public void victoryOff()
    {
        victory.SetActive(false);
    }
    public void blackScreenOn()
    {
        blackScreen.SetActive(true);
    }
    public void blackScreenOff()
    {
        blackScreen.SetActive(false);
    }


}
