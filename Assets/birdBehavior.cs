using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UnityEventInt : UnityEvent<string> { }
public class birdBehavior : MonoBehaviour
{
    public float birdWeight;
    public float jumpSpeed;
    public float horizontalSpeed;

    public UnityEventInt onScoreGain;
    public UnityEvent onGameOver;

    private bool isGamePaused;
    private bool isControlled;
    private int score;
    private float verticalSpeed;
    private float currentAngle;
    private GameObject lastPassedPipe;
    private int Score;

    // Start is called before the first frame update
    void Start()
    {
        verticalSpeed = 0;
        currentAngle = 0;
        isGamePaused = true;
        isControlled = false;
        score = 0;
        lastPassedPipe = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGamePaused)
        {
            // bird acceleration
            verticalSpeed -= birdWeight * 9.8f * Time.deltaTime;
            // jump detection
            if (Input.GetKeyDown("space") && isControlled)
                verticalSpeed = jumpSpeed;

            // falling angle computation
            float newAngle = Mathf.Atan(verticalSpeed) * Mathf.Rad2Deg / horizontalSpeed;
            float rotation = (newAngle - currentAngle);
            currentAngle = newAngle;

            // position + angle transfomation
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, verticalSpeed * Time.deltaTime, 0);
            gameObject.transform.RotateAround(gameObject.transform.position, Vector3.forward, rotation);

            // score detection
            List<GameObject> pipes = GameObject.Find("Background").GetComponent<pipesCreator>().PipesSetsList;
            foreach (GameObject i in pipes)
            {
                if (i.transform.position.x - gameObject.transform.position.x <= 0 && i != lastPassedPipe)
                {
                    lastPassedPipe = i;
                    score++;
                    onScoreGain.Invoke(score.ToString());
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision with pipe, game finished
        isControlled = false;
        gameObject.GetComponent<Animator>().speed = 0;
        onGameOver.Invoke();
    }

    public void StartGame()
    {
        isGamePaused = false;
        isControlled = true;
        gameObject.GetComponent<Animator>().speed = 1;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
