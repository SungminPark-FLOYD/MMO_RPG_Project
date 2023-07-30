using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;
    [SerializeField]
    Vector3 _delta = new Vector3(0, 6.0f, -5.0f);
    [SerializeField]
    GameObject _player = null;
    void Start()
    {
        
    }
 
    void LateUpdate()
    {
        //카메라 위치 정의
        if(_mode == Define.CameraMode.QuarterView)
        {
            RaycastHit hit;
            if(Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                //카메라에서 ray를 보내서 Wall에 닿으면 player쪽에 가깝게 위치하도록 설정
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
                //거리만 이동하기를 원하기 때문에 _delta값에 normalized를 해준다
                transform.position = _player.transform.position + _delta.normalized * dist;
            }
            else
            {
                transform.position = _player.transform.position + _delta;
                transform.LookAt(_player.transform);
            }
                    
        }
        
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
