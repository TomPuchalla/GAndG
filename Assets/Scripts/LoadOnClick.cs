using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

    public GameObject transitionHole;
    string courseName = "";
    bool transitionHoleLarge = false;
    //Vector3 destinationScale;

    //public void LoadScene(int level)
    public void LoadScene(string courseName)
    {
        //transitionHole.SetActive(true);
        //Application.LoadLevel(level);
        SceneManager.LoadScene(courseName);
        //StartCoroutine(ScaleOverTime(2));    
    }

    /*IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = transitionHole.transform.localScale;
        Vector3 destinationScale = new Vector3(10.0f, 10.0f, 1);

        float currentTime = 0.0f;

        do
        {
            transitionHole.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            if (transitionHole.transform.localScale == destinationScale)
            {
                transitionHoleLarge = true;
            }
            yield return null;


        } while (currentTime <= time);

        //if(transitionHoleLarge)
        {
            //Application.LoadLevel(level);
            SceneManager.LoadScene(courseName);
        }



        //Destroy(gameObject);
    }*/

    /*private void Update()
    {
        if (transitionHole.transform.localScale == destinationScale)
        {
            transitionHoleLarge = true;
        }
    }*/
}