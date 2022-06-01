using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject balaPrefab;
    
    public GameObject canon;
    public int cantidadBalas = 10;

    bool disparando = true;
    bool recargasndo = true;

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
        if (Input.GetButton("Fire1") ) 
        {
            if (disparando)
            {
                StartCoroutine(Disparar());
            }
        }
        if (Input.GetButton("Fire2")) 
        {
            if (recargasndo)
            {
                StartCoroutine(Recargar());
            }
        }
    }

    IEnumerator Disparar(){
        for (int i = 0; i < balas.Length; i++)
        {
            if (!balas[i].activeInHierarchy)
            {
                balas[i].SetActive(true);
                balas[i].transform.position = canon.transform.position;
                break;
            }
                 
        }
        if (balas[9].activeInHierarchy)
        {
            StartCoroutine(Recargar());
        }
        disparando = false;
        yield return new WaitForSeconds(0.5f);
        disparando = true;
    }

    IEnumerator Recargar(){
        recargasndo = false;
        yield return new WaitForSeconds(2);
        recargasndo = true;
        for (int i = 0; i < balas.Length; i++)
        {
            balas[i].SetActive(false);
        }
    }
}
