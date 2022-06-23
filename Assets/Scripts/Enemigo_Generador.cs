using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Generador : MonoBehaviour
{
    public static Enemigo_Generador instance;

    private void Awake()
    {
        if (Enemigo_Generador.instance != null && Enemigo_Generador.instance != this) Destroy(gameObject);
        if (Enemigo_Generador.instance == null) instance = this;
    }
    public bool ON = true;
    private float range;
    [SerializeField]
    private float mintime;
    [SerializeField]
    private float maxtime;
    [SerializeField]
    private float timetosummon;
    [SerializeField]
    private float actualtime;

    [SerializeField]
    private GameObject Enemigo_Prefab;
    [SerializeField]
    private List<GameObject> Enemigos = new List<GameObject>();

    private void Start()
    {
        var camara = Camera.main;
        var camara_size = (camara.orthographicSize * camara.aspect);
        range = camara_size;

        timetosummon = Random.Range(mintime, maxtime);
    }
    public void restart()
    {
        if (ON) return;
        ON = true;
        timetosummon = Random.Range(mintime, maxtime);
        actualtime = 0;
    }
    void Update()
    {
        if (!ON) return;
        if(actualtime>= timetosummon)
        {
            summonEnemigo();
            timetosummon = Random.Range(mintime, maxtime);
            actualtime = 0;
        }
        actualtime += 1*Time.deltaTime;
    }


    private void summonEnemigo()
    {

       

        if (Enemigos.Count <= 0)
        {
            var primerEnemigo =
            Instantiate(Enemigo_Prefab, new Vector2(Random.Range(-range, range), range), Enemigo_Prefab.transform.rotation);

           
            Enemigos.Add(primerEnemigo);

            return;
        }

        foreach (GameObject enm in Enemigos)
        {
            if (!enm.activeInHierarchy)
            {
                enm.transform.position = new Vector2(Random.Range(-range, range), range);

                enm.SetActive(true);
                
                return;
            }
        }

        var enemigo =
           Instantiate(Enemigo_Prefab, new Vector2(Random.Range(-range, range), range), Enemigo_Prefab.transform.rotation);

        Enemigos.Add(enemigo);
     
    }


    public void DestroyAll()
    {
        foreach (GameObject enm in Enemigos) enm.SetActive(false);
    }
}
