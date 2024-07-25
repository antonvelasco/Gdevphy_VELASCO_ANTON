using UnityEngine;

public class Blackhole : MonoBehaviour
{
    #region Variables
    [Header("Bird Reference")]
    [SerializeField] private Bird _bird;
    private Vector3 _birdPosition;

    [Header("Blackhole Stats")]
    [SerializeField] private float _pullStrength;
    [SerializeField] private float _pullRange;

    private float _distanceFromBird;
    private float _xPull;
    private float _yPull;
    #endregion

    #region Private Functions
    private void Update()
    {
        CheckBird();
        Pull();
    }

    private void CheckBird()
    {
        transform.Rotate(0.0f, 0.0f, -0.10f);
        _birdPosition = _bird.GetBirdPosition();
        _distanceFromBird = Vector3.Distance(transform.position, _birdPosition);
    }

    private void Pull()
    {
        if (_distanceFromBird < _pullRange)
        {
            _xPull = _distanceFromBird * _pullStrength;
            _yPull = _distanceFromBird * _pullStrength;
            if (transform.position.x < _bird.GetBirdPosition().x)
            {
                _bird.Velocity.x -= _xPull;
            }
            else if (transform.position.x > _bird.GetBirdPosition().x)
            {
                _bird.Velocity.x += _xPull;
            }
            if (transform.position.y < _bird.GetBirdPosition().y)
            {
                _bird.Velocity.y -= _yPull;
            }
            else if (transform.position.y > _bird.GetBirdPosition().y)
            {
                _bird.Velocity.y += _yPull;
            }
        }
    }
    #endregion
}
