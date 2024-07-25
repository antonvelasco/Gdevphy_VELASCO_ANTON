using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    [Header("Bird Reference")]
    [SerializeField] private Bird _bird;

    [Header("UI Reference")]
    [SerializeField] private TextMeshProUGUI _goalText;

    [Header("Goal Detection")]
    [SerializeField] private float detectionRadius = 1f; // Radius for detection

    private void Start()
    {
        _goalText.gameObject.SetActive(false); // Ensure the text is hidden initially
    }

    private void Update()
    {
        CheckGoalReached();
    }

    private void CheckGoalReached()
    {
        // Get the bird's position
        Vector3 birdPosition = _bird.transform.position;

        // Get the goal's position
        Vector3 goalPosition = transform.position;

        // Check if the bird is within the detection radius of the goal
        float distance = Vector3.Distance(birdPosition, goalPosition);
        if (distance < detectionRadius)
        {
            Debug.Log("HIT");
            _goalText.gameObject.SetActive(true); // Enable the TextMeshPro object when the bird hits the goal
        }
    }
}
