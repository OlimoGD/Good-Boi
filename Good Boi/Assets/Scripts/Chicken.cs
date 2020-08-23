using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] sounds;
    private static readonly Vector3 spriteOffset = new Vector3(0.5f, 0.5f, 0f);

    public void GetScared(Dog dog)
    {
        if(Vector3.Distance(dog.GetPosition(), this.GetPosition()) > 1)
        {
            //dog too far away, chicken won't get scared
            return;
        }

        bool dogIsRight = dog.GetPosition().x > this.GetPosition().x;
        bool dogIsLeft = dog.GetPosition().x < this.GetPosition().x;
        bool dogIsUp = dog.GetPosition().y > this.GetPosition().y;
        
        if(dogIsRight)
        {
            moveInDirection(Vector3.left);
            spriteRenderer.flipX = true;
        }
        else if(dogIsLeft)
        {
            moveInDirection(Vector3.right);
            spriteRenderer.flipX = false;
        }
        else if(dogIsUp)
        {
            moveInDirection(Vector3.down);
        }
        else
        {
            moveInDirection(Vector3.up);
        }

        StartCoroutine(PlayRandomChickenSoundCoroutine());
    }

    private IEnumerator PlayRandomChickenSoundCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
        PlayRandomChickenSound();
        yield return new WaitForSeconds(0.23f);
        PlayRandomChickenSound();
    }

    private void moveInDirection(Vector3 direction)
    {
        Vector2 newPosition = GetPosition() + direction;
        MoveTo(newPosition);
    }

    private Vector3 GetPosition(){
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

    private void PlayRandomChickenSound(){
        int randomNumber = Random.Range(0, 2);
        PlaySound(sounds[randomNumber]);
    }

    private void PlaySound(AudioClip sound){
        audioSource.clip = sound;
        audioSource.Play();
    }
}
