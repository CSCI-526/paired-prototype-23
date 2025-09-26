using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float startTime = 60f; // countdown time in seconds

    [Header("UI Reference")]
    public TextMeshProUGUI timerText;

    private float currentTime;
    private bool isRunning = false;

    void Start()
    {
        currentTime = startTime;
        isRunning = true;
    }

    void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isRunning = false;
            // You can trigger an event here, e.g. GameOver()
        }

        // Format mm:ss
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
