using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int boolCount = 0;//球的数量
    public float m_speed = 5f;//玩家的移动速度

    /// <summary>
    /// 当进入碰撞体时
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag != "interaction") return;
        Destroy(collision.gameObject);
        boolCount++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "interaction") return;
        Debug.Log(other.gameObject.name);
        Destroy(other.gameObject);
        boolCount++;
    }


    //void Update()
    //{
    //    //键盘控制移动
    //    PlayerMove_KeyTransform2();
    //}


    ////通过Transform组件 键盘控制移动 另一种写法
    //public void PlayerMove_KeyTransform2()
    //{
    //    float horizontal = Input.GetAxis("Horizontal"); //A D 左右
    //    float vertical = Input.GetAxis("Vertical"); //W S 上 下

    //    transform.Translate(Vector3.forward * vertical * m_speed * Time.deltaTime);//W S 上 下
    //    transform.Translate(Vector3.right * horizontal * m_speed * Time.deltaTime);//A D 左右
    //}

}
