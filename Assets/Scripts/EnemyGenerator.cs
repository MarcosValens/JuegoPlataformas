using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rollEnemy();
    }

    private void rollEnemy()
    {
        float random = Random.Range(0.0f, 100.0f);
        if (random < 1.0f) 
        {
            GameObject.Instantiate(enemy, transform.position, transform.rotation);
        };
    }
}
