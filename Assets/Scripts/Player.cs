using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    [SerializeField] float paralaxEffectFactor = 12f;

    Vector2 moveInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    GameObject background;
    Vector2 backgroundOffset;

    void Awake()
    {
        //move also the Background object in paralax effect
        background = GameObject.Find("Background");
    }

    void Start()
    {
        minBounds = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        minBounds.x += paddingLeft;
        maxBounds.x -= paddingRight;
        minBounds.y += paddingBottom;
        maxBounds.y -= paddingTop;

        backgroundOffset = (Vector2)background.transform.position + new Vector2(transform.position.x / paralaxEffectFactor, transform.position.y / paralaxEffectFactor);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {

        Vector2 newPosition = moveInput * moveSpeed * Time.deltaTime;

        //confine the player to the screen, inluding padding
    
        //get player size
        Vector2 playerSize = GetComponent<SpriteRenderer>().bounds.size;
        newPosition.x = Mathf.Clamp(transform.position.x + newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(transform.position.y + newPosition.y, minBounds.y, maxBounds.y);

        transform.position = newPosition;

        if (background != null)
        {
            background.transform.position = backgroundOffset - new Vector2(newPosition.x / paralaxEffectFactor, newPosition.y / paralaxEffectFactor);
        }
    }
}
