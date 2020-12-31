using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CameraMoveControl : MonoBehaviour
{
    public Transform tourCamera;
    //相机移动的参数

    #region 相机移动参数
    public float _moveSpeed = 5.0f;
    public float _rotateSpeed = 90.0f;
    public float _shiftAddSpeed = 2.0f;//按住shift加速
    public float _mindistance = 0.5f;//相机距离不可穿过
    #endregion

    #region 运动速度和其每个方向的速度分量
    private Vector3 _direction = Vector3.zero;
    private Vector3 _speedForward;
    private Vector3 _speedBack;
    private Vector3 _speedLeft;
    private Vector3 _speedRight;
    private Vector3 _speedUp;
    private Vector3 _speedDown;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        if (tourCamera == null)
        {
            tourCamera = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetDirection();
        // 检测是否离不可穿透表面过近
        RaycastHit hit;
        while (Physics.Raycast(tourCamera.position, _direction, out hit, _mindistance))
        {
            // 消去垂直于不可穿透表面的运动速度分量
            float angel = Vector3.Angle(_direction, hit.normal);
            float magnitude = Vector3.Magnitude(_direction) * Mathf.Cos(Mathf.Deg2Rad * (180 - angel));
            _direction += hit.normal * magnitude;
        }
        tourCamera.Translate(_direction * _moveSpeed * Time.deltaTime, Space.World);
    }

    private void GetDirection()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) _moveSpeed *= _shiftAddSpeed;
        if (Input.GetKeyUp(KeyCode.LeftShift)) _moveSpeed /= _shiftAddSpeed;
        
        _speedForward = Vector3.zero;
        _speedBack = Vector3.zero;
        _speedLeft = Vector3.zero;
        _speedRight = Vector3.zero;
        _speedUp = Vector3.zero;
        _speedDown = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) _speedForward = tourCamera.forward;
        if (Input.GetKey(KeyCode.S)) _speedBack = -tourCamera.forward;
        if (Input.GetKey(KeyCode.A)) _speedLeft = -tourCamera.right;
        if (Input.GetKey(KeyCode.D)) _speedRight = tourCamera.right;
        if (Input.GetKey(KeyCode.E)) _speedUp = Vector3.up;
        if(Input.GetKey(KeyCode.Q)) _speedDown = Vector3.back;
        _direction = _speedForward + _speedBack + _speedLeft + _speedRight + _speedUp + _speedDown;
        if (Input.GetMouseButton(1))
        {
            // 转相机朝向
            tourCamera.RotateAround(tourCamera.position, Vector3.up, Input.GetAxis("Mouse X") * _rotateSpeed * Time.deltaTime);
            tourCamera.RotateAround(tourCamera.position, tourCamera.right, -Input.GetAxis("Mouse Y") * _rotateSpeed * Time.deltaTime);
            // 转运动速度方向
            _direction = V3RotateAround(_direction, Vector3.up, Input.GetAxis("Mouse X") * _rotateSpeed * Time.deltaTime);
            _direction = V3RotateAround(_direction, tourCamera.right, -Input.GetAxis("Mouse Y") * _rotateSpeed * Time.deltaTime);
        }
    }
    
    public Vector3 V3RotateAround(Vector3 source, Vector3 axis, float angle)
    {
        Quaternion q = Quaternion.AngleAxis(angle, axis);// 旋转系数
        return q * source;// 返回目标点
    }
}
