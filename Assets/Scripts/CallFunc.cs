using UnityEngine;
using System.Collections;

// 该委托不传任何参数
public delegate void CallFunc();
// 该委托会传入发生事件的GameObject，即sender
public delegate void CallFuncO(GameObject sender);
// 该委托会传入发生事件的GameObject，即sender。和一个变长参数列表
public delegate void CallFuncOP(GameObject sender, params object[] list);
