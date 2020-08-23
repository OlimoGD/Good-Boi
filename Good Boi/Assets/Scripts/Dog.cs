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
    private DialogueManager dialogueManager;

    private static readonly Vector3 spriteOffset = new Vector3(0.5f, 0.5f, 0f);

    private void Start()
    {
        dialogueManager = DialogueManager.GetInstance();
    }

    private void Update(){
        if(dialogueManager.IsDialoguePlaying)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.A)){
            Vector2 newPosition = GetPosition() + Vector3.left;
            MoveTo(newPosition);
            spriteRenderer.flipX = true;
        }else if(Input.GetKeyDown(KeyCode.W)){
            Vector2 newPosition = GetPosition() + Vector3.up;
            MoveTo(newPosition);
        }else if(Input.GetKeyDown(KeyCode.D)){
            Vector2 newPosition = GetPosition() + Vector3.right;
            MoveTo(newPosition);
            spriteRenderer.flipX = false;
        }else if(Input.GetKeyDown(KeyCode.S)){
            Vector2 newPosition = GetPosition() + Vector3.down;
            MoveTo(newPosition);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            Bark();
        }
    }

    public Vector3 GetPosition(){
        return transform.position + spriteOffset;
    }

    private void MoveTo(Vector2 position){
        if(IsTileEmpty(position)){
            transform.position = position - new Vector2(spriteOffset.x, spriteOffset.y);
        }
    }

    private bool IsTileEmpty(Vector2 position){
        Collider2D collider = Physics2D.OverlapPoint(position);
        return (collider == null);
    }

    private void Bark(){
        PlayRandomBarkSound();
        Collider2D[] neighbors = Physics2D.OverlapCircleAll(GetPosition(), 1f);
        foreach (Collider2D collider in neighbors)
        {
            if(collider.tag == "Farmer")
            {
                collider.GetComponentInParent<Farmer>().Interact(this);
                return;
            }
            else if(collider.tag == "Chicken")
            {
                collider.GetComponentInParent<Chicken>().GetScared(this);
            }
        }
    }

    private void PlayRandomBarkSound(){
        //0, 1 or 2
        int randomNumber = Random.Range(0, 3);
        PlaySound(sounds[randomNumber]);
    }

    private void PlaySound(AudioClip sound){
        audioSource.clip = sound;
        audioSource.Play();
    }
}
