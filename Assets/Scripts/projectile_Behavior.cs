using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_Behavior : MonoBehaviour
{

    public float speed = 10f;
    public float maxDistance = 16.5f;

    
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    } */

    // Update is called once per frame
    void Update()
    {
        
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + (speed * Time.deltaTime));

        transform.position = position;

        if (transform.position.y >= maxDistance)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }
}
