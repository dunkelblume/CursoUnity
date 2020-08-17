using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{

    public Animator animator;
    public SpriteRenderer sprite;
    public BoxCollider2D collider;
    public int collectables;

    public UICollectables uiCollectables;
    public UIHealthBar uiHealthBar;

    [SerializeField]
    private float moveSpeed;
    
    [SerializeField]
    private float CurrentHealth = 100;

    [SerializeField]
    private float MaxHealth = 100;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // move left
            animator.SetBool("RunSide",true);
            animator.SetBool("RunDown", false);
            animator.SetBool("RunUp", false);
            sprite.flipX = false;
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y); 
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // move right
            animator.SetBool("RunSide",true);
            animator.SetBool("RunDown", false);
            animator.SetBool("RunUp", false);
            sprite.flipX = true;
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y); 
        }
        
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // move Down
            animator.SetBool("RunDown", true);
            animator.SetBool("RunUp", false);
            animator.SetBool("RunSide", false);
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // move up
            animator.SetBool("RunUp", true);
            animator.SetBool("RunSide", false);
            animator.SetBool("RunDown", false);
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed);
        }
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Collectable"))
        {
            collision.GetComponent<BoxCollider2D>().enabled = false;
            collectables++;
            PlayerPrefs.SetInt("collectables", collectables);
            uiCollectables.UpdateCollectableAmount(collectables);
            if(collision.GetComponent<Animator>() != null)
            {
                collision.GetComponent<Animator>().Play("Collected");
            }
        }

        if(collision.CompareTag("Health"))
        {
            CurrentHealth += 10;
            uiHealthBar.UpdateHealth(CurrentHealth, MaxHealth);
            collision.GetComponent<Animator>().Play("Collected");
            collision.GetComponentInChildren<ParticleSystem>().Play();
        }
        
        if(collision.CompareTag("Hazard"))
        {
            CurrentHealth -= 10;
            uiHealthBar.UpdateHealth(CurrentHealth, MaxHealth);
            animator.SetTrigger("HitSides");
            collision.GetComponent<Animator>().Play("DoDamage");
        }
        
    }

}
