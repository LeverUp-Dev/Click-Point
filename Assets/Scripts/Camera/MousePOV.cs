using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraRig))]
public class MousePOV : MonoBehaviour
{
    public float XSensitivity = 2f;
    public float YSensitivity = 2f;
    public bool clampVerticalRotation = true;
    public float MinimumX = -90F;
    public float MaximumX = 90F;
    public bool smooth;
    public float smoothTime = 5f;
    public bool lockCursor = true;


    private Quaternion yAxis;
    private Quaternion xAxis;
    private CameraRig rig;

    void Start()
    {
        rig = GetComponent<CameraRig>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)) {
            if (GameManager.ins.IVCanvas.gameObject.activeInHierarchy || GameManager.ins.obsCam.gameObject.activeInHierarchy)
                return;

            yAxis = rig.YAxis.localRotation;
            xAxis = rig.XAxis.localRotation;
            LookRotation();
        }
    }

    public void LookRotation()
    {
        float yRot = Input.GetAxis("Mouse X") * XSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

        yAxis *= Quaternion.Euler(0f, yRot, 0f);
        xAxis *= Quaternion.Euler(-xRot, 0f, 0f);

        if (clampVerticalRotation)
            xAxis = ClampRotationAroundXAxis(xAxis);

        if (smooth)
        {
            rig.YAxis.localRotation = Quaternion.Slerp(rig.YAxis.localRotation, yAxis,
                smoothTime * Time.deltaTime);
            rig.XAxis.localRotation = Quaternion.Slerp(rig.XAxis.localRotation, xAxis,
                smoothTime * Time.deltaTime);
        }
        else
        {
            rig.YAxis.localRotation = yAxis;
            rig.XAxis.localRotation = xAxis;
        }
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}