using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour, Contactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnContact(Collider2D collider)
    {
        FlyingCatController catController = collider.GetComponent<FlyingCatController>();
        if (catController != null) {
            catController.listController.DestroyCat(catController.index);
        }
        Destroy(gameObject);
    }
}
