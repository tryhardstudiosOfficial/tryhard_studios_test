using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputfield;
    public void salir()
    {
        Application.Quit();
    }

    public void Jugar()
    {
        gameManager.Instance.set_Name(inputfield.text);
        SceneManager.LoadScene(1);
    }

}
