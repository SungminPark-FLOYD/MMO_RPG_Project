using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    //이벤트 뿌리기
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    bool _pressed = false;

    public void OnUpdate()
    {
        //이벤트 발생시 리턴
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if(Input.anyKey && KeyAction != null) 
            KeyAction.Invoke();
        if(MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else
            {
                if (_pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
                _pressed = false;
            }
        }
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}
