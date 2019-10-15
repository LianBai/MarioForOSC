using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace QFramework.MFO
{
	public partial class CannonManage : ViewController
	{
        private Queue<GameObject> ShellQueue = new Queue<GameObject>();
		void Start()
		{
		    // Code Here
            //初始化加载炮弹池
		    foreach (Transform childTf in ShellPool)
		    {
		        ShellQueue.Enqueue(childTf.gameObject);
		    }
            //设置间隔发射炮弹
            Observable.EveryUpdate()
                .Where(_ => Time.frameCount % 8 == 0)
                .Subscribe(_ => 
                {
                   FireShell();
                })
                .AddTo(this);

        }

        /// <summary>
        /// 发射炮弹
        /// </summary>
	    void FireShell()
	    {
            
	        GameObject shell;
            //炮弹对象池不足时增加炮弹
            if (ShellQueue.Count < 10)
	        {
	            for (int i = 0; i < 10; i++)
	            {
	                shell = GameObject.Instantiate(ShellQueue.Peek());
	                shell.transform.parent = ShellQueue.Peek().transform.parent;
                    ShellQueue.Enqueue(shell);
                }
	        }
	        
	        AddShell(Muzle2);
        }
        /// <summary>
        /// 往炮弹口增加一个炮弹
        /// </summary>
        /// <param name="muzlel"></param>
	    void AddShell(Transform muzlel)
	    {
	        GameObject shell;
            shell = ShellQueue.Dequeue();
	        shell.SetActive(true);
            shell.transform.position = muzlel.position;
            shell.transform.rotation = muzlel.transform.parent.rotation;
            shell.GetComponent<Rigidbody>().AddForce(muzlel.transform.parent.forward * 900f);
            //碰撞到物体上时自动消失
            shell.OnCollisionEnterAsObservable()
                .Subscribe(triggerCollider =>
                {
                    shell.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    shell.SetActive(false);
                    ShellQueue.Enqueue(shell);
                })
                .AddTo(this);

        }
	}
}
