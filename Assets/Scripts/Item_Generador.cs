using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Generador : MonoBehaviour
{
    [SerializeField]
    private GameObject Prefab_Item;

    [SerializeField]
    private float totaltime_buff = 20;
    [SerializeField]
    private float actualtime_buff;


    [SerializeField]
    private float totaltime_debuff = 15;
    [SerializeField]
    private float actualtime_debuff;

    [SerializeField]
    private List<GameObject> Buffs = new List<GameObject>();
    [SerializeField]
    private List<GameObject> Debuffs = new List<GameObject>();
    private float range;

    private void Start()
    {
        var camara = Camera.main;
        var camara_size = (camara.orthographicSize * camara.aspect);
        range = camara_size;

        totaltime_debuff = Random.Range(12f, 15f);
    }
    private void Update()
    {
        if (actualtime_buff >= totaltime_buff) InvokeBuff();
        if (actualtime_debuff >= totaltime_debuff) InvokeDebuff();


        actualtime_buff += 1 * Time.deltaTime;
        actualtime_debuff += 1 * Time.deltaTime;
    }


    private void InvokeBuff()
    {
       




    }

    private void InvokeDebuff()
    {
        totaltime_debuff = Random.Range(12f, 15f);

        if (Debuffs.Count <= 0)
        {
            var firstitem =
            Instantiate(Prefab_Item, new Vector2(Random.Range(-range, range),range),Prefab_Item.transform.rotation);

            firstitem.GetComponent<collision_item>().SetItem(RandomDebuff());
            Debuffs.Add(firstitem);
            actualtime_debuff = 0;
            return;
        }

        foreach(GameObject deb in Debuffs)
        {
            if (!deb.activeInHierarchy)
            {
                deb.transform.position = new Vector2(Random.Range(-range, range), range);
                deb.GetComponent<collision_item>().SetItem(RandomDebuff());
                deb.SetActive(true);
                actualtime_debuff = 0;
                return;
            }
        }

        var item =
           Instantiate(Prefab_Item, new Vector2(Random.Range(-range, range), range), Prefab_Item.transform.rotation);
        item.GetComponent<collision_item>().SetItem(RandomDebuff());
        Debuffs.Add(item);
        actualtime_debuff = 0;
    }


    Item RandomDebuff()
    {
        Item db;
        switch (Random.Range(1, 3))
        {
            case 1:
                 db = new Debuff_invertir();
                return db;
            case 2:
                 db = new Debuff_LivesDown();
                return db;
            default:
                  db = new Debuff_invertir();
                return db;
        }


    }
}
