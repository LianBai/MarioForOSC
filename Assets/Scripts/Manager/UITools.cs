using System.Collections;
using System.Collections.Generic;
using QF;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.MFO
{
    public class UITools : Singleton<UITools>
    {
        private UITools()
        {
            
        }
        /// <summary>
        /// �л�Image��ͼƬ
        /// </summary>
        /// <param name="image"></param>
        /// <param name="resName"></param>
        public void ChanegeImage(Image image, string resName)
        {
            image.sprite = ResLoadManage.Instance.mResLoader.LoadSprite(resName);
        }

    }
}
