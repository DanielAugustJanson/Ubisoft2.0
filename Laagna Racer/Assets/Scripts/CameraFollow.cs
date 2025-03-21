using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public float positionSmoothness;
    [SerializeField] public float rotationSmoothness;
    [SerializeField] public float cameraRisingMulitplier;
    public Transform Following;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {   
        //Maybe try LateUpdate later?
        Vector3 CarPosition = Following.transform.position;
        CarPosition.y += VelocityToCamera(); //Lisab kaamera Y teljele k�rgust mida kiirem see on.
        transform.position = Vector3.Lerp(transform.position, CarPosition, positionSmoothness);
        transform.rotation = Quaternion.Slerp(transform.rotation, Following.rotation, rotationSmoothness);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));

    }
    public void SetCameraToStart()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    public float VelocityToCamera()
    {
        float endValue;
        float speedOfCar = Following.GetComponent<Rigidbody>().velocity.magnitude;
        endValue = speedOfCar * cameraRisingMulitplier;

        return endValue;
    }

    
    //LateUpdate is called every frame, if the Behaviour is enabled.

    //LateUpdate is called after all Update functions have been called.
    //This is useful to order script execution.For example a follow camera should always be implemented in LateUpdate because it tracks objects that might have moved inside Update.
}
