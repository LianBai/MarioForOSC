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
		    foreach (Transform childTf in ShellPool)
		    {
		        ShellQueue.Enqueue(childTf.gameObject);
		    }
            Observable.EveryUpdate()
                .Where(_ => Time.frameCount % 8 == 0)
                .Subscribe(_ => 
                {
                   FireShell();
                })
                .AddTo(this);

        }

        /// <summary>
        /// ∑¢…‰≈⁄µØ
        /// </summary>
	    void FireShell()
	    {
            
	        GameObject shell;
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

	    void AddShell(Transform muzlel)
	    {
	        GameObject shell;
            shell = ShellQueue.Dequeue();
	        shell.SetActive(true);
            shell.transform.position = muzlel.position;
            shell.transform.rotation = muzlel.transform.parent.rotation;
            shell.GetComponent<Rigidbody>().AddForce(muzlel.transform.parent.forward * 900f);
            shell.OnCollisionEnterAsObservable()
                .Subscribe(triggerCollider =>
                {
                    shell.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    shell.SetActive(false);
                    ShellQueue.Enqueue(shell);
                })
                .AddTo(this);

            //Observable.Timer(TimeSpan.FromSeconds(3))
            //    .Subscribe(_ =>
            //    {
            //        shell.SetActive(false);
            //        ShellQueue.Enqueue(shell);
            //    })
            //    .AddTo(this);
        }
	}
}
