using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.5f;

    Vector2 offset;
    Material material;

    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void Start()
    {
        offset = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += scrollSpeed * Time.deltaTime;
        material.mainTextureOffset = offset;
    }
}
