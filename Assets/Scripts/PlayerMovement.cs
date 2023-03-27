using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        rb.velocity = Vector2.right * direction;

        if (Input.GetKey("space"))
        {
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        rb.velocity += Vector2.up;
        canJump = false;
        yield return new WaitForSeconds(1f);
        canJump = true;
    }
}
