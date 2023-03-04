using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondHalfController : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;
    public float Speed { get; set; }
    public bool horizontal;
    Vector2 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (horizontal)
        {
            movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") * -1);
        }
        else if (!horizontal)
        {
            movementDirection = new Vector2(Input.GetAxis("Horizontal") * -1, Input.GetAxis("Vertical"));
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = (movementDirection * Speed * Time.deltaTime);
    }
}
