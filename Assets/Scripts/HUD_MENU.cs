using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD_MENU : MonoBehaviour
{
    [SerializeField ]private GameObject optionsWindow;
    void Start()
    {
        
        optionsWindow.GetComponentInChildren<Slider>().value = GameController.Instance.AudioManager.SfxVolume;
    }


    public void Play()
    {
        GameController.Instance.AudioManager.PlaySound("Bip");

        SceneManager.LoadScene(GameController.Instance.lvl_now, LoadSceneMode.Single);
        
    }

    public void RestartLevel()

    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,
LoadSceneMode.Single);
    }
    public void Exit()
    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        Application.Quit();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowWindow(GameObject window)
    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        window.GetComponent<Animator>().SetBool("Open", true);
        
    }

    public void HideWindow(GameObject window)
    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        window.GetComponent<Animator>().SetBool("Open", false);
    }

    public void SetSoundVolume(Slider slider)
    {
        GameController.Instance.AudioManager.SfxVolume = slider.value;

    }
    public void SetMusicVolume(Slider slider)
    {
        GameController.Instance.AudioManager.MusicVolume = slider.value;
    }

    private void Awake()
    {
        

    }

}
