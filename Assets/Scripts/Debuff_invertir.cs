
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff_invertir : Item
{
    public void Accion(Control_Nave nave)
    {
        nave.get_nave()?.Descontrol();
    }
}
