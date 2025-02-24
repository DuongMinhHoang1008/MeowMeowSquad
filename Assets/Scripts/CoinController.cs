using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour, Contactable
{
    GameObject followObject;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (followObject != null) {
            Vector2 distance = (Vector2) followObject.transform.position - rigidbody2D.position;
            if (distance.magnitude < 1f) {
                GlobalVar.Instance().AddCoin(1);
                Destroy(gameObject);
            }
            Vector2 direction = distance.normalized;
            rigidbody2D.MovePosition(rigidbody2D.position + direction * 20 * Time.fixedDeltaTime);
        }
    }
    public void OnContact(Collider2D collider)
    {
        if (followObject == null) {
            if (collider.GetComponent<FlyingCatController>() != null) followObject = collider.gameObject;
        }
    }
}
