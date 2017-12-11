using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    Player player;

    public Text hole1Score;
    public Text hole2Score;
    public Text hole3Score;
    public Text hole4Score;
    public Text hole5Score;
    public Text hole6Score;
    public Text hole7Score;

    //Boss
    public Text courseScore;

    public bool bossUnlocked;
    public GameObject bossButton;
    public Image bossButtonImage;
    public GameObject bossButtonUnlock;
    private Image bossHoleTitleImage;
    public GameObject bossHoleInfo;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    void Start ()
    {
        //courseScore.gameObject.SetActive(false);

        hole1Score.text = PlayerPrefs.GetInt("Level1BestScore", 100).ToString();
        hole2Score.text = PlayerPrefs.GetInt("Level2BestScore", 100).ToString();
        hole3Score.text = PlayerPrefs.GetInt("Level3BestScore", 100).ToString();
        hole4Score.text = PlayerPrefs.GetInt("Level4BestScore", 100).ToString();
        hole5Score.text = PlayerPrefs.GetInt("Level5BestScore", 100).ToString();
        hole6Score.text = PlayerPrefs.GetInt("Level6BestScore", 100).ToString();
        hole7Score.text = PlayerPrefs.GetInt("Level7BestScore", 100).ToString();
        UpdateScores();

        if (PlayerPrefs.GetInt("Level1BestScore", 100) + PlayerPrefs.GetInt("Level2BestScore", 100) + PlayerPrefs.GetInt("Level3BestScore", 100) + PlayerPrefs.GetInt("Level4BestScore", 100) + PlayerPrefs.GetInt("Level5BestScore", 100) + PlayerPrefs.GetInt("Level6BestScore", 100) < 100)
        {
            CourseScoreUnlock();
        }
        else
        {
            courseScore.text = "-";
        }

        //Boss
        bossUnlocked = false;
        bossButton.SetActive(true);
        bossButtonImage.color = new Color(1, 0.43f, 0.43f, 0.5f);
        bossButtonUnlock.SetActive(true);
        bossHoleInfo.SetActive(false);
    }
	
	//void Update ()
    //{
        //UpdateScores();
    //}

    public void UpdateScores()
    {
        hole1Score.text = PlayerPrefs.GetInt("Level1BestScore", 100).ToString();
        hole2Score.text = PlayerPrefs.GetInt("Level2BestScore", 100).ToString();
        hole3Score.text = PlayerPrefs.GetInt("Level3BestScore", 100).ToString();
        hole4Score.text = PlayerPrefs.GetInt("Level4BestScore", 100).ToString();
        hole5Score.text = PlayerPrefs.GetInt("Level5BestScore", 100).ToString();
        hole6Score.text = PlayerPrefs.GetInt("Level6BestScore", 100).ToString();
        hole7Score.text = PlayerPrefs.GetInt("Level7BestScore", 100).ToString();

        if (PlayerPrefs.GetInt("Level1BestScore", 100) == 100)
        {
            hole1Score.text = "";
            //if (hole1Score.text == null || hole1Score.text == "") ;
        }

        if (PlayerPrefs.GetInt("Level2BestScore", 100) == 100)
        {
            hole2Score.text = "";
            //if (hole2Score.text == null || hole2Score.text == "") ;
        }

        if (PlayerPrefs.GetInt("Level3BestScore", 100) == 100)
        {
            hole3Score.text = "";
            //if (hole3Score.text == null || hole3Score.text == "") ;
        }

        if (PlayerPrefs.GetInt("Level4BestScore", 100) == 100)
        {
            hole4Score.text = "";
            //if (hole4Score.text == null || hole4Score.text == "") ;
        }

        if (PlayerPrefs.GetInt("Level5BestScore", 100) == 100)
        {
            hole5Score.text = "";
            //if (hole5Score.text == null || hole5Score.text == "") ;
        }

        if (PlayerPrefs.GetInt("Level6BestScore", 100) == 100)
        {
            hole6Score.text = "";
            //if (hole6Score.text == null || hole6Score.text == "") ;
        }

        if (PlayerPrefs.GetInt("Level7BestScore", 100) == 100)
        {
            hole7Score.text = "";
            //if (hole7Score.text == null || hole7Score.text == "") ;
        }
    }

    public void CourseScoreUnlock()
    {
        courseScore.gameObject.SetActive(true);
        courseScore.text = (PlayerPrefs.GetInt("Level1BestScore", 100) + PlayerPrefs.GetInt("Level2BestScore", 100) + PlayerPrefs.GetInt("Level3BestScore", 100) + PlayerPrefs.GetInt("Level4BestScore", 100) + PlayerPrefs.GetInt("Level5BestScore", 100) + PlayerPrefs.GetInt("Level6BestScore", 100)).ToString();
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Hole 1");
        Debug.Log("hole 1 load");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Hole 2");
        Debug.Log("hole 2 load");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Hole 3");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Hole 4");
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene("Hole 5");
    }

    public void LoadLevel6()
    {
        SceneManager.LoadScene("Hole 6");
    }

    public void LoadLevel7Boss()
    {
        if (bossUnlocked)
        {
            SceneManager.LoadScene("Hole 7");
        }
    }

    private void Update()
    {
        //Boss Unlock Bool
        if (PlayerPrefs.GetInt("Level1BestScore", 100) + PlayerPrefs.GetInt("Level2BestScore", 100) + PlayerPrefs.GetInt("Level3BestScore", 100) + PlayerPrefs.GetInt("Level4BestScore", 100) + PlayerPrefs.GetInt("Level5BestScore", 100) + PlayerPrefs.GetInt("Level6BestScore", 100) < 100)
        {
            bossUnlocked = true;
        }

        if (bossUnlocked)
        {
            //Boss
            bossButton.SetActive(true);
            bossButtonImage.color = new Color(1, 0.43f, 0.43f, 1f);
            bossButtonUnlock.SetActive(false);
            bossHoleInfo.SetActive(true);
        }
    }
}
