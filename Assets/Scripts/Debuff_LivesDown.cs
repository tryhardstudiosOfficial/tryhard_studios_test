using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff_LivesDown : Item
{
    public void Accion(Control_Nave nave)
    {
        nave.get_vida().Damage(2);
    }
}
