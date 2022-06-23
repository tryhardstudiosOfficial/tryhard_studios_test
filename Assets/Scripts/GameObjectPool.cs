using UnityEngine;

using System.Collections.Generic;

public class GameObjectPool {
    
    public Queue<GameObject> pool;
    int capacity;
    GameObject gameObject;
    Transform parent;

    public GameObjectPool(GameObject gameObject, int capacity, Transform parent){
        this.pool = new Queue<GameObject>(capacity);
        this.gameObject = gameObject;
        this.capacity = capacity;
        this.parent = parent;

        CreatePool(gameObject);
    }

    public void CreatePool(GameObject gameObject){
        for(int i = 0; i < capacity; i++){
            GameObject newObject = GameObject.Instantiate(gameObject, parent);
            newObject.SetActive(false);
            newObject.GetComponent<PoolableObject>().pool = this;
            pool.Enqueue(newObject);
        }
    }

    public GameObject GetObject(){
        GameObject newObject = null;
        if(pool.Count > 0){
            newObject = pool.Dequeue();
        }else{
            newObject = GameObject.Instantiate(gameObject, parent);
            newObject.GetComponent<PoolableObject>().pool = this;
        } 
        newObject.SetActive(true);
        return newObject;
    }

    public void ReturnToPool(GameObject gameObject){
        gameObject.SetActive(false);
        pool.Enqueue(gameObject);
    }
}