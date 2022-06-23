using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    [SerializeField]
    private GameObject player;
    [Header("GAMEUI")]
    [SerializeField]
    private int puntos_actuales;
    [SerializeField]
    private TMP_Text puntos;
    [SerializeField]
    private TMP_Text puntosmax;
    [Header("GAMEOVERUI")]
    [SerializeField]
    private TMP_Text high;
    [SerializeField]
    private TMP_Text now;
    private void Start()
    {
        Canvas_juego.SetActive(true);
        Canvas_resultado.SetActive(false);
        puntosmax.text = "HighScore:" + gameManager.Instance.get_max();
    }


    public void volver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    private void GAMEOVER()
    {
        player.SetActive(false);
        balas.Limpiar();
        items.limpiar();
        items.ON = false;
        enemigos.DestroyAll();
        enemigos.ON = false;
        Canvas_juego.SetActive(false);
        Canvas_resultado.SetActive(true);
        high.text = gameManager.Instance.get_name()+ ": "+gameManager.Instance.get_max();
        now.text = gameManager.Instance.get_player() + ": " +puntos_actuales;
    }
    public void checkend(int vida)
    {
        if (vida <= 0) GAMEOVER();
    }
    public void Restart()
    {
        balas.Limpiar();
        items.limpiar();
        enemigos.DestroyAll();
        Canvas_juego.SetActive(true);
        Canvas_resultado.SetActive(false);
        player.SetActive(true);
        player.transform.position = Vector3.zero;
        items.restart();
        enemigos.restart();
        puntos_actuales = 0;
        puntos.text = "Puntos:" + puntos_actuales;
        puntosmax.text = "HighScore:" + gameManager.Instance.get_max();
    }

    public void SumarPuntos()
    {
        
        puntos_actuales++;
        puntos.text = "Puntos:" + puntos_actuales;
        gameManager.Instance.Set_Highscore(puntos_actuales);
        puntosmax.text = "HighScore:" + gameManager.Instance.get_max();
       
        
    }
}
