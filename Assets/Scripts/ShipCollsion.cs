using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollsion : MonoBehaviour
{    

    public delegate void OnCollision();
    public static event OnCollision onCollision;

    // Start is called before the first frame update
    void Start(){
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        transform.parent.gameObject.SetActive(false);
        onCollision();
    }
}
