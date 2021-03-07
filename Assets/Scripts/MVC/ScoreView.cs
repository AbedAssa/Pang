using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Represent score view
public class ScoreView : PangElement
{
    //Change the text of UI which holld score text.
    //parameters:
    //      scoreText: the score as text to display.
    public void UpdateScore(string scoreText)
    {
        transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = scoreText;
    }
}
