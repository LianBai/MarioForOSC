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
        /// <summary>
        /// ��ʼ�����ؽ�ң�ֻ����ض���صĶ������
        /// </summary>
        /// <param name="level"></param>
        public void InitPickCoin(int level)
        {
            var jsonText = ResLoadManage.Instance.mResLoader
                .LoadSync<TextAsset>("pickup_game_" + level.ToString()).text;
            mCoinPosList = jsonText.FromJson<Queue<Vector3>>();
            //����dotween�γɼ�����ؽ�ҴӶ����ɲ�ͬ������
            int temp = 0;
            mAllocTransforms.ForEach(coinTf => mSequence.Append(DOTween.To(
                () => temp, x => temp = x, temp, 0.02f
                )
                .OnComplete(() =>
                {
                    AddCoin(coinTf);
                })
                ));
            //mAllocTransforms.ForEach(coinTf => AddCoin(coinTf));
        }

        /// <summary>
        /// ����ұ��Ե����ҽ��л���
        /// </summary>
        /// <param name="tF"></param>
        public void RecyCoin(Transform tF)
        {
            if (mCoinPosList.Count != 0)
            {
                //StartCoroutine(AddCoin(tF));
            }
            else
            {
                tF.gameObject.SetActive(false);
            }
        }
        /// <summary>
        /// ����һ����ʾ�Ľ��
        /// </summary>
        /// <param name="coinTf"></param>
        /// <returns></returns>
        public void AddCoin(Transform coinTf)
        {
            coinTf.ApplySelfTo(self =>
            {
                //var coinClip = self.GetComponent<Animation>().clip;
                //AnimationEvent coinPlayEvent = new AnimationEvent();
                //coinPlayEvent.time = 1.0f * Random.Range(0, 10) / 10f;
                self.localPosition = mCoinPosList.Dequeue();
                self.gameObject.SetActive(true);
                //coinClip.AddEvent(coinPlayEvent);
                //self.gameObject.GetComponent<Animation>().clip = 0.1f*Random.Range(0,10);
            });
        }
     }
}
