using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipesCreator : MonoBehaviour
{
    public float pipeSpeed;
    public int pipesInterval;
    public GameObject pipesSetPrefab;

    private float halfCameraWidth;
    private Vector3 pipeSetInitPos;
    private List<GameObject> pipesSetsList;
    private bool isPaused;
    public List<GameObject> PipesSetsList { get => pipesSetsList; }
    public void OnPause()
    {
        isPaused = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        pipesSetsList = new List<GameObject>();
        halfCameraWidth = Camera.main.orthographicSize * Screen.width / Screen.height + 2;
        pipeSetInitPos = new Vector3(halfCameraWidth, 0, -2);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPaused)
        {
            // pipes instatation
            if (pipesSetsList.Count < 4)
            {
                // randomize y-position
                float yPosition = Random.Range(-2f, 2f);
                Vector3 newPosition = (pipesSetsList.Count == 0) ?
                    pipeSetInitPos + new Vector3(0, yPosition, 0) : // when creating first pipe set
                    new Vector3(pipesSetsList[pipesSetsList.Count - 1].transform.position.x + pipesInterval, yPosition, 0); // creating upcoming pipes
                pipesSetsList.Add(InstantiatePipes(newPosition));
            }

            // updated of pipes position + finding passed pipes set
            GameObject passedPipes = null;
            foreach (GameObject i in pipesSetsList)
            {
                // move
                i.transform.position = new Vector3(i.transform.position.x - pipeSpeed * Time.deltaTime, i.transform.position.y, i.transform.position.z);
                // passed pipe
                if (i.transform.position.x < -halfCameraWidth)
                    passedPipes = i;
            }

            // destroying passed pipes
            if (passedPipes != null)
            {
                pipesSetsList.Remove(passedPipes);
                Destroy(passedPipes);
            }
        }
    }

    private GameObject InstantiatePipes(Vector3 position)
    {
        GameObject pipes = Instantiate(pipesSetPrefab);
        pipes.transform.position = new Vector3(position.x, position.y, pipes.transform.position.z);
        return pipes;
    }
}
