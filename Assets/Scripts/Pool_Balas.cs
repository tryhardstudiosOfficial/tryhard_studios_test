using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Pool_Balas : MonoBehaviour
{
    public static Pool_Balas instance;

    private void Awake()
    {
        if (Pool_Balas.instance != this && Pool_Balas.instance != null) Destroy(gameObject);
        if (Pool_Balas.instance == null) instance = this;

    }
    public void Limpiar()
    {
        foreach (GameObject b in balas) b.SetActive(false);
        foreach (GameObject pb in balas_player) pb.SetActive(false);
    }
    [SerializeField]
    private GameObject bala;
    [SerializeField]
    private List<GameObject> balas = new List<GameObject>();
    public void Invocar_Bala(Vector2 posicion)
    {
        if (balas.Count <= 0)
        {
            var primerbala =
            Instantiate(bala, posicion, bala.transform.rotation);


            balas.Add(primerbala);

            return;
        }

        foreach (GameObject b in balas)
        {
            if (!b.activeInHierarchy)
            {
                b.transform.position = posicion;

                b.SetActive(true);

                return;
            }
        }

        var nuevabala =
           Instantiate(bala, posicion, bala.transform.rotation);

        balas.Add(nuevabala);
    }



    [SerializeField]
    private GameObject bala_player;
    [SerializeField]
    private List<GameObject> balas_player = new List<GameObject>();
    public void disparar(Vector2 posicion)
    {
        if (balas_player.Count <= 0)
        {
            var primerbala =
            Instantiate(bala_player, posicion, bala_player.transform.rotation);


            balas_player.Add(primerbala);

            return;
        }

        foreach (GameObject b in balas_player)
        {
            if (!b.activeInHierarchy)
            {
                b.transform.position = posicion;

                b.SetActive(true);

                return;
            }
        }

        var nuevabala =
           Instantiate(bala_player, posicion, bala_player.transform.rotation);

        balas_player.Add(nuevabala);
    }

}
