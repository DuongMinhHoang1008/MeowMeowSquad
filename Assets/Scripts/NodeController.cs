using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NodeController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    bool isGoUp = false;
    float speed = 0f;
    [SerializeField] float acceleration = 0.1f;
    [SerializeField] float MAX_SPEED = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int direction = 1;
        if (!isGoUp) direction = -1;
        speed += direction * acceleration;
        if (speed > MAX_SPEED) {
            speed = MAX_SPEED;
        }
        if (speed < -1 * MAX_SPEED) {
            speed = -1 * MAX_SPEED;
        }
    }

    private void FixedUpdate() {
        Vector2 movePos = rigidbody2D.position + speed * Vector2.up * Time.deltaTime;
        rigidbody2D.MovePosition(movePos);
    }

    public void GoUp() {
        isGoUp = true;
    }
    public void GoDown() {
        isGoUp = false;
    }
}
