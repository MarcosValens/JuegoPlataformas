using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{

    public float groundSize;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 distance = mainCamera.transform.position - transform.position;
        if (groundSize <= distance.magnitude) {
            transform.position = new Vector3(mainCamera.transform.position.x, transform.position.y, transform.position.z);
        }
        /*if (groundSize <= (mainCamera.transform.position - transform.position).magnitude) {
            transform.position = new Vector3(mainCamera.transform.position.x, transform.position.y, transform.position.z);
        }*/
    }
}
