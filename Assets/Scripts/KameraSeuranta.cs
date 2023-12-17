using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraSeuranta : MonoBehaviour
{
    public float tarinaVaihe;
    public bool peliLoppu = false;

    public GameObject playerTO;
    private Vector3 offsetTO;

    void Start()
    {
        offsetTO = transform.position - playerTO.transform.position;
    }

    void LateUpdate()
    {
        if (!peliLoppu)
        {
            transform.position = playerTO.transform.position + offsetTO;
        }
    }
}
