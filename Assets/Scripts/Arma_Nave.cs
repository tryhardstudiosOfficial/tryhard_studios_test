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
    private bool reloading;
    public void Disparar()
    {
        if (reloading) return;
        if (Balas_Cantidad_Actual <= 0) { reloading = true; StartCoroutine(Reload()); return; }
        Debug.Log("bang");
        Balas_Cantidad_Actual--;
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
