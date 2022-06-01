using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations.Rigging;
public class MyCameraCinemachine : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachinevirtualcamera;
    private CinemachineTransposer cinemachinetransposer;
    private MultiAimConstraint multiaimconstraint;
    private CinemachineTargetGroup cinemachinetargetgroup;
    [SerializeField] Transform TargetGroupFocus;
    [SerializeField] Transform PlayerFocus;
    SecondCharacterScript secondcharacterScript;
    private void Awake()
    {
        cinemachinevirtualcamera = GetComponent<CinemachineVirtualCamera>();
        secondcharacterScript = FindObjectOfType<SecondCharacterScript>();
        cinemachinetransposer = cinemachinevirtualcamera.GetCinemachineComponent<CinemachineTransposer>();
        cinemachinetargetgroup = GameObject.Find("Target Group").GetComponent<CinemachineTargetGroup>();
        multiaimconstraint = GameObject.Find("Rig 1").GetComponent<MultiAimConstraint>();
    }
    private void Update()
    {
        if (secondcharacterScript.IsCol)
        {
            cinemachinevirtualcamera.Follow = TargetGroupFocus;
            cinemachinevirtualcamera.LookAt = TargetGroupFocus;
            cinemachinetransposer.m_FollowOffset.z = -6f;
            //multiaimconstraint.weight = 1f;
        }
        else
        {
            cinemachinevirtualcamera.Follow = PlayerFocus;
            cinemachinevirtualcamera.LookAt = PlayerFocus;
            cinemachinetransposer.m_FollowOffset.z = -10f;
            //multiaimconstraint.weight = .3f;
        }
        float Distance = (cinemachinetargetgroup.BoundingBox.size.x + cinemachinetargetgroup.BoundingBox.size.y + cinemachinetargetgroup.BoundingBox.size.z) / 10f;
         multiaimconstraint.weight = Mathf.Lerp(1,0,Distance);
    }
}
