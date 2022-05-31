using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public GameObject balaPrefab;
    
    public GameObject canon;

    public int cadencia = 2; 
    public int cantidadBalas = 10;
    bool shot = true;

    GameObject[] balas;

    void Awake(){
        balas = new GameObject[cantidadBalas];
        
        for (int i = 0; i < balas.Length; i++)
        {
            balas[i] = (GameObject)Instantiate(balaPrefab);
        }
    }
    void Update()
    {
        if (shot)
        {
            StartCoroutine(Disparar());
        }
    }

    IEnumerator  Disparar(){
        for (int i = 0; i < balas.Length; i++)
        {
            if (!balas[i].activeInHierarchy)
            {
                balas[i].SetActive(true);
                balas[i].transform.position = canon.transform.position;
                break;
            }
        }
        shot = false;
        yield return new WaitForSeconds(cadencia);
        shot = true;
    }
}
