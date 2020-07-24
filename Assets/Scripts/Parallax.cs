using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public Renderer[] waves;
    public float[] waveSpeed;
    public GameObject[] backgrounds;
    public float[] backgroundSpeed;
    public float[] sizes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveWaves();
        MoveBackground();
    }

    private void MoveWaves() {
        for (int i = 0; i < waves.Length; i++)
        {
            float offset = Time.time * waveSpeed[i];
            waves[i].material.SetTextureOffset("_MainTex", new Vector2(offset, 0.0f));
        }
    }

    private void MoveBackground() {

        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (Mathf.Abs(backgrounds[i].transform.localPosition.x) >= sizes[i])
            {
                //returning background to initial position
                backgrounds[i].transform.localPosition = new Vector3(0.0f, backgrounds[i].transform.localPosition.y, backgrounds[i].transform.localPosition.z);
            }
            else {

                //movinf background
                float offset = Time.deltaTime * backgroundSpeed[i];
                backgrounds[i].transform.localPosition += new Vector3(offset, 0.0f);
            }
        }
    }
}
