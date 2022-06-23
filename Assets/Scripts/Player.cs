using UnityEngine;

public class Player : MonoBehaviour {
    
    public int StartingLives = 3;
    public int StartingShoots = 15;

    public int Lives;
    public int Shoots;

    public float InvincibleTime = 0f;

    public float Speed = 30f;
    public float ShootRate = .5f;
    public float ShootReloadTime = 2f;

    public float InvertedControlsTime = 0f;

    public PowerItemData CurrentPowerItem;
    public float CurrentPowerItemTime = 0f;
    public float LastReloadTime;

    MeshRenderer Map;

    float lastFire = 0;
    float defaultInvincibleTime = 2f;
    Vector3 startPosition;
    Bounds bounds;

    void Awake() {
        Lives = StartingLives;
        Shoots = StartingShoots;
        LastReloadTime = ShootReloadTime;
        startPosition = transform.position;
        bounds = GetComponent<MeshRenderer>().bounds;
    }

    void Start() {
        Map = GameManager.Instance.Map;
        transform.position = startPosition;
        InvincibleTime = defaultInvincibleTime;
    }

    void Update() {
        float horizontalMove = Input.GetAxisRaw("Horizontal");

        Vector3 clampedArea = Map.bounds.extents - bounds.extents;

        float Xposition =  Mathf.Clamp(transform.position.x + horizontalMove * (InvertedControlsTime > 0f? -1 : 1) * Speed * Time.deltaTime, -clampedArea.x, clampedArea.x);

        transform.position = new Vector3(Xposition, 0f, transform.position.z);

        bool isFiring = Input.GetButton("Fire1");

        if(Shoots == 0f){
            if(LastReloadTime <= 0f){
                LastReloadTime = ShootReloadTime;
                Shoots = 15;
            }else{
                LastReloadTime -= Time.deltaTime;
            }
        }

        if(isFiring && lastFire >= ShootRate && Shoots > 0f){
            lastFire = 0;
            Shoots--;
            Shoot();
        }
        
        lastFire += Time.deltaTime;
        
        if(InvincibleTime > 0f){
            InvincibleTime -=Time.deltaTime;
        }
        if(InvertedControlsTime > 0f){
            InvertedControlsTime -= Time.deltaTime;
        }

        if(CurrentPowerItemTime >0f){
            CurrentPowerItemTime = Mathf.Max(CurrentPowerItemTime - Time.deltaTime, 0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if((other.gameObject.tag.Equals("Enemy") || other.gameObject.tag.Equals("EnemyBullet")) && InvincibleTime <= 0f){
            Lives--;
            if(Lives > 0){
                Start();
            }else{
                GameManager.Instance.GameOver();
            }
        }
    }

    void Shoot(){
        GameObject bullet = ObjectsPool.bulletPool.GetObject();
        bullet.transform.position = transform.position;
    }

}