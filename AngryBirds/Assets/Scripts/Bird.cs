using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bird : MonoBehaviour
{
    #region Variables
    [Header("PullPower & Max Pull Distance")]
    [SerializeField] private float MaxPullDistance;
    [SerializeField] private float MaxPower;
    private Vector3 Origin;
    private Vector3 Position;
    private bool Dragging = false;
    private bool Released = false;
    private float Distfromorigin;
    private Vector3 _offset;

    [Header("Bounds")]
    [SerializeField] private Camera cam;

    [Header("Debuffs")]
    [SerializeField] private float Gravity;
    [SerializeField] private float WindEffect;

    public Vector2 Velocity;
    #endregion

    #region MonoBehaviour Methods
    private void Start()
    {
        InitializeBird();
        
    }

    private void Update()
    {
        if (Released)
        {
            ApplyGravity();
            MoveBird();
            CheckScreenBounds();
        }
    }
    #endregion

    #region Private Methods



    private void InitializeBird()
    {
        Origin = transform.position;
    }
    
    private void ApplyGravity()
    {
        Velocity.y += Gravity * Time.deltaTime;
        Velocity.x += WindEffect * Time.deltaTime; //Wind effect sheeesh
    }

    private void MoveBird()
    {
        transform.Translate(Velocity * Time.deltaTime);
    }
   
    private void CheckScreenBounds()
    {
        if (IsOutOfBounds())
        {
            ResetBird();
        }
    }

    private bool IsOutOfBounds()
    {
        float orthographicWidth = cam.orthographicSize * cam.aspect;
        return transform.position.x > orthographicWidth ||
               transform.position.x < -orthographicWidth ||
               transform.position.y > cam.orthographicSize ||
               transform.position.y < -cam.orthographicSize;
    }

    private void OnMouseDown()
    {
        if (!Released)
        {
            Dragging = true;
            _offset = transform.position - GetMouseWorldPosition();
        }
    }

    private void OnMouseUp()
    {
        if (Dragging)
        {
            Dragging = false;
            Released = true;
            CalculateLaunchVelocity();
        }
    }

    private void OnMouseDrag()
    {
        if (Dragging)
        {
            DragBird();
        }
    }

    private void DragBird()
    {
        Position = GetMouseWorldPosition() + _offset;
        Distfromorigin = Vector3.Distance(Origin, Position);
        Position = ClampPositionToMaxPullDistance(Position);
        transform.position = Position;
    }

    private Vector3 ClampPositionToMaxPullDistance(Vector3 position)
    {
        Vector3 direction = position - Origin;
        if (direction.magnitude > MaxPullDistance)
        {
            direction = direction.normalized * MaxPullDistance;
        }
        return Origin + direction;
    }

    private void CalculateLaunchVelocity()
    {
        Vector3 launchDirection = (Origin - transform.position).normalized;
        Velocity = launchDirection * MaxPower * Distfromorigin;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10; // Distance of the mouse pointer from the camera
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void ResetBird()
    {
        transform.position = Origin;
        Released = false;
        Velocity = Vector2.zero;
    }
   
    #endregion

    #region Public Methods
    public Vector3 GetBirdPosition()
    {
        return Position;
    }
    #endregion
}
