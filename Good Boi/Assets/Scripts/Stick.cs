using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public void Interact()
    {
        FindObjectOfType<Farmer>().EndLevel();
        Destroy(this.gameObject);
    }
}
