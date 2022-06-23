using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Generador : MonoBehaviour
{
    public bool ON= true;
    private Control_Nave Nave;

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

        Nave = GameObject.FindWithTag("Player").GetComponent<Control_Nave>();
    }
    public void restart()
    {
        if (ON) return;
        ON = true;
        totaltime_debuff = Random.Range(12f, 15f);
        totaltime_buff = Random.Range(15f, 20f);
        actualtime_buff = 0;
        actualtime_debuff = 0;
    }
    private void Update()
    {
        if (!ON) return;
        if (actualtime_buff >= totaltime_buff) InvokeBuff();
        if (actualtime_debuff >= totaltime_debuff) InvokeDebuff();


        actualtime_buff += 1 * Time.deltaTime;
        actualtime_debuff += 1 * Time.deltaTime;
    }


    private void InvokeBuff()
    {

        totaltime_buff = Random.Range(15f, 20f);

        if (Buffs.Count <= 0)
        {
            var firstitem =
            Instantiate(Prefab_Item, new Vector2(Random.Range(-range, range), range), Prefab_Item.transform.rotation);
            firstitem.GetComponent<SpriteRenderer>().color = Color.yellow;
            firstitem.GetComponent<collision_item>().SetItem(RandomBuff());
            Buffs.Add(firstitem);
            actualtime_buff = 0;
            return;
        }

        foreach (GameObject b in Buffs)
        {
            if (!b.activeInHierarchy)
            {
                b.transform.position = new Vector2(Random.Range(-range, range), range);
                b.GetComponent<collision_item>().SetItem(RandomBuff());
                b.GetComponent<SpriteRenderer>().color = Color.yellow;
                b.SetActive(true);
                actualtime_buff = 0;
                return;
            }
        }

        var item =
           Instantiate(Prefab_Item, new Vector2(Random.Range(-range, range), range), Prefab_Item.transform.rotation);
        item.GetComponent<collision_item>().SetItem(RandomBuff());
        item.GetComponent<SpriteRenderer>().color = Color.yellow;
        Buffs.Add(item);
        actualtime_buff = 0;



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

    Item RandomBuff()
    {
        Item buff;
        switch (Random.Range(1, 4))
        {
            case 1:
                
                buff = Nave.get_vida().VidaAmount() < 3 ?new Buff_lifesup():new buff_shield();
                return buff;
            case 2:
                buff = new buff_shield();
                return buff;
            case 3:
                buff = new Buff_KILLALL();
                return buff;
            default:
                buff = new Buff_KILLALL();
                return buff;
        }
    }


    public void limpiar()
    {
        foreach (GameObject b in Buffs) b.SetActive(false);
        foreach (GameObject d in Debuffs) d.SetActive(false);
    }
}
