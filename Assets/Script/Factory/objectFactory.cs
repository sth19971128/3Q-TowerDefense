using System;
using UnityEngine;

namespace Script.Factory
{
    public class objectFactory:MonoBehaviour 
    {
        private static volatile objectFactory _instance;
        private static object _lock = new object();

        public static objectFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new objectFactory();
                        }
                    }
                }

                return _instance;
            }
        }

        private objectFactory()
        {
        }

        public GameObject createObject(Enum type,string prefabPath,Vector3 pos,Quaternion rotate)
        {
            GameObject tempInstance = null;
            switch (type)
            {
                case ConstConfig.ObjectType.TOWER:
                    Debug.Log("创建塔");
                    tempInstance = (GameObject)Instantiate(Resources.Load(prefabPath),pos,rotate);
                    break;
                case ConstConfig.ObjectType.MONSTER:
                    Debug.Log("创建怪物");
                    break;
                case ConstConfig.ObjectType.HERO:
                    Debug.Log("创建子弹");
                    break;
                default:
                    break;
            }
            return tempInstance;
        }
    }
}