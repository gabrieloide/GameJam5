using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Fade;
    public static MenuManager instance;
    //Dictionary<int, Sprite>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void ChangeUIFamily()
    {

    }
    public void AnimationOut()
    {
        LeanTween.moveX(Fade, 170, 0.4f).setOnComplete(Play);
        //StartCoroutine(Play());
    }
    public void AnimationIn()
    {

        LeanTween.moveX(Fade, -5500, 1f);
            
    }
    void Play()
    {
        SceneManager.LoadScene("MainWorld");
    }
    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();   
    }
}
