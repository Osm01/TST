using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTragetManager : MonoBehaviour
{

    [SerializeField] List<GameObject> Chars;
    [SerializeField] Vector3 Offset;
    [SerializeField] float smoothTime = .5f;
    [SerializeField] float MaxZoom;
    [SerializeField] float MinZoom;
    [SerializeField] float ZoomLimiter;
    private Vector3 velocity;
    private Camera cam;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        Move();
        Zoom();
    }
    private void Move()
    {
        Vector3 CenterPoints = GetCenterPoints();
        CenterPoints += Offset;
        transform.position = Vector3.SmoothDamp(transform.position, CenterPoints, ref velocity, smoothTime);
    }
    void Zoom()
    {
        float Distance = Mathf.Lerp(MaxZoom,MinZoom, GetGreatestDistance()/ZoomLimiter);
        Debug.Log(GetGreatestDistance());
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, Distance,Time.deltaTime);
    }
    float GetGreatestDistance()
    {
        var _Bounds = new Bounds(Chars[0].transform.position, Vector3.zero);
        for (int i = 0; i < Chars.Count; i++)
        {
            _Bounds.Encapsulate(Chars[i].transform.position);
        }
        return _Bounds.size.x;
    }
    Vector3 GetCenterPoints()
    {
        var _Bounds = new Bounds(Chars[0].transform.position, Vector3.zero);
        for (int i = 0; i < Chars.Count; i++)
        {
            _Bounds.Encapsulate(Chars[i].transform.position);
        }
        return _Bounds.center;
    }
}
