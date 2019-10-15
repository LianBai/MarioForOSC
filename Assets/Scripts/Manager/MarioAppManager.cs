using System.Collections;
using System.Collections.Generic;
using QF;
using UnityEngine;

namespace QFramework.MFO
{
    /// <summary>
    /// 整个项目的管理
    /// </summary>
    public class MarioAppManager : QSingleton<MarioAppManager>
    {
        /// <summary>
        /// 一个全局的容器，外部访问使用
        /// </summary>
        public static QFrameworkContainer Container
        {
            get { return MarioAppManager.Instance.mContainer; }
        }
        /// <summary>
        /// 一个全局的容器，内部访问使用
        /// </summary>
        private QFrameworkContainer mContainer { get; set; }

        private MarioAppManager()
        {
            mContainer = new QFrameworkContainer();
            mContainer.RegisterInstance<IQFrameworkContainer>(mContainer);

            //注册一些服务
            //注册UITools
            mContainer.RegisterInstance<IUITools>(new UITools());
        }

    }
}
