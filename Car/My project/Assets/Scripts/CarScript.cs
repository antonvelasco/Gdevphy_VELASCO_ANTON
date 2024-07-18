using UnityEngine;

public class CarScript : MonoBehaviour
{
    #region Variables
    [SerializeField] private float CurrentSpeed = 0.0f;
    [SerializeField] private float TopSpeed;
    [SerializeField] private float AccelerationSpeed;
    [SerializeField] private float DecelerationSpeed;
    [SerializeField] private float BackwardSpeed;

    private bool isMovingForward;
    private bool isMoving;
    private float TurnSpeed;
    #endregion

    #region Private Functions
    private void Update()
    {
        transform.Translate(Vector3.forward * CurrentSpeed);
        transform.Rotate(0.0f, TurnSpeed, 0.0f);
        if (CurrentSpeed > 0)
        {
            isMovingForward = true;
            isMoving = true;
        }
        else if (CurrentSpeed < 0)
        {
            isMovingForward = false;
            isMoving = true;
        }
        else
        {
            isMovingForward = false;
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
        if (isMovingForward)
        {
            CurrentSpeed -= DecelerationSpeed  * Time.deltaTime;
            if (CurrentSpeed < 0)
                CurrentSpeed = 0;
        }
        //Decelerate upwards
        else if (!isMovingForward)
        {
            CurrentSpeed += DecelerationSpeed * Time.deltaTime;
            if (CurrentSpeed > 0)
                CurrentSpeed = 0;
        }
    }

    public void AccelerateBackwards()//movebackwards
    {
        CurrentSpeed -= BackwardSpeed * Time.deltaTime;
        if (CurrentSpeed < -TopSpeed)
            CurrentSpeed = -TopSpeed;
    }

    public void SteerRight()
    {
        if (isMoving)
        {
            TurnSpeed = 0.1f;
        }
         else if (!isMoving)
        {
            TurnSpeed = 0;
        }
    }

    public void SteerLeft()
    {
        if (isMoving)
        {
            TurnSpeed = -0.1f;
        }
        else if (!isMoving)
        {
            TurnSpeed = 0;
         }
            
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
