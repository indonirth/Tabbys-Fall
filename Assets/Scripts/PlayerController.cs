using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    public SpriteRenderer spriteRenderer;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 speed = new Vector3(x*5, 0 ,0) + Vector3.up * rigidbody.velocity.y;
        rigidbody.velocity = speed;
        if (x > 0) {
            spriteRenderer.flipX = false;
        } else if (x < 0) {
            spriteRenderer.flipX = true;
        }

        if (Input.GetButtonDown("Jump") && ifFloor()) {
            rigidbody.velocity += Vector3.up * 10;
        }

        if (x == 0) {
            animator.SetFloat("Speed", 0);
        } else {
            animator.SetFloat("Speed", 1);
        }
    }

    bool ifFloor()
    {
        RaycastHit collider_checker;
        return Physics.SphereCast(transform.position, 0.45f, Vector3.down, out collider_checker, 1.15f);
    }
}
