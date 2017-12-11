using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.EventSystems;
//using System;

public class PauseMenu : MonoBehaviour
{
    ChangeMusic changeMusic;

    public GameObject pauseUI;
    GameObject clicked;
    RaycastHit rayHit;
    public LayerMask layerUI;
    public GameObject options;
    public GameObject resume;
    public GameObject musicOn;
    public GameObject musicOff;
    public GameObject restart;
    public GameObject exitHole;
    public GameObject pausedMessage;

    public GameObject controlsPage;
    public GameObject controlsShowButton;
    public GameObject controlsHideButton;

    public bool paused = false;
    public bool musicPlaying = true;

    private void Awake()
    {
        changeMusic = GameObject.FindObjectOfType<ChangeMusic>();
    }

    void Start()
    {
        pauseUI.SetActive(false);
        pausedMessage.SetActive(false);
        //musicOn.SetActive(false);
        musicPlaying = true;

        controlsShowButton.SetActive(true);
        controlsHideButton.SetActive(false);
        controlsPage.SetActive(false);
    }

    void Update()
    {
        //if (Input.mousePosition )

        /*if (Input.GetButtonDown("Options"))
        {
            Debug.Log("Pause/Options");
            paused = !paused;
        }*/

        if (paused)
        {
            resume.SetActive(true);
            Time.timeScale = 0; //pauses gameplay

            if (musicPlaying)
            {
                musicOff.SetActive(true);
            }
        }

        if (!paused)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1; //unpause gameplay
        }

        //Debug.Log(musicPlaying);

    }

    /*private void OnMouseDown()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition).origin, rayHit.point,layerUI))
        {
            clicked = rayHit.collider.gameObject;
            print(clicked.name);
        }
    }*/

    public void OptionsButton()
    {
        //Debug.Log("Pause/Options");
        //paused = !paused;
        paused = true;
        options.SetActive(false);
        pauseUI.SetActive(true);
        //resume.SetActive(true);
        pausedMessage.SetActive(true);
    }

    public void Resume()
    {
        paused = false;
        //resume.SetActive(false);
        pauseUI.SetActive(false);
        options.SetActive(true);
        pausedMessage.SetActive(false);

        controlsPage.SetActive(false);
    }

    public void MusicOn()
    {
        musicPlaying = true;
        musicOn.SetActive(false);
        musicOff.SetActive(true);

        if (changeMusic.source.isPlaying == false)
        {
            changeMusic.source.Play();
            //changeMusic.source.mute = true;
        }
    }

    public void MusicOff()
    {
        musicPlaying = false;
        musicOn.SetActive(true);
        musicOff.SetActive(false);

        if (changeMusic.source.isPlaying)
        {
            changeMusic.source.Pause();
        }
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

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene(0);
    }

    public void ExitHole()
    {
        Application.LoadLevel(0);
    }

    /*public void Quit()
    {
        Application.Quit();
    }*/

    /*public void OnPointerClick(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }*/
}
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //print(ray.origin);

//if (ray)

/*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
if (Physics.Raycast(ray))
{
    Debug.Log("click");
    print(gameObject.name);
}

On
}
}
*/