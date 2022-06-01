using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPD : MonoBehaviour
{
    public float min_X;
    public float max_X;
    public float min_Tiempo;
    public float max_Tiempo;
    public GameObject[] pdPrefab;

    bool spawn = true;

    Vector2 posicionPD;

    void Update()
    {
        if (spawn)
        {
            StartCoroutine(SpawnearPD());
        } 
    }
    IEnumerator SpawnearPD()
    {
        int index = Random.Range(1, pdPrefab.Length);
        float frecuencia = Random.Range(min_Tiempo, max_Tiempo);
        posicionPD = new Vector2(Random.Range(min_X, max_X), 10);
        Instantiate(pdPrefab[index-1], posicionPD, Quaternion.identity);
        spawn = false;
        yield return new WaitForSeconds(frecuencia);
        spawn = true;
    }
}
