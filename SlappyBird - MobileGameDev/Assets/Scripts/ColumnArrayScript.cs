using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnArrayScript : MonoBehaviour
{
    public int columnArraySize = 5;
    //public GameObject columnPrefab;
    public float spawnRate = 4f;
    public float columnMin = -2f;
    public float columnMax = 2.5f; 
    
    [SerializeField] GameObject[] columns;
    private int currentColumn;
    private Vector2 objectArrayPosition = new Vector2(-15f, -25f);
    private float spawnXPosition = 10f;
    private float timeSinceLastRespawn;

    // Start is called before the first frame update
    void Start()
    {
        // columns = new GameObject[columnArraySize];
        // for(int i = 0; i < columnArraySize; i++)
        // {
            // int pickAColumn = Random.Range(0, columnArraySize); //This is my own thing bcos I wanted to spawn them differently
            //columns[i] = (GameObject)Instantiate(columns[pickAColumn], objectArrayPosition, Quaternion.identity);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastRespawn += Time.deltaTime;
        if(GameManagerScript.instance.gameOver == false && timeSinceLastRespawn >= spawnRate)
        {
            timeSinceLastRespawn = 0f;
            currentColumn = Random.Range(0, columnArraySize - 1); //This is my own thing bcos I wanted to spawn them differently
            //I don't need this for the way I'm doing it...
            //float spawnYPosition = Random.Range(columnMin, columnMax);

            //Modified this
            Instantiate(columns[currentColumn], new Vector2(spawnXPosition, 0f), Quaternion.identity);
            //columns[currentColumn].transform.position = new Vector2(spawnXPosition, 1.6f); //1.6 happens to be the height I need the columns at

            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            //currentColumn ++;

            // if (currentColumn >= columnArraySize) 
            // {
                // currentColumn = 0;
            // }
        }
    }
}
