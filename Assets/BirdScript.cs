using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logicScript;
    public bool isBirdAlive = true;

    private InputAction jumpAction;
    private ParticleSystem particleSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        particleSystem = GameObject.FindGameObjectWithTag("ParticleSystem").GetComponent<ParticleSystem>();
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.IsPressed() && isBirdAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.GameOver();
        isBirdAlive = false;
        particleSystem.Pause();
    }
}
