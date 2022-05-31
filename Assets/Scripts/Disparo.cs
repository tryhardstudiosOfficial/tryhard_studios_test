using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject balaPrefab;
    
    public GameObject canon;
    public int cantidadBalas = 10;

    bool disparando = true;
    

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
        }disparando = false;
        yield return new WaitForSeconds(1);
        disparando = true;
    }    
}
