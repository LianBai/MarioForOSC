using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarioForOSC
{
    public class BasePoolManage:MonoBehaviour
    {
        public Stack<Transform> poolstack;
        public void InitPool()
        {
            poolstack = new Stack<Transform>();
            foreach(var child in GetComponentsInChildren<Transform>())
            {
                poolstack.Push(child);
                child.gameObject.SetActive(false);
            }
        }
        
    }
}

