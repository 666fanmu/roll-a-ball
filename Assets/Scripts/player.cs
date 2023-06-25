using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour
{

    public float moveSpeed;
    public static int count=0;
    public static int Health=3;//����ֵ
    public Text HealthText;
    public Text countText;
    Vector3 moveAmount;
    Rigidbody rb; //��������
    public float jumpSpeed; // ������Ծ�߶�
   public static bool isGround = true;//�ж��Ƿ��ڵ���
    public float BuffTime;
    private GameObject MenuCanvas;
    public GameObject WinText;
    public GameObject gameManager;
    private Vector3 MoveDir;
    void Start()
    {
        setCountText();
        rb = GetComponent<Rigidbody>();
        SetHealthText();
    }
    // Update is called once per frame
    void Update()
    {
         MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }
    public void AddBuff(Buff buff)
    {
        buff.OnAdd();
    }
    void FixedUpdate()
    {
        rb.AddForce(MoveDir * moveSpeed);
        if (Input.GetKey(KeyCode.Space))// ʵ�ְ�����Ծ
        {
            if (isGround)
            {
                rb.AddForce(new Vector3(0f, jumpSpeed, 0f) * jumpSpeed);
                isGround = false;
            }
        }
        
    }
    
    



        void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pick")
        {
            other.gameObject.SetActive(false);
            count+=6;
            setCountText();
        }
        else if (other.gameObject.tag == "Pick Win")
        {
            other.gameObject.SetActive(false);
            count += 16;
            setCountText();
        }
        else if (other.gameObject.tag == "Pick Speed")//�ٶ�buff
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
            /* moveSpeed += 1;
             Invoke("SpeedClear", BuffTime);*/
            AddBuff(new SpeedBuff(this, Buff.BuffKind.SpeedBuff, 3f));


        }
        else if (other.gameObject.tag == "Pick Hight")//�߶�buff
        {
            other.gameObject.SetActive(false);
            count++;
            jumpSpeed += 2;
            setCountText();
            Invoke("HightClear", BuffTime);
        }
        else if (other.gameObject.tag == "Pick Blood")
        {
            other.gameObject.SetActive(false);
            count++;
            Health++;
            SetHealthText();
            setCountText();
        }
        else if (other.gameObject.tag == "Fake Pick")
        {
            other.gameObject.SetActive(false);
            count--;
            Health--;
            WinText.GetComponent<Text>().text = "���ϵ��ˣ�������";
            WinText.SetActive(true);
            Invoke("HideText", 2);
            SetHealthText();
            setCountText();
        }
    }
    void HideText()
    {
        WinText.SetActive(false);
    }
    void SpeedClear()
    {
        moveSpeed -= 1;
    }
    void HightClear()
    {
        jumpSpeed -= 2;
    }

    void setCountText()
    {
        countText.text = "����:" + count;
    }
    void SetHealthText()
    {
        HealthText.text = "����:" + Health;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // ��������������
        if (collision.gameObject.tag == "Ground")
        {
            // �����ڵ�����
            isGround = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Health -= 1;
            SetHealthText();
        }

    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
