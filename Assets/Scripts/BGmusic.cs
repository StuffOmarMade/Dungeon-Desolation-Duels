using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGmusic : MonoBehaviour
{
    public static BGmusic instance;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        // Check if the active scene is "Lobby" and pause the music
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            GetComponent<AudioSource>().Pause();
        }
        
    }
}

public class SceneSwitcher : MonoBehaviour
{
    void Update()
    {
        // Check for space key press to load the next scene
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
