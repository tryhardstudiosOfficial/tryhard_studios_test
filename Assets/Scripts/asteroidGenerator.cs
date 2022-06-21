using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] asteroids;

    [SerializeField]
    float spawnInterval;

    [SerializeField]    
    GameObject endPoint;

    Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Prewarm();
        Invoke("AttemptSpawn", spawnInterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        startPos = transform.position;

        
    }

     void SpawnAsteroid(Vector2 startPos){
         int randomIndex = UnityEngine.Random.Range(0, asteroids.Length);
         GameObject asteroid = Instantiate(asteroids[randomIndex],this.transform);

         float startX = UnityEngine.Random.Range(startPos.x - 5f, startPos.x + 5f);
         asteroid.transform.position = new Vector2(startX, startPos.y);

         float scale = UnityEngine.Random.Range(0.3f,0.6f);
         asteroid.transform.localScale = new Vector2(scale,scale);

         float gravity = UnityEngine.Random.Range(0.3f,0.7f);
         asteroid.GetComponent<Rigidbody2D>().gravityScale = gravity;
     }

     void AttemptSpawn(){
         //check some things.
         SpawnAsteroid(startPos);

        Invoke("AttemptSpawn", spawnInterval);
     }

     void Prewarm(){
         for (int i = 0; i < 5; i++){
             Vector2 spawnPos = Vector2.right * (i * 2) + startPos;
             SpawnAsteroid(spawnPos);
         }
     }
     
}
