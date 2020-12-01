using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{    
    [SerializeField]
    private float disableAfterSeconds = 40f;
    private float time = 0f;

    

    private void Start()
    {

        GameManager.onGameStart += Reset;
    }

    private void Reset()
    {
        time = 0f;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(GameManager.Instance.CurrentGameSpeed!= 0)
        {
            if(time > disableAfterSeconds / GameManager.Instance.CurrentGameSpeed)
            {
                Deactivate();
                time = 0f;
            }
        }
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
