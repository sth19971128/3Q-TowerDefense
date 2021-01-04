//=====================================================
// - FileName:      TowerBase.cs
// - Created:       Sth
// - CreateTime:      2021/01/04 14:49:45
// - Email:         438599338@qq.com
// - Description:   
// -  (C) Copyright 2008 - 2018,wegame ,Inc.
// -  All Rights Reserved.
//======================================================

using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using Script.Factory;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TowerBase : MonoBehaviour {
    
    // Use this for initialization
    void Start ()
    {

    }
    
    // Update is called once per frame
    void Update () {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("beidianji1le1");
        Vector3 tempVector3 = transform.position;
        tempVector3.y += transform.GetComponent<BoxCollider>().size.y/2;
        GameObject tempObject = objectFactory.Instance.createObject(ConstConfig.ObjectType.TOWER, ConstConfig.Instance.PrefabPath,
            tempVector3,new Quaternion());
        tempObject.transform.position = new Vector3(tempVector3.x,
            tempVector3.y + tempObject.GetComponent<BoxCollider>().size.y-0.2f, tempVector3.z);
    }
}