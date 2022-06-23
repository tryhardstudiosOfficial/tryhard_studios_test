using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida_nave : MonoBehaviour
{
    [SerializeField]
    private int Vida = 3;

    private bool shield = false;
    private float shieldtime;

    public void Damage(int cantidad)
    {
        if (cantidad > 0 && shield) return;
        Vida -= cantidad;
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
        while (shieldtime > 0)
        {
            yield return null;

            shieldtime -= Time.deltaTime;
        }

        yield return shield = false;
    }
}
