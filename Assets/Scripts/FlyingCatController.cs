using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class FlyingCatController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    bool isGoUp = false;
    float speed = 0f;
    [SerializeField] float acceleration = 0.1f;
    [SerializeField] float MAX_SPEED = 1f;
    float horizontalSpeed = 1f;
    public FlyingCatListController listController { get; private set; }
    public int index { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f);
    }

    // Update is called once per frame
    void Update()
    {
        int direction = 1;
        if (!isGoUp) direction = -1;
        speed += direction * acceleration * Time.deltaTime;
        if (speed > MAX_SPEED) {
            speed = MAX_SPEED;
        }
        if (speed < -1 * MAX_SPEED) {
            speed = -1 * MAX_SPEED;
        }
    }

    private void FixedUpdate() {
        Vector2 movePos = rigidbody2D.position + speed * Vector2.up * Time.fixedDeltaTime + Vector2.right * horizontalSpeed * Time.fixedDeltaTime;
        rigidbody2D.MovePosition(movePos);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Contactable contactableObject = other.GetComponent<Contactable>();
        Debug.Log(other.name);
        if (contactableObject != null) {
            contactableObject.OnContact(GetComponent<Collider2D>());
        }
    }
    public void GoUp() {
        isGoUp = true;
    }
    public void GoDown() {
        isGoUp = false;
    }
    public void SetHorizontalSpeed(float s) {
        horizontalSpeed = s;
    }
    public void SetListController(FlyingCatListController list) {
        listController = list;
    }
    public void SetVisible(bool isVisible) {
        GetComponent<SpriteRenderer>().enabled = isVisible;
        GetComponent<CircleCollider2D>().enabled = isVisible;
    }
    public void ChangeType(Color color) {
        GetComponent<SpriteRenderer>().color = color;
    }
    public void ChangeType() {
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f);
    }
    public void SetIndex(int i) {
        index = i;
    }
}
