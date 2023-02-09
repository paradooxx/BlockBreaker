using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float velX = 2f, velY = 10f; 
    Vector2 paddletoBallVector;
    bool hasStarted = false;
    AudioSource clickAudio;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.3f;
    Rigidbody2D myRigidBody2D;
    void Start()
    {
        paddletoBallVector = transform.position - paddle1.transform.position;
        clickAudio = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
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
            myRigidBody2D.velocity = new Vector2(velX, velY);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Vector2 velTweak = new Vector2(Random.Range(0.0f, randomFactor), Random.Range(0.0f, randomFactor));
        AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
        if(hasStarted)
        {
            clickAudio.PlayOneShot(clip);
            myRigidBody2D.velocity += velTweak;
        }
    }
}
