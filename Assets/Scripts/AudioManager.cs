using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource destroyed;
    // Start is called before the first frame update
    void Start()
    {
        ShipCollsion.onCollision += DestroySound;
    }

    private void DestroySound()
    {
        destroyed.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
