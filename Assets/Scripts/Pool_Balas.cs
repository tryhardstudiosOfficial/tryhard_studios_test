using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Pool_Balas : MonoBehaviour
{
    public static Pool_Balas instance;

    private void Awake()
    {
        if (Pool_Balas.instance != this) Destroy(gameObject);
        if (Pool_Balas.instance == null) instance = this;

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
}
