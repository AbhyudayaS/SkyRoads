using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float forwardSpeed = 20f;

    private GameManager gm;
    private Vector3 initLocation;

    private void Start()
    {
        initLocation = transform.position;       
        gm = GameManager.Instance;
        GameManager.onGameStart += Reset;
    }

    void Update()
    {       
        transform.position += transform.forward * forwardSpeed * Time.deltaTime * gm.CurrentGameSpeed;
    }

    private void Reset()
    {
        transform.position = initLocation;
     
    }
}
