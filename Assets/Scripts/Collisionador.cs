using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisionador : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
