using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class PowerItemSpawner : MonoBehaviour {

    public List<GameObject> PowerUpPrefabs;
    public List<GameObject> PowerDownPrefabs;
    public Transform SpawnPoint;
    MeshRenderer Map;
    Player player;

    public void StartSpawning() {
        player = GameManager.Instance.Player.GetComponent<Player>();
        Map = GameManager.Instance.Map;
        StartCoroutine(SpawnPowerUpItems());
        StartCoroutine(SpawnPowerDownItems());
    }

    void OnDisable(){
        StopAllCoroutines();
    }

    IEnumerator SpawnPowerUpItems() {
        Vector3 clampedArea = Map.bounds.extents - PowerUpPrefabs[0].GetComponentInChildren<MeshRenderer>().bounds.extents;
        yield return new WaitForSeconds(Random.Range(15f,20f));
        while(enabled){
            
            float randomPositionX = SpawnPoint.position.x + Random.Range(-clampedArea.x,clampedArea.x);
            Vector3 randomPosition = SpawnPoint.position;
            randomPosition.x = randomPositionX;

            //Restamos 1 al total de power items, para quitar el buff de salud, si la vida no es < 3
            //El primer indice de la lista de items es el Power Up de Curacion
            int startIndex = player.Lives < 3 ? 0 : 1;
            GameObject.Instantiate(PowerUpPrefabs[Random.Range(startIndex, PowerUpPrefabs.Count)], randomPosition, SpawnPoint.rotation);

            yield return new WaitForSeconds(Random.Range(15f,20f));
        }
    }

    IEnumerator SpawnPowerDownItems() {
        Vector3 clampedArea = Map.bounds.extents - PowerDownPrefabs[0].GetComponentInChildren<MeshRenderer>().bounds.extents;
        yield return new WaitForSeconds(Random.Range(12f,15f));
        while(enabled){
            
            float randomPositionX = SpawnPoint.position.x + Random.Range(-clampedArea.x,clampedArea.x);
            Vector3 randomPosition = SpawnPoint.position;
            randomPosition.x = randomPositionX;

            GameObject.Instantiate(PowerDownPrefabs[Random.Range(0, PowerDownPrefabs.Count)], randomPosition, SpawnPoint.rotation);
            yield return new WaitForSeconds(Random.Range(12f,15f));
        }
    }
}