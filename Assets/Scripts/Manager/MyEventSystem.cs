using System;
using System.Collections;
using System.Collections.Generic;
using QF;
using UniRx;
using UnityEngine;

namespace QFramework.MFO
{
    /// <summary>
    /// �ӿ� ֻ����洢���ֵ���
    /// </summary>
    interface IRegisterations
    {

    }
    /// <summary>
    /// ���ע��
    /// </summary>
    class Registerations : IRegisterations
    {
        /// <summary>
        /// ί�б���Ϳ���һ�Զ�ע��
        /// </summary>
        public Subject<object[]> Subject = new Subject<object[]>();
    }
    public class MyEventSystem
    {
        /// <summary>
        /// �洢�Ѿ�ע����¼�
        /// </summary>
        private static Dictionary<MyEventType, IRegisterations> mTypeEventDict 
            = new Dictionary<MyEventType, IRegisterations>();

        /// <summary>
        /// ע���¼�
        /// </summary>
        public static Subject<object[]> GetEvent(MyEventType type)
        {

            IRegisterations registerations = null;

            if (mTypeEventDict.TryGetValue(type, out registerations))
            {
                var reg = registerations as Registerations;
                return reg.Subject;
            }
            else
            {
                var reg = new Registerations();
                mTypeEventDict.Add(type, reg);
                return reg.Subject;
            }
        }

        /// <summary>
        /// �����¼�
        /// </summary>
        public static void Send(MyEventType type, params object[] param)
        {

            IRegisterations registerations = null;

            if (mTypeEventDict.TryGetValue(type, out registerations))
            {
                var reg = registerations as Registerations;
                reg.Subject.OnNext(param);
            }
        }
        
    }
}
