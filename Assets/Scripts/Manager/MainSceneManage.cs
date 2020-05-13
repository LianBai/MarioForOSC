using QF.Res;
using System.Collections;
using System.Collections.Generic; 
using QF;
using QF.Extensions;
using UnityEngine;

namespace QFramework.MFO
{
    public class MainSceneManage : MonoBehaviour
    {
        
        void Awake()
        {

            //Debug.LogError(posData);
            CacheDataManage.Instance.RescoveyCacheData();
            ResLoadManage.Instance.mResLoader
                .LoadSync<GameObject>("mainsceneground")
                .Instantiate();
        }
        void Start()
        {
            ResLoadManage.Instance.OpenInitPanel(PanelType.MainPanel);
        }

    }
}

