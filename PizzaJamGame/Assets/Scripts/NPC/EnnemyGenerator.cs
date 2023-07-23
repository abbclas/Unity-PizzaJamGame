using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyGenerator : MonoBehaviour
{

    /*
     * This is a Bahviour for generating ennemies around the player
     */


    // Public
    public Transform playerPosition;         
    public GameObject EnnemyPool;

    // Private
    [SerializeField] private float spawningRate;
    [SerializeField] private float spawningTime;
    private float timer;
    [SerializeField] private float spawnDistanceRange;
    [SerializeField] private float actualHeight;
    [SerializeField] private EnemySO enemySO;

    
    private void Awake()
    {
        
        #region Exception

        if (spawningRate > 1)
        {
            Debug.Log("A rate mathematically cannot be more than 1");
            throw new System.Exception("A rate mathematically cannot be more than 1");
        }  
        
        #endregion
        
    }

    private void Start()
    {
        timer = spawningTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            if (Random.Range(0f, 1f) < spawningRate)
            {
                SpawnANewEnnemy();
                timer = spawningTime;      // Get back the timer
            }
        }
    }


    private void SpawnANewEnnemy()
    {
        GameObject newEnnemy = EnnemyPool.GetComponent<EnnemyPoolingSystem>().GetPooledObject();


        if (newEnnemy != null)
        {
            if(newEnnemy.GetComponent<RogueRobotsManager>().HP <= 0)
            {
                newEnnemy.GetComponent<RogueRobotsManager>().HP = enemySO.MaxHP;
            }
            // The random position
            float randomAngle = Random.Range(0f, 2 * Mathf.PI);
            float randomX = playerPosition.position.x + spawnDistanceRange * Mathf.Cos(randomAngle);
            float randomZ = playerPosition.position.z + spawnDistanceRange * Mathf.Sin(randomAngle);

            newEnnemy.transform.position = new Vector3(randomX, actualHeight, randomZ);


            newEnnemy.SetActive(true);

        }
    }
}
