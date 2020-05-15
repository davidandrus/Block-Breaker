using UnityEngine;

public class Ball : MonoBehaviour
{
    // config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] Vector2 startVelocity;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomBounceFactor = 0.2f;
    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //cached component references
    AudioSource audioSource;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPosition();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
       if(Input.GetMouseButtonDown(0))
       {
            hasStarted = true;
            rb.velocity = startVelocity;
       }
    }

    private void LockBallToPosition()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);

        // start ball on paddle
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomBounceFactor),  Random.Range(0f, randomBounceFactor));
        if (hasStarted)
        {
            AudioClip randomSound = ballSounds[Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(randomSound);
            rb.velocity += velocityTweak;
        }
    }
}
