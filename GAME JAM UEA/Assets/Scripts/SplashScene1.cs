using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class SplashScene1 : MonoBehaviour
{

    public Image blackfade;
    public Animator animFade;
    public string lvlName;

    void Start()
    {
        Invoke("ChangeSceneSplash", 2.5f);
    }

    void ChangeSceneSplash()
    {
        StartCoroutine(GoToNextLevel());
    }
   
    public void Fade(string scene)
    {
        lvlName = scene;
        StartCoroutine(GoToNextLevel());
    }
   
    IEnumerator GoToNextLevel()
    {
        animFade.SetBool("fade", true);
        yield return new WaitUntil(() => blackfade.color.a == 1);
        SceneManager.LoadScene(lvlName);
    }

    void fadeCaller()
    {
        StartCoroutine(GoToNextLevel());
    }


}
