using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public GameObject coin;
    public float chance;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rollCoin();
    }

    private void rollCoin()
    {
        float random = Random.Range(0.0f, 100.0f);
        if (random < chance)
        {
            GameObject.Instantiate(coin, transform.position, transform.rotation);
        };
    }
}
