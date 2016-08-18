using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour {

    int numFull;
    int numNew;
    int score;
    //Ratio of bonus points given for each full/new moon. Multiplicative bonusRatio ^ numMoons
    double bonusRatio;
    GameObject controllerReference;

    public void ExitPressed()
    {
        Debug.Log("Start button pressed");
        SceneManager.LoadScene("Title Scene");
    }

    void updateScoreValues()
    {
        int tempNewMoon = 0;
        int tempFullMoon = 0;
        int baseScore = 0;

        //Add up new moons and full moons
        GameObject[] theEdges = GameObject.FindGameObjectsWithTag("Edge");
        for (int i = 0; i < theEdges.Length; i++)
        {
            int tempValue = System.Math.Abs(theEdges[i].GetComponent<EdgeScript>().moonValue);
            if(tempValue == 0)
            {
                tempNewMoon = tempNewMoon + 1;
            }
            if(tempValue == 7)
            {
                tempFullMoon = tempFullMoon + 1;
            }
            baseScore = baseScore + tempValue;
        }
        //Update the values we really want
        numFull = tempFullMoon;
        numNew = tempNewMoon;
        score = baseScore * (int)System.Math.Pow(bonusRatio, numNew + numFull);
        //Debug.Log(theEdges.Length.ToString());
        
    }

    // Use this for initialization
    void Start () {
        numFull = 0;
        numNew = 0;
        score = 0;
        bonusRatio = 1.2;
        controllerReference = GameObject.FindGameObjectWithTag("GameController");
    }

	// Update is called once per frame
	void Update () {
        updateScoreValues();
        GameObject.Find("Score Display").GetComponentInChildren<Text>().text = score.ToString();
        GameObject.Find("New Moon").GetComponentInChildren<Text>().text = numNew.ToString();
        GameObject.Find("Full Moon").GetComponentInChildren<Text>().text = numFull.ToString();
    }
}
