using UnityEngine;

public class ObjectsPool : MonoBehaviour {
    
    public static GameObjectPool enemyPool;
    public GameObject EnemyPrefab;

    public static GameObjectPool bulletPool;
    public GameObject BulletPrefab;

    public static GameObjectPool enemyBulletPool;
    public GameObject EnemyBulletPrefab;

    void Awake()
    {
        enemyPool = new GameObjectPool(EnemyPrefab,10,transform);
        bulletPool = new GameObjectPool(BulletPrefab,15,transform);
        enemyBulletPool = new GameObjectPool(EnemyBulletPrefab,10,transform);
    }
}