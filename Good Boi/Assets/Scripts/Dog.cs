using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] sounds;

    private static readonly Vector3 spriteOffset = new Vector3(0.5f, 0.5f, 0f);

    private void Update(){
        if(Input.GetKeyDown(KeyCode.A)){
            Vector2 newPosition = getPosition() + Vector3.left;
            moveTo(newPosition);
            spriteRenderer.flipX = true;
        }else if(Input.GetKeyDown(KeyCode.W)){
            Vector2 newPosition = getPosition() + Vector3.up;
            moveTo(newPosition);
        }else if(Input.GetKeyDown(KeyCode.D)){
            Vector2 newPosition = getPosition() + Vector3.right;
            moveTo(newPosition);
            spriteRenderer.flipX = false;
        }else if(Input.GetKeyDown(KeyCode.S)){
            Vector2 newPosition = getPosition() + Vector3.down;
            moveTo(newPosition);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            bark();
        }
    }

    private Vector3 getPosition(){
        return transform.position + spriteOffset;
    }

    private void moveTo(Vector2 position){
        if(isTileEmpty(position)){
            transform.position = position - new Vector2(spriteOffset.x, spriteOffset.y);
        }
    }

    private bool isTileEmpty(Vector2 position){
        Collider2D collider = Physics2D.OverlapPoint(position);
        return (collider == null);
    }

    private void bark(){
        playRandomBarkSound();
    }

    private void playRandomBarkSound(){
        //0, 1 or 2
        int randomNumber = Random.Range(0, 3);
        playSound(sounds[randomNumber]);
    }

    private void playSound(AudioClip sound){
        audioSource.clip = sound;
        audioSource.Play();
    }
}
