using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPooler : MonoBehaviour
{
    public static PlatformPooler Instance{ get; set; }

    [SerializeField]
    private List<GameObject> platformsPrefabs;
    [SerializeField]
    private int amountToPool;
   
    private List<GameObject> platformPooled;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        platformPooled = new List<GameObject>();

        for(int i = 0; i < amountToPool;  i++)
        {
            GameObject obj = (GameObject)Instantiate(platformsPrefabs[Random.Range(0, platformsPrefabs.Count)]);           
            obj.SetActive(false);
            platformPooled.Add(obj);
        }       
    }

    public GameObject GetPooledObject()
    {
        //for(int i = 0; i< platformPooled.Count; i++)
        int i = Random.Range(0, platformPooled.Count);
        {
           if(!platformPooled[i].activeInHierarchy)
             {
                return platformPooled[i];
            }
            else
            {
                return GetPooledObject();
            }
        }       
    }

    public void DeactivateAllObject()
    {
        foreach (var item in platformPooled)
        {
            item.SetActive(false);
        }
    }
}
