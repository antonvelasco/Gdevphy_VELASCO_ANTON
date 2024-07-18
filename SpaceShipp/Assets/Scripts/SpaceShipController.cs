using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    #region Variables
    
    public GameObject Car;
    private SpaceShip car;
    private bool Turning = false;
    #endregion

    #region Private Functions
    private void Start()
    {
        GetCar();
    }

    private void Update()
    {
//transform.Translate(Vector3.forward * car.CurrentSpeed);
        CarControls();
    }
    #endregion

    #region Public Functions
    public void GetCar()
    {
        if (Car != null)
        {
            if (Car.GetComponent<SpaceShip>())
                car = Car.GetComponent<SpaceShip>();
        }
    }
    public void CarControls()
    {
        //Pandrive sheesh :> 
        if (Input.GetKey(KeyCode.Space) && Turning == false || (Input.GetKey(KeyCode.Z) && Turning == false))
        {
            
            car.Accelerate();
        }
        else
        {
            car.Decelerate();
        }

        ////Pangliko
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    car.SteerRight();
        //    Turning = true;
        //}
        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    car.SteerRelease();
        //    Turning = false;
        //}

        //else if (Input.GetKeyDown(KeyCode.A))
        //{
        //    car.SteerLeft();
        //    Turning = true;
        //}
        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    car.SteerRelease();
        //    Turning = false;
        //}
        

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            Turning = true;
            if (Input.GetKeyDown(KeyCode.D)) car.SteerRight();
            if (Input.GetKeyDown(KeyCode.A)) car.SteerLeft();
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            Turning = false;
            car.SteerRelease();
        }

    }
        #endregion
    }
