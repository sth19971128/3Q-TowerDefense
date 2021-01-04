//=====================================================
// - FileName:      Tower.cs
// - Created:       Sth
// - CreateTime:      2021/01/04 10:34:39
// - Email:         438599338@qq.com
// - Description:   
// -  (C) Copyright 2008 - 2018,wegame ,Inc.
// -  All Rights Reserved.
//======================================================
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEditor.UI;
using UnityEngine;

public class Tower : myObject {
    
    // Use this for initialization
    void Start ()
    {
        type = (int)ConstConfig.ObjectType.Tower;
        Defence = 1234;
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    public void upgradeTower()
    {
    }
}