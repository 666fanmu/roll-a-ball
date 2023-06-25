using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour
{

    public float moveSpeed;
    public static int count=0;
    public static int Health=3;//生命值
    public Text HealthText;
    public Text countText;
    Vector3 moveAmount;
    Rigidbody rb; //刚体属性
    public float jumpSpeed; // 控制跳跃高度
   public static bool isGround = true;//判断是否在地面
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
        if (Input.GetKey(KeyCode.Space))// 实现按键跳跃
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
        else if (other.gameObject.tag == "Pick Speed")//速度buff
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
            /* moveSpeed += 1;
             Invoke("SpeedClear", BuffTime);*/
            AddBuff(new SpeedBuff(this, Buff.BuffKind.SpeedBuff, 3f));


        }
        else if (other.gameObject.tag == "Pick Hight")//高度buff
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
            WinText.GetComponent<Text>().text = "你上当了！蠢货！";
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
        countText.text = "分数:" + count;
    }
    void SetHealthText()
    {
        HealthText.text = "生命:" + Health;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // 物体碰触到地面
        if (collision.gameObject.tag == "Ground")
        {
            // 物体在地面上
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
