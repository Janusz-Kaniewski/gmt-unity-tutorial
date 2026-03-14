using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logicScript;
    public bool isBirdAlive = true;

    public GameObject wingUp;
    public GameObject wingDown;

    private bool isWingsDown = false;

    private float timer = 0;

    private InputAction jumpAction;
    private ParticleSystem particleSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        particleSystem = GameObject.FindGameObjectWithTag("ParticleSystem").GetComponent<ParticleSystem>();
        jumpAction = InputSystem.actions.FindAction("Jump");

        UpdateWings(isWingsDown);
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.IsPressed() && isBirdAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
            isWingsDown = true;
        }

        if (isWingsDown)
        {
            if (timer < 0.25)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                isWingsDown = false;
            }
        }


        UpdateWings(isWingsDown);
    }

    private void UpdateWings(bool isWingsDown)
    {
        wingDown.SetActive(isWingsDown);
        wingUp.SetActive(!isWingsDown);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.GameOver();
        isBirdAlive = false;
        particleSystem.Pause();
    }
}
