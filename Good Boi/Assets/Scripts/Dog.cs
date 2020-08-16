using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.A)){
            transform.position += Vector3.left;
            spriteRenderer.flipX = true;
        }else if(Input.GetKeyDown(KeyCode.W)){
            transform.position += Vector3.up;
        }else if(Input.GetKeyDown(KeyCode.D)){
            transform.position += Vector3.right;
            spriteRenderer.flipX = false;
        }else if(Input.GetKeyDown(KeyCode.S)){
            transform.position += Vector3.down;
        }

        if(Input.GetKeyDown(KeyCode.E)){
            bark();
        }
    }

    private void bark(){
        
    }
}
