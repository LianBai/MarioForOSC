using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using QF;
using QF.Action;
using UniRx;
using QF.Res;
using QF.Extensions;
using UnityEngine;

namespace QFramework.MFO
{
    public class PickUpCoinManage : MonoSingleton<PickUpCoinManage>
    {
        public ResLoader mResLoader;
        public Sequence mSequence;
        public List<Transform> mAllocTransforms;
        public Queue<Vector3> mCoinPosList;

        public override void OnSingletonInit()
        {
            mResLoader = ResLoader.Allocate();
            mSequence = DOTween.Sequence();
            mAllocTransforms = new List<Transform>();
            mCoinPosList = new Queue<Vector3>();

            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
                mAllocTransforms.Add(child);
            }
        }
        public void InitPickCoin(int level)
        {
            var jsonText = ResLoadManage.Instance.mResLoader
                .LoadSync<TextAsset>("pickup_game_" + level.ToString()).text;
            mCoinPosList = jsonText.FromJson<Queue<Vector3>>();
            int temp = 0;
            mAllocTransforms.ForEach(coinTf => mSequence.Append(DOTween.To(
                () => temp, x => temp = x, temp, 0.02f
                )
                .OnComplete(() =>
                {
                    AddCoin(coinTf);
                })
                ));
        }
        public void RecyCoin(Transform tF)
        {
            if (mCoinPosList.Count != 0)
            {
                tF.gameObject.SetActive(false);
            }
            else
            {
                tF.gameObject.SetActive(false);
            }
        }
        public void AddCoin(Transform coinTf)
        {
            coinTf.ApplySelfTo(self =>
            {
                self.localPosition = mCoinPosList.Dequeue();
                self.gameObject.SetActive(true);
            });
        }
     }
}
