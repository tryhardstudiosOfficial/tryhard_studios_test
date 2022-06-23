using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;

        }

        DontDestroyOnLoad(this.gameObject);
    }

    private string nombre_puntuacion_maxima;
    private int puntuacion_maxima;
    private string nombre_Actual;
    public void set_Name(string namefield)
    {
        nombre_Actual = namefield;
    }

    public void Set_Highscore(int puntuacion)
    {
        if (puntuacion < puntuacion_maxima) return;

        puntuacion_maxima = puntuacion;
        nombre_puntuacion_maxima = nombre_Actual;
    }
}
