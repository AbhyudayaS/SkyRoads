using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreText : MonoBehaviour
{   
    private GameManager gm;
    
    private TMP_Text scoreText;
    private float scoreMultiplier;  

    private void Start()
    {
        gm = GameManager.Instance;
        scoreText = GetComponent<TMP_Text>();
        scoreMultiplier = GameManager.Instance.CurrentGameSpeed;       
    }
       
    // Update is called once per frame
    void Update()
    {
        if(gm.startGame)
        {           
            scoreText.text = gm.Score.ToString();
        }  
        
    }
}
