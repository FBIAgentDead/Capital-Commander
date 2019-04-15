using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField]
    Transform target;

    private void Start()
    {
        GetComponent<SteeringVehicle>().SetTarget(target.position);
        GetComponent<SteeringVehicle>().Arrived += SetAgain;
    }

    private void SetAgain()
    {
        GetComponent<SteeringVehicle>().SetTarget(target.position);
    }

}
