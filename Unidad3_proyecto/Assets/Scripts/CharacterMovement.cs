using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    [SerializeField] private float velocidad = 5f;
    public float JumpForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();//Nos permite acceder a Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal =
            Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed ? -1 :
            Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed ? 1 : 0;

        if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame)
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
