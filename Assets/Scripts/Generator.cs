using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject originalObject;
    public float chance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rollSpawn();
    }

    private void rollSpawn()
    {
        float random = Random.Range(0.0f, 100.0f);
        if (random < chance)
        {
            GameObject.Instantiate(originalObject, transform.position, transform.rotation);
        };
    }
}
