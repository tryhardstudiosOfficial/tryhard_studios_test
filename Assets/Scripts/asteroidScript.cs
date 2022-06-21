using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidScript : MonoBehaviour
{
    public float speed;
    public float endPosY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartFloating(float endPosY){
        this.endPosY = endPosY;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        if (transform.position.y < this.endPosY){
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x,endPosY), 0.5f);
    }
}
