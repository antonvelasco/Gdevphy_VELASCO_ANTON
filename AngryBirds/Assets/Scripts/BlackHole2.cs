using UnityEngine;

public class Blackhole2 : MonoBehaviour
{
    #region Variables
    [Header("Bird Reference")]
    [SerializeField] private Bird _bird;

    [Header("Blackhole Stats")]
    [SerializeField] private float pullStr;
    [SerializeField] private float pullRange;

    private Vector3 birdPos;
    private float disFromBird;
    private Vector3 pullDir;
    #endregion

    #region Private Functions
    private void Update()
    {
        transform.Rotate(0.0f, 0.0f, -0.25f);
        ApplyBlackholeEffect();
    }

    private void ApplyBlackholeEffect()
    {
        if (_bird == null) return;

        birdPos = _bird.GetBirdPosition();
        disFromBird = Vector3.Distance(transform.position, birdPos);

        if (disFromBird < pullRange)
        {
            //v1
            /* 
            _pullDirection = (transform.position - _birdPosition).normalized; 
            float pullForce = (_pullRange - _distanceFromBird) / _pullRange * _pullStrength;
            _bird.Velocity += (Vector2)(_pullDirection * pullForce) * Time.deltaTime;
            */
            // Calculate pull direction and strength
            pullDir = (transform.position - birdPos).normalized; // Pull towards the black hole
            float pullForce = (pullRange - disFromBird) / pullRange * pullStr;

            // Apply the force to the bird's velocity
            _bird.Velocity += (Vector2)(pullDir * pullForce) * Time.deltaTime;

            // Optional: You can add a visual or debugging indication here
            Debug.DrawLine(birdPos, birdPos + pullDir * pullRange, Color.red); 
        }
    }
    #endregion
}
