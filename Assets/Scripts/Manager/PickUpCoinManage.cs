using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using QF;
using UniRx;
using QF.Res;
using QF.Extensions;
using UnityEngine;

namespace QFramework.MFO
{
    public class PickUpCoinManage : MonoSingleton<PickUpCoinManage>
    {
        public ResLoader mResLoader;
        
        public List<Transform> mAllocTransforms;
        public Queue<Vector3> mCoinPosList;

        public override void OnSingletonInit()
        {
            mResLoader = ResLoader.Allocate();
            mAllocTransforms = new List<Transform>();
            mCoinPosList = new Queue<Vector3>();

            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
                mAllocTransforms.Add(child);
            }
        }
        /// <summary>
        /// 初始化加载金币，只会加载对象池的对象个数
        /// </summary>
        /// <param name="level"></param>
        public void InitPickCoin(int level)
        {
            var jsonText = ResLoadManage.Instance.mResLoader
                .LoadSync<TextAsset>("pickup_game_" + level.ToString()).text;
            mCoinPosList = jsonText.FromJson<Queue<Vector3>>();
            mAllocTransforms.ForEach(coinTf => StartCoroutine(AddCoin(coinTf)));
        }
        /// <summary>
        /// 当金币被吃掉后金币进行回收
        /// </summary>
        /// <param name="tF"></param>
        public void RecyCoin(Transform tF)
        {
            if (mCoinPosList.Count != 0)
            {
                StartCoroutine(AddCoin(tF));
            }
        }
        /// <summary>
        /// 增加一个显示的金币
        /// </summary>
        /// <param name="coinTf"></param>
        /// <returns></returns>
        public IEnumerator AddCoin(Transform coinTf)
        {
            yield return new WaitForSeconds(0.1f);
            coinTf.ApplySelfTo(self =>
            {
                self.localPosition = mCoinPosList.Dequeue();
                self.gameObject.SetActive(true);
            });
        }
    }
}
