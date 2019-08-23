using System.Collections;
using System.Collections.Generic;
using QF;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.MFO
{
    public class UITools : ISingleton
    {
        private UITools()
        {
            
        }
        /// <summary>
        /// ÇÐ»»ImageµÄÍ¼Æ¬
        /// </summary>
        /// <param name="image"></param>
        /// <param name="resName"></param>
        public void ChanegeImage(Image image, string resName)
        {
            image.sprite = ResLoadManage.Instance.mResLoader.LoadSprite(resName);
        }

        public static UITools Instance
        {
            get { return SingletonProperty<UITools>.Instance; }
        }
        public void OnSingletonInit()
        {
        }
    }
}
