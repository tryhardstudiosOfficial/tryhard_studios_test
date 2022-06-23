using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_shield : Item
{
    public void Accion(Control_Nave nave)
    {
        nave.get_vida().ActivateShield();
    }
}
