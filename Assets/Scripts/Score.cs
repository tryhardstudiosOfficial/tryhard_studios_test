using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int puntuacion;
    public bool win = false;
    
    void Update()
    {
        if (puntuacion >= 10)
        {
            win = true;
        }
    }
}
