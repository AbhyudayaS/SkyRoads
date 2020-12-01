using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HighScore : MonoBehaviour
{
    private GameManager gm;

    private TMP_Text scoreText;
    private float scoreMultiplier;    

    private void Start()
    {
        gm = GameManager.Instance;
        scoreText = GetComponent<TMP_Text>();
        scoreMultiplier = GameManager.Instance.CurrentGameSpeed;
        scoreText.text = $"Score: 0";
        GameManager.onGameEnd += SetScore;
    }

    private void SetScore()
    {
        scoreText.text = $"Score: {gm.Score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
