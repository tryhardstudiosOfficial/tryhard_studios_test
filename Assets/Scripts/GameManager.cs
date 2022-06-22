using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager current;

    public GameObject menuPrincipal;
    public GameObject menuGameOver;
    public GameObject asteroidGenerator;
    public GameObject enemyGenerator;

    public static int Score = 0;
    public string ScoreString = "time";
    public Text TextScore;
    public static GameManager Gamemanager;
    public float timer;

    public float velocidad = 2;
    public GameObject asteroide1;
    public GameObject asteroide2;

    //public GameObject col;

    public Renderer fondo;
    public bool gameOver = false;
    public List<GameObject> cols;
    public List<GameObject> obstaculos;

    public bool start = false;

    [SerializeField] private Text BronzeCoinsTxt;
    private int bronzeCoins;

    public static void sumCoin(string type, int quantity)
    {
        if (type == "bronze")
        {
            current.bronzeCoins = current.bronzeCoins + quantity;
            current.BronzeCoinsTxt.text = current.bronzeCoins.ToString();
        }
    }

    void Awake()
    {
        current = this;
        Gamemanager = this;
    }


    // Start is called before the first frame update
    void Start()
    {

        Screen.SetResolution(240, 180, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
                Score = 0;
                timer = 0;
                asteroidGenerator.SetActive(true);
                enemyGenerator.SetActive(true);
            }
        }

        if (start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                GameObject.Destroy(enemy);
            }
            asteroidGenerator.SetActive(false);
            enemyGenerator.SetActive(false);


            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


        if (start == true && gameOver == false)
        {
            //Tiempo cuando el juego empieza.
            timer += Time.deltaTime;

            if (timer > 2f)
            {
                //Score += 1;
                //Reset the timer to 0.
                timer = 0;
            }

            menuPrincipal.SetActive(false);

            // mover fondo
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.005f, 0) * Time.deltaTime;
        }

        if (TextScore != null)
        {
            TextScore.text = ScoreString + ": " + Score.ToString();
        }
    }

    public void sumScore(int num)
    {
        Score = Score + num;
    }
}
