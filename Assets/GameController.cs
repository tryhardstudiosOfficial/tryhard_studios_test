using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
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
    }
    [SerializeField]
    private GameObject Canvas_resultado;
    [SerializeField]
    private GameObject Canvas_juego;

    [SerializeField]
    private Pool_Balas balas;
    [SerializeField]
    private Item_Generador items;
    [SerializeField]
    private Enemigo_Generador enemigos;
    private void Start()
    {
        Canvas_juego.SetActive(true);
        Canvas_resultado.SetActive(false);
    }



    private void GAMEOVER()
    {
        balas.Limpiar();
        items.limpiar();
        enemigos.DestroyAll();
        Canvas_juego.SetActive(false);
        Canvas_resultado.SetActive(true);
    }

    public void Restart()
    {
        balas.Limpiar();
        items.limpiar();
        enemigos.DestroyAll();
        Canvas_juego.SetActive(true);
        Canvas_resultado.SetActive(false);
    }
}
