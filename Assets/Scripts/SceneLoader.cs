using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadSceneByIndex(int idx)
    {
            Debug.Log("Scene Loading: " + idx.ToString());
            SceneManager.LoadScene(idx, LoadSceneMode.Single);
    }
}
