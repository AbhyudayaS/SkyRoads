using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject platform0;

    [SerializeField]
    private GameObject startPlatform;

    private Transform previousPlatform;
    private GameManager gm;

    private float spawnTimer;
    [SerializeField] private float spawnTimerMax = 1f;

   
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        GameManager.onGameStart += Reset;
    }

    private void Reset()
    {
        startPlatform.SetActive(true);
        previousPlatform = platform0.transform;
        PlatformPooler.Instance.DeactivateAllObject();
    }

    private void Update()
    {
        if (gm.startGame)
        {
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
            }
            else
            {
                spawnTimer = spawnTimerMax / gm.CurrentGameSpeed;
                InstantiatePlatforms();
            }
        }
    }

    private void InstantiatePlatforms()
    {
        GameObject platform = PlatformPooler.Instance.GetPooledObject();
        if (platform != null)
        {
            platform.transform.position = new Vector3(0, 0, previousPlatform.position.z + 80);
            previousPlatform = platform.transform;
            platform.SetActive(true);
        }
    }
}


