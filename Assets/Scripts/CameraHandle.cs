using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraHandle : MonoBehaviour
{
    public DataHandle DataHandle;

    public GameObject cameraObject;
    public Slider sliderObject;

    private float x_max;
    private float x_min;
    private float multiplier;

    public void UpdateCameraPosition()
    {
        float z_pos = sliderObject.value * multiplier;
   
        cameraObject.transform.position = new Vector3(sliderObject.value, DataHandle.BTC.transform.position.y, z_pos) ;
        //Debug.Log(sliderObject.value);
    }

    public void setValues()
    {
        x_max = DataHandle.BTC.transform.position.x; //+ DataHandle.BTC.transform.localScale.x / 2;
        x_min = DataHandle.SOL.transform.position.x; // - DataHandle.SOL.transform.localScale.x / 2;

        sliderObject.minValue = x_min;
        sliderObject.maxValue = x_max;

        multiplier = (45000 / x_max) * -1;
    }
}
