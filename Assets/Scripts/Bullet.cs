using UnityEngine;

using System.Collections.Generic;

public class Bullet : PoolableObject {
    
    public float Speed = 25f;

    void Update() {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("Enemy") && gameObject.tag.Equals("Bullet")){
            GameManager.Instance.AddPointsToPlayer(1);
            ReturnOrDestroy();
        }else if(other.gameObject.tag.Equals("Player") && gameObject.tag.Equals("EnemyBullet")){
            ReturnOrDestroy();
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag.Equals("MapBounds")){
            ReturnOrDestroy();
        }
    }
}