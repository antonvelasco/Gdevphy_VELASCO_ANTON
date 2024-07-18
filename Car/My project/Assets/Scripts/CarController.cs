using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    #region Variables
    public GameObject Car;
    private CarScript car;
    #endregion

    #region Private Functions
    private void Start()
    {
        GetCar();
    }

    private void Update()
    {
        CarControls();
    }
    #endregion

    #region Public Functions
    public void GetCar()
    {
        if (Car != null)
        {
            if (Car.GetComponent<CarScript>())
                car = Car.GetComponent<CarScript>();
        }
    }
    public void CarControls()
    {
        //Pandrive sheesh :>
        if (Input.GetKey(KeyCode.W))
        {
            car.Accelerate();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            car.AccelerateBackwards();
        }
        else
        {
            car.Decelerate();
        }

        //Pangliko
        if (Input.GetKey(KeyCode.D))
            car.SteerRight();
        else if (Input.GetKey(KeyCode.A))
           car.SteerLeft();
        else
            car.SteerRelease();

    }
    #endregion
}
