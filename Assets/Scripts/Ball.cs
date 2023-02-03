using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float velX = 2f, velY = 10f; 
    Vector2 paddletoBallVector;
    bool hasStarted = false;
    AudioSource clickAudio;
    [SerializeField] AudioClip[] ballSounds;
    void Start()
    {
        paddletoBallVector = transform.position - paddle1.transform.position;
        clickAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
       if(!hasStarted)
        {
            LockBalltoPaddle();
            LaunchBallonClick();
        }
    }

    private void LockBalltoPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddletoBallVector;
    }

    private void LaunchBallonClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(velX, velY);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
        if(hasStarted)
        {
            clickAudio.PlayOneShot(clip);
        }
    }
}
