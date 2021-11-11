using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawner : MonoBehaviour   
{
    [SerializeField] float spawningSphereRadius = 0.9f;


    // Start is called before the first frame update
    void Start()
    {
        GameObject token = ObjectPool.instance.GetPooledObject();

        if (token != null) 
        {
            // Create a Random Position
            Vector3 randomSpawnPos = new Vector3(Random.Range(0, spawningSphereRadius), Random.Range(0, spawningSphereRadius), Random.Range(0, spawningSphereRadius));

            token.transform.position = randomSpawnPos;
            token.SetActive(true);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
