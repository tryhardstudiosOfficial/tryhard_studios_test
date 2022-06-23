using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_lifesup : Item
{
    public void Accion(Control_Nave nave)
    {
        nave.get_vida().Damage(-1);
    }
}
