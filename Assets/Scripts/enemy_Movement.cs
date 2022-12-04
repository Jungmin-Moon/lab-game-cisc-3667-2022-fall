using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_Movement : MonoBehaviour
{

    public float speed = 14f;
    bool movingLeft;
    const float LEFT_MAX = -25f;
    const float RIGHT_MAX = 25f;

    Vector3 direction = Vector3.left;

    public float scale = 3f;

    private float enemySizeLimit = 9f;

    public AudioSource audioSource;

    // Start is called before the first frame update

    
    void Start()
    {


        movingLeft = true;
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        InvokeRepeating("IncreaseSize", 3.0f, 5.0f);

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(direction * speed * Time.deltaTime);

        if(gameObject.transform.position.x <= LEFT_MAX)
        {

            EnemyFlip();
            direction = Vector3.right;
            
        } else if(gameObject.transform.position.x >= RIGHT_MAX)
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

        if (scale <= 3f && scale < 4f)
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            Destroy(gameObject);
            GameManager.instance.AddPoint(600);
        }
        else if (scale == 4f && scale < 5f)
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            Destroy(gameObject);
            GameManager.instance.AddPoint(500);
        }
        else if (scale == 6f && scale < 7f)
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            Destroy(gameObject);
            GameManager.instance.AddPoint(400);
        }
        else if (scale == 8f && scale < 9f)
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            Destroy(gameObject);
            GameManager.instance.AddPoint(300);
        }

        if ((SceneManager.GetActiveScene().buildIndex + 1) >= 4)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void IncreaseSize()
    {

        scale += 0.5f;

        transform.localScale = new Vector2(scale, scale);
        
        if (scale >= enemySizeLimit)
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            Destroy(gameObject);
            GameManager.instance.AddPoint(0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } 
        
    }
}
