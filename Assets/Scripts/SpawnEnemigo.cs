using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigo : MonoBehaviour
{

    public float min_X;
    public float max_X;
    public GameObject enemigoPrefab;
    public int cantidadEnemigos;

    public int frecuencia;

    bool spawn = true;

    Vector2 posicionEnemigo;
    GameObject[] enemigos;
    
    void Update()
    {
        if (spawn)
        {
            StartCoroutine(SpawnearEnemigos());
        } 
    }
    IEnumerator SpawnearEnemigos()
    {
        posicionEnemigo = new Vector2(Random.Range(min_X, max_X), 10);
        Instantiate(enemigoPrefab, posicionEnemigo, Quaternion.identity);
        spawn = false;
        yield return new WaitForSeconds(frecuencia);
        spawn = true;
    }
}
