using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] private Paddle paddle1;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] ballSounds;
    [SerializeField] private float randomFactor = 0.2f;

    // state
    private Vector2 paddleToBallVector;
    private bool hasStarted = false;
    
    // Cached component references
    private AudioSource myAudioSource;
    private Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        var paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f,randomFactor),Random.Range(0f, randomFactor));
        switch (hasStarted)
        {
            case true:
            {
                var clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
                Debug.Log(clip);
                myAudioSource.PlayOneShot(clip);
                myRigidbody2D.velocity += velocityTweak;
                break;
            }
        }
    }
}
