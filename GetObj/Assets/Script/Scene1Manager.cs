using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene1Manager : MonoBehaviour
{
    public Button button;

    private void Awake()
    {
        button.onClick.AddListener(() => 
        {
            SceneManager.LoadScene("2");
        });
    }
}
