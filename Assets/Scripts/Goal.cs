using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject timer;
    private bool levelComplete = false;

    void Start()
    { 
    }

    void Update()
    {
        if(levelComplete)
        {
            if(Input.GetMouseButtonDown(0))
            {
                LoadNextScene();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Collided with " + col.gameObject.name);
            levelComplete = true;

            if (endScreen != null)
            {
                timer.SetActive(false);
                endScreen.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No End Screen");
            }
        }
    }

    void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        // Check if it's at the last scene
        if (currentScene + 1 < totalScenes)
        {
            SceneManager.LoadScene(currentScene + 1);
        }
        else
        {
            Debug.Log("End");
        }
    }
}
