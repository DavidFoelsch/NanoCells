using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationTracker : MonoBehaviour
{
    public GameObject tCellHolder;
    public AudioSource winSound;
    public AudioSource matchedSound;
    public AudioSource backgroundMusic;
    public UITimer uiTimer;
    public GameObject endScreen;


    int activatedCells = 0;
    int totalCells = -1;

    // Start is called before the first frame update
    void Start()
    {
        totalCells = tCellHolder.transform.childCount;
        Debug.Log("TCells found: " + totalCells.ToString());
    }

    public bool deactivateTCell()
    {
        activatedCells++;

        Debug.Log("Found " + activatedCells.ToString() + " of " + totalCells.ToString());

        if(activatedCells == totalCells)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void EndGame()
    {
        Debug.Log("GAME ENDED");

        backgroundMusic.Stop();
        matchedSound.Play();

        Invoke("EndGameSequence", 2.0f);
    }

    private void EndGameSequence()
    {
        winSound.Play();

        endScreen.SetActive(true);

        uiTimer.StopTimer();
    }
}
