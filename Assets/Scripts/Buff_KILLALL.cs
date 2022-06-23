using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_KILLALL : Item
{
    public void Accion(Control_Nave nave)
    {
        Enemigo_Generador.instance.DestroyAll();
    }
}
