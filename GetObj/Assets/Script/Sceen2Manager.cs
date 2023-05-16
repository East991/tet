using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sceen2Manager : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();

    public GameObject playGO;
    public Player player;

    public Text TimeText;
    public float times = 10;
    private int s;//定义一个秒

    public Button reGame;

    public Text GetBoll;//已获得钥匙

    private void Awake()
    {
        player = playGO.GetComponent<Player>();
        foreach (GameObject go in gameObjects)
            go.SetActive(false);

        reGame.onClick.AddListener(ReGame);
    }

    private void Update()
    {
        GetBoll.text = $"已获得钥匙:{player.boolCount}";

        //计时器完成倒计时的功能
        times -= Time.deltaTime;
        s = (int)times % 60; //小数转整数 
        TimeText.text = s.ToString();
        if (times <= 0)//时间到了
        {
            //判定倒计时结束时该做什么
            if (player.boolCount >= 5)//获取到了足够数量
                ShowUI("WinUI");
            else
                ShowUI("FailUI");
            Time.timeScale = 0;
        }
        else
        {
            Debug.Log(player.boolCount);
            //判定倒计时结束时该做什么
            if (player.boolCount >= 5)//获取到了足够数量
            {
                ShowUI("WinUI");
                Time.timeScale = 0;
            }
        }

    }

    private void ShowUI(string uiName)
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (gameObjects[i].name == uiName)
                gameObjects[i].SetActive(true);
        }
    }

    /// <summary>
    /// 重新开始游戏
    /// </summary>
    private void ReGame()
    {
        times = 10;
        SceneManager.LoadScene("2");
        Time.timeScale = 1;
    }
}
