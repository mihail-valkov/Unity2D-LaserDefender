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

    Vector2 moveInput;

    Vector2 minBounds;
    Vector2 maxBounds;

    void Start()
    {
        minBounds = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        minBounds.x += paddingLeft;
        maxBounds.x -= paddingRight;
        minBounds.y += paddingBottom;
        maxBounds.y -= paddingTop;
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

        //move also the Background object in paralax effect
        GameObject background = GameObject.Find("Background");
        if (background != null)
        {
            background.transform.position = new Vector3(newPosition.x / 4, newPosition.y / 4, background.transform.position.z);
        }
    }
}
