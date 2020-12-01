using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private float seconds;

    private void OnEnable()
    {
        Destroy(this.gameObject, seconds);
    }    
}
