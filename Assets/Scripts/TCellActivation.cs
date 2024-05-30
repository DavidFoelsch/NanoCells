using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCellActivation : MonoBehaviour
{
    public AudioSource touchedSound;
    public ActivationTracker activationTracker;
    public Sprite matchedSprite;

    SpriteRenderer sr;
    bool isActive = true;
    bool isLastCell = false;
    Color deactivatedColor = new Color(0.6f, 0.6f, 0.6f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision2d)
    {
        if (collision2d.gameObject.CompareTag("Player") && isActive)
        {
            isLastCell = activationTracker.deactivateTCell();

            if (isLastCell)
            {
                MatchedTCell();
                activationTracker.EndGame();
            }
            else
            {
                DeactivateTCell();
            }
            
        }
    }

    private void DeactivateTCell()
    {
        sr.color = deactivatedColor;
        isActive = false;
        touchedSound.Play();
    }

    private void MatchedTCell()
    {
        sr.sprite = matchedSprite;
        isActive = false;
        touchedSound.Play();
    }

}
