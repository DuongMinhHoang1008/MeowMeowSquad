using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Contactable
{
    public abstract void OnContact(Collider2D collider);
}
