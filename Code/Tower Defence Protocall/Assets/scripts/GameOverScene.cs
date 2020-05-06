using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{
    public GameObject Score;
    public Text textbox;
    void start()
    {
        Debug.Log("calculating");
        int sc = Score.GetComponent<ScoreScript>().calculatescore();
        textbox.text = "" + sc;
    }
}
