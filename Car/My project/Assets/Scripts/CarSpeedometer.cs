using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class CarSpeedometer : MonoBehaviour
{
    public TMP_Text Speedometerr;
    public Slider Speedometer; 
    public CarScript carScript;

    // Start is called before the first frame update
    void Start()
    {
       
        Speedometerr.maxVisibleCharacters = 4;
    }

    // Update is called once per frame
    void Update()
    {
       Speedometerr.text=carScript.GetSpeed().ToString();
    Speedometer.value = carScript.GetSpeed();
        Speedometer.maxValue = carScript.GetTopSpeed();
    }
}
