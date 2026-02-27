using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    [SerializeField] private float velocidad = 5f;
    public float JumpForce;
    private bool Grounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();//Nos permite acceder a Rigidbody2D
        Animator = GetComponent<Animator>();//Nos permite acceder a Animator
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal =
            Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed ? -1 :
            Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed ? 1 : 0;

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 1.2f, Color.blue);
        if (Physics2D.Raycast(transform.position, Vector3.down, 1.2f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if ((Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame) && Grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = new Vector2(Horizontal * velocidad, Rigidbody2D.linearVelocity.y);
    }
}
