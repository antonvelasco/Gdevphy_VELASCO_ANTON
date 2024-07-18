using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    #region Variables
    [SerializeField] public float CurrentSpeed = 0.0f;
    [Range(0f, 30f)]
    [SerializeField] private float TopSpeed;
    [Range(0f, 30f)]
    [SerializeField] private float AccelerationSpeed;
    [Range(0f, 10f)]
    [SerializeField] private float DecelerationSpeed;
    [Range(0f, 10f)]
    [SerializeField] private float SetTurnSpeed;
    [SerializeField] private Camera SpaceCamera;
    private bool isMoving;
    private bool isMovingForward;
    private float TurnSpeed;
    #endregion

    #region Private Functions
    private void Update()
    {
       transform.Translate(Vector3.forward * CurrentSpeed);
        transform.Rotate(0.0f, TurnSpeed, 0.0f);
        CheckScreenBounds();
        if (CurrentSpeed > 0)
        {
            isMoving = true;
        }
        else if (CurrentSpeed < 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = false;
        }
    }
    #endregion

    #region Public Functions
    public void Accelerate()//move forward 
    {
        CurrentSpeed += AccelerationSpeed * Time.deltaTime;
        if (CurrentSpeed > TopSpeed)
            CurrentSpeed = TopSpeed;
    }
    public void Decelerate() 
    {
        //Decelerate downwards
        if (isMoving)
        {
            CurrentSpeed -= DecelerationSpeed  * Time.deltaTime;
            if (CurrentSpeed < 0)
                CurrentSpeed = 0;
        }
        //Decelerate upwards
        else if (!isMoving)
        {
            CurrentSpeed += DecelerationSpeed * Time.deltaTime;
            if (CurrentSpeed > 0)
                CurrentSpeed = 0;
        }
    }
    private void CheckScreenBounds()
    {
        if (transform.position.x > SpaceCamera.orthographicSize * 2)
            transform.position = new Vector3(-SpaceCamera.orthographicSize * 2 , -transform.position.y, 0.0f);
        if (transform.position.x < -SpaceCamera.orthographicSize * 2)
            transform.position = new Vector3(SpaceCamera.orthographicSize * 2 , -transform.position.y, 0.0f);
        if (transform.position.y > SpaceCamera.orthographicSize)
            transform.position = new Vector3(-transform.position.x, -SpaceCamera.orthographicSize , 0.0f);
        if (transform.position.y < -SpaceCamera.orthographicSize)
            transform.position = new Vector3(-transform.position.x, SpaceCamera.orthographicSize  , 0.0f);
    }
   
    public void SteerRight()
    {
        TurnSpeed = SetTurnSpeed;
    }
    public void SteerLeft()
    {
        TurnSpeed = -SetTurnSpeed;
    }

    public void SteerRelease()//Para mag gitna ulit yung manibela sheesh racer
    {
        TurnSpeed = 0.0f;
    }

    public float GetSpeed()
    {
        return CurrentSpeed;
    }

    public float GetTopSpeed()
    {
        return TopSpeed;
    }
    #endregion
}
