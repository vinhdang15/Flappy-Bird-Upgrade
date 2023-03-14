using System;
using System.Collections;
using System.Drawing;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector3        direction;
    public  float          rotSpeed = 500f;
    public  float          lastPosition;
    public  float          gravity  = -9.8f;
    public  float          strength = 5f;
    public  Sprite[]       sprites;
    public  Sprite[]       sprites_upGrade_1;
    public  Sprite[]       sprites_upGrade_2;
    public  int            spriteIndex;
    public  XPManager      xpManager;

    public int level;


    private void Awake()
    {
        spriteRenderer   =  GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        direction.y             = 0f;
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }
    private void Update()
    {
        lastPosition = transform.position.y;
        
        var isTouch = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
        if (isTouch)
        {
            direction = Vector3.up * strength;
        }

        direction.y        += gravity * Time.smoothDeltaTime;
        transform.position += direction * Time.smoothDeltaTime;

        if (lastPosition < transform.position.y && transform.rotation.z <= 0.35)
        {
            transform.Rotate(Vector3.forward, rotSpeed * Time.smoothDeltaTime);
            transform.localRotation = Quaternion.Euler(0, 0, 30);
        }
        else if(transform.rotation.z > -0.35)
        {
            transform.Rotate(Vector3.forward, -rotSpeed * Time.smoothDeltaTime);
        }
    }
    private void AnimateSprite()
    {
        spriteIndex++;
        if (xpManager.level == 0)
        {
            if (spriteIndex >= sprites.Length)
            {
                spriteIndex = 0;
            }
            spriteRenderer.sprite = sprites[spriteIndex];
        }
        else if(xpManager.level == 1)
        {
            if (spriteIndex >= sprites_upGrade_1.Length)
            {
                spriteIndex = 0;
            }
            spriteRenderer.sprite = sprites_upGrade_1[spriteIndex];
        }
        else
        {
            if (spriteIndex >= sprites_upGrade_2.Length)
            {
                spriteIndex = 0;
            }
            spriteRenderer.sprite = sprites_upGrade_2[spriteIndex];
        }

    }

    const string scoring        = "scoring";
    const string Item_Rectangle = "Item_Rectangle";
    const string obstacle       = "obstacle";
    const string ground         = "ground";
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals(scoring))
        {
            GameManager.OnAddScore();
            GameManager.OnHighScore();
            AudioManager.OnPlayAudio("score");
            // FindObjectOfType<AudioManager>().play("score");
            // AudioManager.Instance.play("score");
        }
        else if (col.gameObject.tag.Equals(Item_Rectangle))
        {
            xpManager.AddXP();
            // col.gameObject.SetActive(false);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag.Equals(obstacle))
        {
            GameManager.OnGameOver();
        }
        else if (col.gameObject.tag.Equals(ground))
        {
            GameManager.OnGameOver();
        }
    }
}