using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdBehavior : MonoBehaviour
{
    public float birdWeight;
    public float jumpSpeed;

    private float verticalSpeed;
    private float currentAngle;
    // Start is called before the first frame update
    void Start()
    {
        verticalSpeed = 0;
        currentAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        verticalSpeed -= birdWeight * 9.8f; 
        if (Input.GetKeyDown("space"))
            verticalSpeed = jumpSpeed;

        float newAngle  = Mathf.Atan(verticalSpeed) * 1000;
        float rotation = newAngle - currentAngle;
        currentAngle = newAngle;             
        
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, verticalSpeed, 0);
        gameObject.transform.RotateAround(gameObject.transform.position, Vector3.forward, rotation);
    }
}
