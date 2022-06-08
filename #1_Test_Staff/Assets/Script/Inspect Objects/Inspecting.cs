using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspecting : MonoBehaviour
{
    Vector3 PosLasFrame;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Pizza;
    [SerializeField] float Distance;
    [SerializeField] GameObject CanvasInspect;
    [SerializeField] GameObject CamRenderUI;

    bool PickUp = false;
    private void Start()
    {
        CamRenderUI.SetActive(false);
    }
    private void Update()
    {
        if(Vector3.Distance(Player.transform.position,Pizza.transform.position)<Distance)
        {
            PickUp = true;
        }
        if(PickUp && Input.GetKeyDown(KeyCode.E))
        {
            Pizza.transform.position = transform.position;
            Pizza.transform.eulerAngles = transform.eulerAngles;
            CanvasInspect.SetActive(true);
            CamRenderUI.SetActive(true);
        }
        if(CanvasInspect.active)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PosLasFrame = Input.mousePosition;
            }
            if(Input.GetMouseButton(0))
            {
                var dir = Input.mousePosition - PosLasFrame;
                PosLasFrame = Input.mousePosition;
                var Axis = Quaternion.AngleAxis(-90, Vector3.forward) * dir;
                Pizza.transform.rotation = Quaternion.AngleAxis(dir.magnitude * 0.1f,Axis) * Pizza.transform.rotation;
            }
        }
    }
}
