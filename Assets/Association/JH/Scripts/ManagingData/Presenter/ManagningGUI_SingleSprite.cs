using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ManagningGUI_SingleSprite : iManagningGUI<Sprite>
{
    // 특정변수 set() 발생 시, Event.invoke 되도록 대응시킴

    // 인스펙터상에서 보여주기용 name string
    public string _comment = "comment to mark";

    // bool OnInitInvoke -> 대응 시 이벤트 발생 여부 ( 변수 동기화시 대응과 동시에 초기화가 필요하므로 true )
    public bool OnInitInvoke = true;

    // UnityEvent<int> eventSet -> 대응 시킬 이벤트
    public UnityEvent<Sprite> eventSet;

    // 활성화 - 할당   /    비활성화 - 할당해제 
    public Action _OnEnableAction;
    public Action _OnDisableAction;

    #region iReactingGUI<int> implementation
    public Action<Sprite> Reaction => eventSet.Invoke;
    public Action OnEnableAction => _OnEnableAction;
    public Action OnDisableAction => _OnDisableAction;
    #endregion
}
