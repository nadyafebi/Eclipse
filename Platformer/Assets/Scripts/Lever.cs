using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : Interactable
{
    public Sprite crankedUpSprite;
    public Sprite crankedDownSprite;

    public UnityEvent OnToggle;

    private bool cranked = false;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        cranked = !cranked;
        if (cranked)
        {
            spriteRenderer.sprite = crankedDownSprite;
        }
        else
        {
            spriteRenderer.sprite = crankedUpSprite;
        }
        OnToggle.Invoke();
    }
}
