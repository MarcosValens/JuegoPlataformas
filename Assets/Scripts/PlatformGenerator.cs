using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject platform;
    public float chance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rollPlatform();
    }

    private void rollPlatform()
    {
        float random = Random.Range(0.0f, 100.0f);
        if (random < chance)
        {
            GameObject.Instantiate(platform, transform.position, transform.rotation);
        };
    }
}
