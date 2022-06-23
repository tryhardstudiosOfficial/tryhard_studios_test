using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_item : MonoBehaviour
{
    [SerializeField]
    private Item item;

    public void SetItem(Item newEffect)
    {
        item = newEffect;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        item.Accion(collision.GetComponent<Control_Nave>());
        gameObject.SetActive(false);
    }
}
