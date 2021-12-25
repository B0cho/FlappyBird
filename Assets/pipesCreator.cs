using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipesCreator : MonoBehaviour
{
    public float pipeSpeed;

    private float halfCameraWidth;
    private Vector2 bottomPipeInitPos;

    // Start is called before the first frame update
    void Start()
    {
        halfCameraWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        bottomPipeInitPos = new Vector2(halfCameraWidth + 100, 0);

    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
