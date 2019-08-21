using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MarioForOSC
{
    public class PickCoinGo : BaseGameObject
    {

        private Animation Anim;

        public override void Init()
        {
            base.Init();
            Anim = GetComponent<Animation>();

        }
        public override void LateInit()
        {
            base.LateInit();
            Anim.Stop();
            Invoke("PlayAnim", Random.Range(0.1f, 1f));
        }
        public void PlayAnim()
        {
            Anim.Play();
        }
        public override void OnHide()
        {
            base.OnHide();
            PickPoolManage.instance.RecyCoin(transform);
        }
    }
}
