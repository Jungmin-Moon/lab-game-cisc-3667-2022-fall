using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Distractor : MonoBehaviour
{

    public float speed = 14f;
    bool movingLeft;
    const float LEFT_MAX = -25f;
    const float RIGHT_MAX = 25f;

    Vector3 direction = Vector3.left;
    public AudioSource audioSource;

   
// Start is called before the first frame update
    void Start()
    {
        movingLeft = true;
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(direction * speed * Time.deltaTime);

        if (gameObject.transform.position.x <= LEFT_MAX)
        {

            EnemyFlip();
            direction = Vector3.right;

        }
        else if (gameObject.transform.position.x >= RIGHT_MAX)
        {

            EnemyFlip();
            direction = Vector3.left;

        }
    }

    void EnemyFlip()
    {
        Vector3 enemyCurrentScale = gameObject.transform.localScale;
        enemyCurrentScale.x *= -1;
        gameObject.transform.localScale = enemyCurrentScale;

        movingLeft = !movingLeft;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
        Destroy(gameObject);
    }
}
