using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace QFramework.MFO
{
    public class CharacterController : MonoBehaviour
    {
        private Animator moveAnim;

        //��ʱ����ʹ��
        private ETCJoystick myJoystick;
        private ETCButton JumpButton;
        private Button backBtn;

        // Start is called before the first frame update
        void Start()
        {
            moveAnim = GetComponent<Animator>();
            //Debug.LogError(moveAnim);
            myJoystick = GameObject.Find("EasyTouchControlsCanvas/TestJoystick")
                                   .GetComponent<ETCJoystick>();
            JumpButton = GameObject.Find("EasyTouchControlsCanvas/JumpButton")
                                    .GetComponent<ETCButton>();
            backBtn = GameObject.Find("EasyTouchControlsCanvas/backBtn")
                                    .GetComponent<Button>();
            
            //����������ֵ�ĸı�
            myJoystick.onMove.AddListener(PlayerMove);
            myJoystick.onMoveEnd.AddListener(PlayerStop);
            myJoystick.onMoveStart.AddListener(PlayerStart);
            JumpButton.onPressed.AddListener(PlayerJumpStart);
            JumpButton.onUp.AddListener(PlayerJumpStop);
            backBtn.onClick.AddListener(() =>
            {
                MyEventSystem.Send(MyEventType.ChangeScence,ScenceType.Main);
            });


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

                });
            gameObject.OnTriggerEnterAsObservable()
                .Subscribe(triggerCollider =>
                {
                    if (triggerCollider.gameObject.CompareTag("Obstacle"))
                    {
                        //Debug.LogError("����");
                        transform.position = Vector3.zero;
                    }
                    else if(triggerCollider.gameObject.CompareTag("GameEnd"))
                    {
                        //Debug.LogError("���سɹ�");
                        int level = CacheDataManage.Instance.GetIntData(DataType.playLevel);
                        if (level == CacheDataManage.Instance.GetIntData(DataType.levelMax))
                        {
                            CacheDataManage.Instance.SetIntData(DataType.levelMax,level+1);
                        }
                        MyEventSystem.Send(MyEventType.ChangeScence,ScenceType.Main);
                    }
                    else if (triggerCollider.gameObject.CompareTag("PickCoin"))
                    {
                        int coinnum = CacheDataManage.Instance.GetIntData(DataType.coinnum);
                        coinnum += 1;
                        CacheDataManage.Instance.SetIntData(DataType.coinnum,coinnum);
                    }
                });
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
        /// ��ɫ��ʼ�˶�
        /// </summary>
        private void PlayerJumpStart()
        {
            moveAnim.SetBool("Jump", true);
            transform.DOLocalMoveY(0.8f, 0.8f);
        }
        /// <summary>
        /// ��ɫֹͣ�ƶ�
        /// </summary>
        private void PlayerJumpStop()
        {
            moveAnim.SetBool("Jump", false);
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
