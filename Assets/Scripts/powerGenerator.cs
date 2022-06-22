using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] powers;

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

     void SpawnPower(Vector2 startPos){
          int randomIndex = UnityEngine.Random.Range(0, powers.Length);
         GameObject power = Instantiate(powers[randomIndex],this.transform);

         float startX = UnityEngine.Random.Range(startPos.x - 5f, startPos.x + 5f);
         power.transform.position = new Vector2(startX, startPos.y);

         float scale = UnityEngine.Random.Range(1.1f,1.5f);
         power.transform.localScale = new Vector2(scale,scale);

         float gravity = UnityEngine.Random.Range(0.1f,0.2f);
         power.GetComponent<Rigidbody2D>().gravityScale = gravity;
         power.GetComponent<powerScript>().StartFloating(endPoint.transform.position.y);

         int powerTypeRandom = UnityEngine.Random.Range(1,6);
         switch(powerTypeRandom){
            case 1: power.GetComponent<powerScript>().powerType = powerScript.PowerType.Limpiador;
            power.GetComponent<SpriteRenderer>().color = Color.blue;
            break;
            case 2: power.GetComponent<powerScript>().powerType = powerScript.PowerType.Curador;
            power.GetComponent<SpriteRenderer>().color = Color.green;
            break;
            case 3: power.GetComponent<powerScript>().powerType = powerScript.PowerType.Invencibilidad;
            power.GetComponent<SpriteRenderer>().color = Color.magenta;
            break;
            case 4: power.GetComponent<powerScript>().powerType = powerScript.PowerType.Descontrol;
            power.GetComponent<SpriteRenderer>().color = Color.black;
            break;
            case 5: power.GetComponent<powerScript>().powerType = powerScript.PowerType.Aniquilador;
            power.GetComponent<SpriteRenderer>().color = Color.red;
            break;
         }
     }

     void AttemptSpawn(){
         //check some things.
         SpawnPower(startPos);

        Invoke("AttemptSpawn", spawnInterval);
     }

     void Prewarm(){
         for (int i = 0; i < 2; i++){
             Vector2 spawnPos = Vector2.right * (i * 2) + startPos;
             SpawnPower(spawnPos);
         }
     }
     
}
