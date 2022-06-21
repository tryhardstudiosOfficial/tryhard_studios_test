using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGeneratorScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemys;

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

     void SpawnEnemy(Vector2 startPos){
         int randomIndex = UnityEngine.Random.Range(0, enemys.Length);
         GameObject enemy = Instantiate(enemys[randomIndex],this.transform);

         float startX = UnityEngine.Random.Range(startPos.x - 5f, startPos.x + 5f);
         enemy.transform.position = new Vector2(startX, startPos.y);

         float scale = UnityEngine.Random.Range(0.5f,0.7f);
         enemy.transform.localScale = new Vector2(scale,scale);

         float gravity = UnityEngine.Random.Range(0.1f,0.2f);
         enemy.GetComponent<Rigidbody2D>().gravityScale = gravity;
         enemy.GetComponent<enemyScript>().StartFloating(endPoint.transform.position.y);
     }

     void AttemptSpawn(){
         //check some things.
         SpawnEnemy(startPos);

        Invoke("AttemptSpawn", spawnInterval);
     }

     void Prewarm(){
         for (int i = 0; i < 1; i++){
             Vector2 spawnPos = Vector2.right * (i * 2) + startPos;
             SpawnEnemy(spawnPos);
         }
     }
     
}
