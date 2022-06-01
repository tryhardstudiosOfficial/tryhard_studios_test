using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPU : MonoBehaviour
{
    public float min_X;
    public float max_X;
    public float min_Tiempo;
    public float max_Tiempo;
    public GameObject[] puPrefab;

    bool spawn = true;

    Vector2 posicionPU;

    void Update()
    {
        if (spawn)
        {
            StartCoroutine(SpawnearEnemigos());
        } 
    }
    IEnumerator SpawnearEnemigos()
    {
        int index = Random.Range(1, puPrefab.Length);
        float frecuencia = Random.Range(min_Tiempo, max_Tiempo);
        posicionPU = new Vector2(Random.Range(min_X, max_X), 10);
        Instantiate(puPrefab[index-1], posicionPU, Quaternion.identity);
        spawn = false;
        yield return new WaitForSeconds(frecuencia);
        spawn = true;
    }
}
