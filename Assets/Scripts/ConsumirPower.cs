using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumirPower : MonoBehaviour
{
    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Jugador") {
            Destroy(gameObject);
        }
    }
}
