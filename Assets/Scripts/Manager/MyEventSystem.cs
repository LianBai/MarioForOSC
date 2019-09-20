using System;
using System.Collections;
using System.Collections.Generic;
using QF;
using UniRx;
using UnityEngine;

namespace QFramework.MFO
{
    /// <summary>
    /// 接口 只负责存储在字典中
    /// </summary>
    interface IRegisterations
    {

    }
    /// <summary>
    /// 多个注册
    /// </summary>
    class Registerations : IRegisterations
    {
        /// <summary>
        /// 委托本身就可以一对多注册
        /// </summary>
        public Subject<object[]> Subject = new Subject<object[]>();
    }
    public class MyEventSystem
    {
        /// <summary>
        /// 存储已经注册的事件
        /// </summary>
        private static Dictionary<MyEventType, IRegisterations> mTypeEventDict 
            = new Dictionary<MyEventType, IRegisterations>();

        /// <summary>
        /// 注册事件
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
        /// 发送事件
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
