using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    public RootData root;
    [SerializeField] private TextMeshPro cardName, rootDesc, affixDesc;
    [SerializeField] private TextMeshPro sideIndicator;
    private Hand hand;
    private Camera cam;
    [SerializeField] private float focusScale = 1.25f;
    public bool displayDefense = false;

    public Vector2 originalPosition;
    private void Start()
    {
        transform.position = originalPosition;
        if (cam == null)
        {
            cam = FindObjectOfType<Camera>();
        }

        if (hand == null)
        {
            hand = FindObjectOfType<Hand>();
        }

        if (root != null)
        {
            UpdateText();
        }
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }

    private void OnMouseUpAsButton()
    {
        if (transform.position.y < hand.handTopHeight)
        {
            transform.position = originalPosition;
        }
        else
        {
            Play();
        }
    }

    private void OnMouseEnter()
    {
        transform.localScale *= focusScale;
        Vector3 raisedPosition = originalPosition + Vector2.up *transform.localScale.y/2;
        transform.position = raisedPosition;
    }

    private void OnMouseExit()
    {
        if (flippedDisplay)
        {
            displayDefense = !displayDefense;
            flippedDisplay = false;
            UpdateText();
        }
        transform.localScale /= focusScale;
        transform.position = originalPosition;
    }

    private bool flippedDisplay = false;
    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            displayDefense = !displayDefense;
            flippedDisplay = true;
            UpdateText();
        }
        else if (Input.GetButtonUp("Fire2") && flippedDisplay)
        {
            displayDefense = !displayDefense;
            flippedDisplay = false;
            UpdateText();
        }
    }

    public void Play()
    {
        transform.localScale /= focusScale;
        hand.cards.Remove(this);
        hand.playerSpell.AddCard(root);
        hand.playedCards.Add(this);
        gameObject.SetActive(false);
        hand.UpdateHandOrder();
    }

    public void UpdateText()
    {
        sideIndicator.text = displayDefense ? "D" : "A";
        cardName.text = root.cardName;
        rootDesc.text = (displayDefense) ? root.rootDescriptionDefense : root.rootDescriptionAttack;
        affixDesc.text = (displayDefense) ? root.affixDescriptionDefense : root.affixDescriptionAttack;
    }
    
    
    
    
}
