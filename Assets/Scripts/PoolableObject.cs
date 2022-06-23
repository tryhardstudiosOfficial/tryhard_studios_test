using UnityEngine;

public class PoolableObject : MonoBehaviour {
    
    public GameObjectPool pool;

    public void ReturnOrDestroy(){
        if(pool != null){
            pool.ReturnToPool(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
}