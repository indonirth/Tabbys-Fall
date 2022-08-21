using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;

    [SerializeField] private float movementSpeed = 3.0f;

    private Vector2 movement;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            float jumpVelocity = 5f;
            rigidbody.velocity = Vector2.up * jumpVelocity;
        }

        movement = new Vector2(Input.GetAxis("Horizontal"), 0).normalized;
        animator.SetFloat("Speed", Mathf.Abs(movement.magnitude * movementSpeed));

        bool flipped = movement.x < 0;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));
    }

    private void FixedUpdate() {
        if (movement != Vector2.zero) { //(0,0)
            var xMovement = movement.x * movementSpeed * Time.deltaTime;
            this.transform.Translate(new Vector3(xMovement, 0), Space.World);
        }
    }
    
    bool ifFloor()
    {
        RaycastHit collider_checker;
        return Physics.SphereCast(transform.position, 0.45f, Vector3.down, out collider_checker, 1.15f);
    }
}
