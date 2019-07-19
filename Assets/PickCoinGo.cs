using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MarioForOSC
{
    public class PickCoinGo : BaseGameObject
    {

        public override void Init()
        {
            base.Init();
            //PickPoolManage.instance.RecyCoin(gameObject);
        }

        public override void OnHide()
        {
            base.OnHide();
            PickPoolManage.instance.RecyCoin(transform);
        }
    }
}
