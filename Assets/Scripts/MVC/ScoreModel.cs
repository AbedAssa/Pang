using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represent score model.
//All data needed for score.
public class ScoreModel : PangElement
{
    //Instantiate score if not instantiated
    public void InitScore()
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", 0);
        }
    }

    //Get saved score.
    public int GetScore()
    {
        return PlayerPrefs.GetInt("Score");
    }

    //Add new score to old score and save.
    public void AddToScore(int numOfScore)
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + numOfScore);
        
    }
}
