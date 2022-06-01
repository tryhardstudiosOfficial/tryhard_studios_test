using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigo : MonoBehaviour
{
    public float min_X;
    public float max_X;
    public float min_Tiempo;
    public float max_Tiempo;
    public GameObject enemigoPrefab;

    bool spawn = true;

    Vector2 posicionEnemigo;

    void Update()
    {
        if (spawn)
        {
            StartCoroutine(SpawnearEnemigos());
        } 
    }
    IEnumerator SpawnearEnemigos()
    {
        float frecuencia = Random.Range(min_Tiempo, max_Tiempo);
        posicionEnemigo = new Vector2(Random.Range(min_X, max_X), 10);
        Instantiate(enemigoPrefab, posicionEnemigo, Quaternion.identity);
        spawn = false;
        yield return new WaitForSeconds(frecuencia);
        spawn = true;
    }
}
