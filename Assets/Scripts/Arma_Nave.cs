using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma_Nave : MonoBehaviour
{
    [SerializeField]
    private int Balas_Cantidad_maxima;
    [SerializeField]
    private int Balas_Cantidad_Actual;
    [SerializeField]
    private float Reload_Tiempo_total;
    private float Reload_time;
    [SerializeField]
    private float enfriamiento = 0;
    [SerializeField]
    private bool reloading;


    public void Disparar()
    {
        if (reloading || enfriamiento > 0) return;
        if (Balas_Cantidad_Actual <= 0) { reloading = true; StartCoroutine(Reload()); return; }
        Pool_Balas.instance.disparar(this.transform.position);
        enfriamiento += 0.5f;
        Balas_Cantidad_Actual--;
    }

    private void Update()
    {
        if(enfriamiento>0)
        enfriamiento -= Time.deltaTime;
    }
    private IEnumerator Reload()
    {
        Debug.Log("reloading");
        while (Reload_time < Reload_Tiempo_total)
        {
            yield return null;
            Reload_time += 1 * Time.deltaTime;   
        }
        Balas_Cantidad_Actual = Balas_Cantidad_maxima;
        Debug.Log("full reload");
        reloading = false;
        Reload_time = 0;
        yield return null;
    }
}
