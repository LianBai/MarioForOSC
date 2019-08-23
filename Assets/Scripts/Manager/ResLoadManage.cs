using System.Collections;
using System.Collections.Generic;
using QF;
using QF.Res;
using UnityEngine;

namespace QFramework.MFO
{
    public class ResLoadManage : ISingleton
    {
        public ResLoader mResLoader = ResLoader.Allocate();
        private ResLoadManage()
        {
            ResMgr.Init();
        }
        public static ResLoadManage Instance
        {
            get { return SingletonProperty<ResLoadManage>.Instance; }
        }
        public void OnSingletonInit()
        {
            
        }
    }
}
