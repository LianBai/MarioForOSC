using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.MFO
{
    public enum MyEventType
    {
        Start = QMgrID.Game,
        //选择角色
        SelectNewPlayer,
        //返回大厅
        ChangeScence,
        End
    }
}
