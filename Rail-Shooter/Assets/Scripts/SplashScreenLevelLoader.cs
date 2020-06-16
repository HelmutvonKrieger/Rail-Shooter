using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenLevelLoader : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        handleSplashScreenInput();
    }

    private void handleSplashScreenInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Invoke("loadSceneAsync", 1f);
        }
    }

    private void loadSceneAsync()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
