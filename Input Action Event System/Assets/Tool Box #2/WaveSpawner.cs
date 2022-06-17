using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>(); // the enemies that will spawn in the scene

    public List<Transform> spawns = new List<Transform>(); // object positions that the enemies spawn at

    public List<GameObject> enemiesInScene = new List<GameObject>(); // enemies in a scene

    public BoolData shopOpenBoolData;

    public int EnemyCount; // amount of enemies in every wave

    int waveCount; // counts the waves in the game.

    public float spawnWait; // spawn an object between a certaint amount of time from spawn to spawn

    public float startWait; // wait a certaint amount of time to start spawning enemies

    public float waveWait; // after every wave is over wait a certaint amount of time to spawn in the new wave

    public AudioSource nextWaveSound; // after every wave play this sound

    public int amountOfEnemies; // number of enemies in the scene
    public int maxEnemies; // max number of enemies

    private float SpawnWaitDecrease;

    // Start is called before the first frame update
    void Start()
    {
        waveCount = 0;
       // StartCoroutine(Spawner()); // Coroutines can get IEnumerators to function
    }

    // Update is called once per frame
    void Update()
    {
        amountOfEnemies = enemiesInScene.Count;
        StartCoroutine(Spawner()); // Coroutines can get IEnumerators to function
    }

    IEnumerator Spawner() // use IEnumerators when you want have something to wait base on time
    {
        yield return new WaitForSeconds(startWait); // time it has to wait before doing the action
        // if there are no objects with the tag Enemy in the scene spawn more enemies.

        print(shopOpenBoolData.GetData());

        while (shopOpenBoolData.GetData())
        {
            if (amountOfEnemies <= 0 && amountOfEnemies <= maxEnemies)
            {
                waveCount++;
                
                if (nextWaveSound != null)
                {
                    nextWaveSound.Play();
                }

                // every wave one more enemy come
                maxEnemies++; 
                EnemyCount++;

                for (int i = 0; i < EnemyCount; i++)
                {
                    // get a random number between 0 and the number of objects in the objects array
                    int rand = Random.Range(0, objects.Count);

                    // get a random number between 0 and the number of spawns in the objects array
                    int randS = Random.Range(0, spawns.Count);

                    if (amountOfEnemies < i)
                    {
                        // this is getting a rand and rands ints and spawning a object at a position in the objects index
                        // and in the spawns index
                        GameObject instance = (GameObject)Instantiate(objects[rand], spawns[i-1].position, transform.rotation);                           
         
                       instance.transform.parent = transform;
                    }
                        
                    
                    // spawns an object after a certain amount of time is over
                    yield return new WaitForSeconds(spawnWait);

                }
            }
            yield return new WaitForSeconds(waveWait);
        }

    }
}
