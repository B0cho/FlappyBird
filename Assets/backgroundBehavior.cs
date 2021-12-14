using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundBehavior : MonoBehaviour
{
    private float halfCameraWidth;
    private Vector3 initPos;
    public float backgroundSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        halfCameraWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        initPos = new Vector3(3 * halfCameraWidth, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= -halfCameraWidth)
            gameObject.transform.position = initPos;
        else
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - backgroundSpeed, initPos.y, initPos.z);
    }
}
