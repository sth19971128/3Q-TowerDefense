namespace Script
{
    public class ConstConfig
    {
        private static volatile ConstConfig _instance;
        private static object _lock = new object();

        public static ConstConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ConstConfig();
                        }
                    }
                }

                return _instance;
            }
        }

        private ConstConfig()
        {
        }



        public string PrefabPath = "Prefabs/Tow_Rocket2_3";
        
        public enum ObjectType
        {
            TOWER,//塔
            MONSTER,//怪物
            HERO, //暂定有英雄
        };
    }
}