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
                Debug.LogWarning("End Screen reference is missing in OnTriggerEnter2D!");
            }
        }
    }

    void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        // Only load if there's another scene after this one
        if (currentScene + 1 < totalScenes)
        {
            SceneManager.LoadScene(currentScene + 1);
        }
        else
        {
            Debug.Log("Final scene reached — not loading another scene.");
            // You can optionally show a "Thanks for playing!" message here
        }
    }
}
