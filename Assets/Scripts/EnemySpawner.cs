using UnityEngine;

using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject EnemyPrefab;
    public Transform SpawnPoint;
    MeshRenderer Map;


    private void OnEnable() {
        Map = GameManager.Instance.Map;
        StartCoroutine(SpawnEnemies());
    }

    void OnDisable(){
        StopAllCoroutines();
    }

    IEnumerator SpawnEnemies() {
        Vector3 clampedArea = Map.bounds.extents - EnemyPrefab.GetComponent<MeshRenderer>().bounds.extents;
        while(enabled){
            
            float randomPositionX = SpawnPoint.position.x + Random.Range(-clampedArea.x,clampedArea.x);
            Vector3 randomPosition = SpawnPoint.position;
            randomPosition.x = randomPositionX;

            GameObject enemy = ObjectsPool.enemyPool.GetObject();
            enemy.transform.position = randomPosition;

            yield return new WaitForSeconds(Random.Range(2f,9f));
        }
    }
}