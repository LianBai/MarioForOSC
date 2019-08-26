using QF.Res;
using System.Collections;
using System.Collections.Generic;
using QF;
using QF.Extensions;
using UnityEngine;

namespace QFramework.MFO
{
    public class MainSceneManage : QMonoBehaviour
    {
        public override IManager Manager { get; }
        void Start()
        {
            ResLoadManage.Instance.OpenInitPanel(PanelType.MainPanel);
            ResLoadManage.Instance.mResLoader
                .LoadSync<GameObject>("mainsceneground")
                .Instantiate();
        }

    }
}
