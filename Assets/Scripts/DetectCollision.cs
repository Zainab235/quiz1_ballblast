using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public bool isCollided;
    static int collide = 0;
    public AudioClip collisionSound;
    private AudioSource ballAudio;
    public GameObject smallBallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        ballAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            ballAudio.PlayOneShot(collisionSound, 1.0f);
            collide = collide + 1;
            Debug.Log("Score:  " + collide);
            isCollided = true;
            if (gameObject.CompareTag("Bigball"))
            {
                SplitBall();
            }
            else if (gameObject.CompareTag("Smallball"))
            {
                VanishSmallball();
            }

            Destroy(collision.gameObject);
            if (collide == 30)
            {
                Debug.Log("Game Over!");
            }

        }
    }
    void VanishSmallball()
    {
        Destroy(gameObject);
    }
    void SplitBall()
    {
        float gap = 1.5f;

       
        Vector3 position1 = transform.position + Vector3.left * gap;
        Vector3 position2 = transform.position + Vector3.right * gap;

        Instantiate(smallBallPrefab, position1, Quaternion.identity);
        Instantiate(smallBallPrefab, position2, Quaternion.identity);

        
        Destroy(gameObject);
    }
}
