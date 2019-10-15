using System.Collections;
using System.Collections.Generic;
using QF;
using UnityEngine;

namespace QFramework.MFO
{
    /// <summary>
    /// ������Ŀ�Ĺ���
    /// </summary>
    public class MarioAppManager : QSingleton<MarioAppManager>
    {
        /// <summary>
        /// һ��ȫ�ֵ��������ⲿ����ʹ��
        /// </summary>
        public static QFrameworkContainer Container
        {
            get { return MarioAppManager.Instance.mContainer; }
        }
        /// <summary>
        /// һ��ȫ�ֵ��������ڲ�����ʹ��
        /// </summary>
        private QFrameworkContainer mContainer { get; set; }

        private MarioAppManager()
        {
            mContainer = new QFrameworkContainer();
            mContainer.RegisterInstance<IQFrameworkContainer>(mContainer);

            //ע��һЩ����
            //ע��UITools
            mContainer.RegisterInstance<IUITools>(new UITools());
        }

    }
}
