using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida_nave : MonoBehaviour
{
    [SerializeField]
    private int Vida = 3;

    private bool shield = false;
    private float shieldtime;
    [SerializeField]
    TMPro.TMP_Text vidaui;
    [SerializeField]
    TMPro.TMP_Text shieldui;
    public void Damage(int cantidad)
    {
        if (cantidad > 0 && shield) return;
        Vida -= cantidad;

        vidaui.text = "Vida: "+Vida;
        GameController.Instance.checkend(Vida);
    } 
    public int VidaAmount()
    {
        return Vida;
    }
    public void ActivateShield()
    {
        shield = true;
        shieldtime = 10;
        StartCoroutine(shieldtimer());
    }


    private IEnumerator shieldtimer()
    {
        shieldui.gameObject.SetActive(true);
        while (shieldtime > 0)
        {
            yield return null;
            shieldui.text = "Escudo: " + shieldtime;
            shieldtime -= Time.deltaTime;
        }
        shieldui.gameObject.SetActive(false);
        yield return shield = false;
    }
    private void OnEnable()
    {
        Vida = 3;
        vidaui.text = "Vida: " + Vida;
        shieldui.gameObject.SetActive(false);
        shield = false;
    }
}
