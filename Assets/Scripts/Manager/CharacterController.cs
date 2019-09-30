using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace QFramework.MFO
{
    public class CharacterController : MonoBehaviour
    {
        private Animator moveAnim;

        //��ʱ����ʹ��
        private ETCJoystick myJoystick;

        // Start is called before the first frame update
        void Start()
        {
            moveAnim = GetComponent<Animator>();
            //Debug.LogError(moveAnim);
            myJoystick = GameObject.Find("EasyTouchControlsCanvas/TestJoystick")
                                   .GetComponent<ETCJoystick>();

            //����������ֵ�ĸı�
            myJoystick.onMove.AddListener(PlayerMove);
            myJoystick.onMoveEnd.AddListener(PlayerStop);
            myJoystick.onMoveStart.AddListener(PlayerStart);

            gameObject.OnTriggerEnterAsObservable()
                .Where(triggerCollider => triggerCollider.gameObject.CompareTag("PickCoin"))
                .Subscribe(triggerCollider =>
                {
                    triggerCollider.gameObject.GetComponent<Animation>()["pickup_rotate"].speed = 3;
                    triggerCollider.transform
                        .DOLocalMoveY(triggerCollider.transform.localPosition.y + 1.5f, 0.3f)
                        .OnComplete(()=>
                        {
                            
                            PickUpCoinManage.Instance.RecyCoin(triggerCollider.transform);
                        });
                    //Debug.LogError(name.gameObject.name);

                });
            gameObject.OnTriggerEnterAsObservable()
                .Where(triggerCollider => triggerCollider.gameObject.CompareTag("Obstacle"))
                .Subscribe(triggerCollider =>
                {
                    Debug.LogError("����");
                    //Debug.LogError(name.gameObject.name);

                });
            //gameObject.AddComponent<ObservableUpdateTrigger>()
            //    .UpdateAsObservable()
            //    .SampleFrame(100)
            //    .Subscribe(name =>
            //    {
            //        Debug.LogError(name);
            //    });
        }
        // Update is called once per frame
        void Update()
        {

        }

        #region ��ɫ���ƺ���
        /// <summary>
        /// ��ɫ��ʼ�˶�
        /// </summary>
        private void PlayerStart()
        {
            moveAnim.SetBool("Run", true);
        }
        /// <summary>
        /// ��ɫֹͣ�ƶ�
        /// </summary>
        private void PlayerStop()
        {
            moveAnim.SetBool("Run", false);
        }
        /// <summary>
        /// ��ɫ�ƶ�
        /// </summary>
        /// <param name="arg0"></param>
        private void PlayerMove(Vector2 arg0)
        {
            //Debug.LogError(arg0);
            transform.LookAt(
                new Vector3(transform.position.x + arg0.y, 
                            transform.position.y, 
                            transform.position.z - arg0.x)
            );
        }
        #endregion

    }
}
