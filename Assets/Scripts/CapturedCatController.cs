using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CapturedCatController : MonoBehaviour, Contactable
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnContact(Collider2D collider) {
        FlyingCatController catController = collider.GetComponent<FlyingCatController>();
        if (catController != null) {
            catController.listController.AppendCat();
        }
        Destroy(gameObject);
    }
}
