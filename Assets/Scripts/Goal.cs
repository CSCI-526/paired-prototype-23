using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject timer;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Collided with " + col.gameObject.name);

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
}
