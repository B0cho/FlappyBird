using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class statesManager : MonoBehaviour
{
    public UnityEvent startGame;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            startGame.Invoke();
            gameObject.SetActive(false);
        }
    }
}
