using UnityEngine;

public class Enemy : PoolableObject {
    
    public float Speed = 10f;
    
    public float ShootRate;
    float lastFire = 0;

    void Start() {
        ShootRate = ShootRate == 0 ? Random.Range(1f, 1.5f) : ShootRate;
    }

    void Update() {
        transform.position += transform.forward * Speed * Time.deltaTime;

        lastFire += Time.deltaTime;
        if(lastFire > ShootRate){
            lastFire = 0;
            Shoot();
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("Player") || other.gameObject.tag.Equals("Bullet")){
            ReturnOrDestroy();
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag.Equals("MapBounds")){
            ReturnOrDestroy();
        }
    }

    void Shoot(){
        GameObject bullet = ObjectsPool.enemyBulletPool.GetObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
    }

}