using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public float speed = 30.0f;
    public float lowerB = 36.0f;
    public float upperB = 53.0f;
    public GameObject projectilePrefab;
    private AudioSource playerAudio;
    public AudioClip shootSound;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (transform.position.x > upperB)
        {
            transform.position = new Vector3(upperB, transform.position.y, transform.position.z);

        }
        if (transform.position.x < lowerB)
        {
            transform.position = new Vector3(lowerB, transform.position.y, transform.position.z);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch a projectile prefab
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            playerAudio.PlayOneShot(shootSound, 1.0f);
        }

    }
}
