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
    private int s;//����һ����

    public Button reGame;

    public Text GetBoll;//�ѻ��Կ��

    private void Awake()
    {
        player = playGO.GetComponent<Player>();
        foreach (GameObject go in gameObjects)
            go.SetActive(false);

        reGame.onClick.AddListener(ReGame);
    }

    private void Update()
    {
        GetBoll.text = $"�ѻ��Կ��:{player.boolCount}";

        //��ʱ����ɵ���ʱ�Ĺ���
        times -= Time.deltaTime;
        s = (int)times % 60; //С��ת���� 
        TimeText.text = s.ToString();
        if (times <= 0)//ʱ�䵽��
        {
            //�ж�����ʱ����ʱ����ʲô
            if (player.boolCount >= 5)//��ȡ�����㹻����
                ShowUI("WinUI");
            else
                ShowUI("FailUI");
            Time.timeScale = 0;
        }
        else
        {
            Debug.Log(player.boolCount);
            //�ж�����ʱ����ʱ����ʲô
            if (player.boolCount >= 5)//��ȡ�����㹻����
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
    /// ���¿�ʼ��Ϸ
    /// </summary>
    private void ReGame()
    {
        times = 10;
        SceneManager.LoadScene("2");
        Time.timeScale = 1;
    }
}
