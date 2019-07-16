using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowPool : MonoBehaviour
{
    public int crowPoolSize = 5;
    public GameObject crowPrefab;
    public float spawnRate = 4f;
    public float crowMin = -1f;
    public float crowMax = 3.5f;

    private GameObject[] crows;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 8f;
    private int currentCrow = 0;

    // Start is called before the first frame update
    void Start()
    {
        crows = new GameObject[crowPoolSize];
        for (int i = 0; i < crowPoolSize; i++)
        {
            crows[i] = (GameObject)Instantiate(crowPrefab, objectPoolPosition, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (!GameController.instance.gameOver && (timeSinceLastSpawned >= spawnRate))
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(crowMin, crowMax);
            crows[currentCrow].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentCrow++;
            if(currentCrow >= crowPoolSize)
            {
                currentCrow = 0;
            }
        } 
    }
}
