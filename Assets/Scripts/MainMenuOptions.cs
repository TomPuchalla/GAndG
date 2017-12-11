using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.EventSystems;
//using System;

public class MainMenuOptions : MonoBehaviour
{
    MainMenu mainMenu;
    ChangeMusic changeMusic;

    public GameObject menuOptionsUI;
    //GameObject clicked;
    //RaycastHit rayHit;
    //public LayerMask layerUI;
    public GameObject menuOptions;
    //public GameObject menuOptionsClose;
    public GameObject musicOn;
    public GameObject musicOff;
    public GameObject exitGame;

    public GameObject controlsPage;
    public GameObject controlsShowButton;
    public GameObject controlsHideButton;

    public bool menuMusicPlaying = true;
    public bool menuOpen = false;

    private void Awake()
    {
        mainMenu = GameObject.FindObjectOfType<MainMenu>();
        changeMusic = GameObject.FindObjectOfType<ChangeMusic>();
    }

    void Start()
    {
        menuOptionsUI.SetActive(false);
        menuMusicPlaying = true;

        controlsShowButton.SetActive(true);
        controlsHideButton.SetActive(false);
        controlsPage.SetActive(false);
}

    public void MenuOptionsButton()
    {
        //Debug.Log("Options click");
        menuOptionsUI.SetActive(true);
        //menuOptions.SetActive(false);

        //menuOptions.SetActive(false);

        /*if (menuOptionsUI.activeInHierarchy)
        {
            menuOptionsUI.SetActive(false);
            //menuOpen = true;
        }
        if (menuOptionsUI.act == false)
        {
            menuOptionsUI.SetActive(true);
            //menuOpen = false;
        }*/
    }

    public void MenuOptionsClose()
    {
        //menuOptions.SetActive(true);
        menuOptionsUI.SetActive(false);
        controlsPage.SetActive(false);
    }

    public void MusicOn()
    {
        menuMusicPlaying = true;
        musicOn.SetActive(false);
        musicOff.SetActive(true);

        if (changeMusic.source.isPlaying == false)
        {
            changeMusic.source.Play();
        }
    }

    public void MusicOff()
    {
        menuMusicPlaying = false;
        musicOn.SetActive(true);
        musicOff.SetActive(false);

        if (changeMusic.source.isPlaying)
        {
            changeMusic.source.Pause();
        }
    }

    public void ResetScores()
    {
        Debug.Log("reset scores");
        PlayerPrefs.DeleteAll();
        mainMenu.UpdateScores();
    }

    public void ControlsShow()
    {
        controlsPage.SetActive(true);
        controlsHideButton.SetActive(true);
        controlsShowButton.SetActive(false);
    }

    public void ControlsHide()
    {
        controlsPage.SetActive(false);
        controlsShowButton.SetActive(true);
        controlsHideButton.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}