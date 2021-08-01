using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public Text cherryText;
    private int score;
    public int Score 
    { 
        get { return score; }
        set { 
            score = value;
            cherryText.text = score.ToString();
        } 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
