//=====================================================
// - FileName:      myObject.cs
// - Created:       Sth
// - CreateTime:      2021/01/04 09:57:01
// - Email:         438599338@qq.com
// - Description:   
// -  (C) Copyright 2008 - 2018,wegame ,Inc.
// -  All Rights Reserved.
//======================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class myObject : MonoBehaviour
{
    #region 定义私有成员变量
    private int _Hp;

    private int _Attack;
    
    private int _Defence;

    public int type;
    #endregion
    public int Attack
    {
        get => _Attack;
        set => _Attack = value;
    }

    public int Defence
    {
        get => _Defence;
        set => _Defence = value;
    }

    public int Hp
    {
        get => _Hp;
        set => _Hp = value;
    }


    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        
    }
}