using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        // Check if the next scene index is within the build index range
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene without adding it to the current scene
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No more scenes in build settings. Unable to load the next scene.");
        }
    }
}
