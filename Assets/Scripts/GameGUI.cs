using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour
{
    Player player;

    //Shots UI
    //public Sprite golfHeart;
    public Image shotsUI;
    public Text shotsText;

    //ScoreUpdate
    public Text levelPar;
    //public GameObject holeScore;
    public Text holeScoreText;
    public Text holeScoreNumber;
    public Text holeReward;

    //DistanceUI
    public Slider distanceUI;
    float startDistanceToPin;
    float currentDistanceToPin;
    public GameObject hole;

	void Awake ()
    {
        player = GameObject.FindObjectOfType<Player>();
	}

    private void Start()
    {
        //startDistanceToPin = Vector2.Distance(player.playerrb.position, new Vector2(1000, 0));
        startDistanceToPin = Vector2.Distance(player.playerrb.position, hole.transform.position);
        levelPar.text = "Par " + player.maxShots;

        holeScoreText.enabled = false;
        holeScoreNumber.enabled = false;
        holeReward.enabled = false;
    }

    void Update ()
    {
        shotsText.text = "" + player.curShots;

        currentDistanceToPin = Vector2.Distance(player.playerrb.position, hole.transform.position);
        distanceUI.value = 1 - (currentDistanceToPin / startDistanceToPin);
        //Debug.Log("sd = " + startDistanceToPin);
        //Debug.Log("cd = " + currentDistanceToPin);
        //Debug.Log("distance = " + distanceUI.value);

        if (player.holeFinish)
        {
            holeScoreText.enabled = true;
            holeScoreNumber.enabled = true;
            holeReward.enabled = true;

            holeScoreNumber.text = "" + player.holeScore;

            //if (player.maxShots - player.holeScore == 5)
            if (player.maxShots - player.holeScore >= 5 && player.maxShots - player.holeScore <= 9)
            {
                holeReward.text = "Amazing!";
            }

            if (player.maxShots - player.holeScore == 4)
            {
                holeReward.text = "Condor!!!!";
            }

            if (player.maxShots - player.holeScore == 3)
            {
                holeReward.text = "Albatross!!!";
            }

            if (player.maxShots - player.holeScore == 2)
            {
                holeReward.text = "Eagle!!";
            }

            if (player.maxShots - player.holeScore == 1)
            {
                holeReward.text = "Birdie!";
            }

            if (player.maxShots - player.holeScore == 0)
            {
                holeReward.text = "Par";
            }

            if (player.maxShots - player.holeScore == player.maxShots - 1)
            {
                holeReward.text = "Hole In One!";
            }
        }
    }
}
