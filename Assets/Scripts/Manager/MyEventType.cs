using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.MFO
{
    public enum MyEventType
    {
        Start = QMgrID.Game,
        //切换一个新的角色
        SelectNewPlayer,
        End
    }
}
