using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; set; }

    [SerializeField]
    public float gameSpeedMin = 0;
    [SerializeField]
    public float gameSpeedMax = 0;
    [SerializeField]
    public GameObject ExplosionVFX;

    private GameObject Player;

    public float CurrentGameSpeed { get; set; }
   

    public bool startGame { get; set; }

    public delegate void OnGameStart();
    public static event OnGameStart onGameStart;
    public static event OnGameStart onGameEnd;

    public int Score { get; set; }
    public int HighScore{ get; set; }

    float timer = 0.0f;
    int seconds;

    private void Awake()
    {
        Instance = this;
        CurrentGameSpeed = 0;        
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        startGame = false;
        ShipCollsion.onCollision += ResetLevel;
        ShipCollsion.onCollision += PlayShipVFX;
        StartCoroutine(WaitForSpace());
    }

    private void PlayShipVFX()
    {
        Instantiate(ExplosionVFX, Player.transform.position, Quaternion.identity);
    }

    IEnumerator WaitForSpace()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        GameStart();
    }

    private void GameStart()
    {
        onGameStart();
        CurrentGameSpeed = gameSpeedMin;
        startGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            timer += Time.deltaTime * CurrentGameSpeed;
            Score = Convert.ToInt32(timer);

            if(CurrentGameSpeed< gameSpeedMax)
                CurrentGameSpeed += Time.deltaTime / 500;

            Debug.Log(CurrentGameSpeed);
        }
    }
    

    public void ResetLevel()
    {       
        onGameEnd();
        CurrentGameSpeed = 0;
        startGame = false;
        timer = 0;
        StartCoroutine(WaitForSpace());
    }
}
