using QF.Extensions;
using UnityEngine;
using QFramework;
using UniRx;

namespace QFramework.MFO
{
	public partial class CharacterManage : ViewController
	{
	    private Vector3 offPos;
	    private Transform playerTf;
		void Start()
		{
			// Code Here
            //生成玩家角色
		    ResLoadManage.Instance.mResLoader.LoadSync<GameObject>(CacheDataManage.Instance.GetStringData(DataType.playerName))
		        .Instantiate()
		        .ApplySelfTo(self =>
		        {
		            self.transform.parent = transform;
		            self.transform.LocalIdentity();
		            self.AddComponent<CharacterController>();

                    //初始化计算相机和人物的位置，用来相机跟随用
		            playerTf = self.transform;
                    offPos = this.seeCamera.transform.position - self.transform.position;

		        })
                .Show();
		}

	    void LateUpdate()
	    {
	        this.seeCamera.transform.position = playerTf.position + offPos;
	    }
	}
}
