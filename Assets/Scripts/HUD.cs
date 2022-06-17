using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;




public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject inventoryWindow;
    [SerializeField] private Text scoreLabel;

    [SerializeField] private GameObject LevelLoseWindow;
    [SerializeField] private GameObject LevelWonWindow;
    [SerializeField] private GameObject optionsWindow;
    [SerializeField] private GameObject bleder;
    [SerializeField] private Text procentWin;
    [SerializeField] private Text procentLose;
    private string test_p;

    static private HUD _instance;

    public static HUD Instance
    {
        get
        {
            return _instance;
        }
    }

    public GameObject Bleder { get => bleder; set => bleder = value; }
    public Text ProcentWin { get => procentWin; set => procentWin = value; }
    public Text ProcentLose { get => procentLose; set => procentLose = value; }
    public string Test_p { get => test_p; set => test_p = value; }

    public void SetScore(string scoreValue)
    {
        scoreLabel.text = scoreValue;
    }

    public void ProcResault(string scoreValue)
    {
        Test_p = scoreValue;
        procentWin.text = scoreValue + ("%");
        procentLose.text = scoreValue + ("%");
        
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

    public void BlenderOpen(GameObject blender)
    {
        blender.GetComponent<Animator>().SetBool("Open", true);
    }
    public void BlenderClose(GameObject blender)
    {
        blender.GetComponent<Animator>().SetBool("Open", false);
    }

    public void ButtonNext()
    {
        GameController.Instance.LoadNextLevel();
    }
    
    public void ButtonRestart()
    {
        GameController.Instance.RestartLevel();
    }
      public void ButtonMainMenu()
    {
        GameController.Instance.LoadMainMenu();
    }




    public void BlenderClosed()
    {
        BlenderClose(Bleder);
    }
   


    private void Awake()
    {
        _instance = this;
    }

    public void ShowLevelLoseWindow()
    {
        ShowWindow(LevelLoseWindow);
      

    }
    public void ShowLevelWonWindow()
    {

       
        ShowWindow(LevelWonWindow); 
        
        
    }


    void Start()
    {
        Debug.Log(GameController.Instance.AudioManager.MusicVolume);
        HUD.Instance.BlenderOpen(Bleder);
        optionsWindow.GetComponentInChildren <Slider>().value = GameController.Instance.AudioManager.SfxVolume; 


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSoundVolume(Slider slider)
    {
        GameController.Instance.AudioManager.SfxVolume = slider.value;
    }
    public void SetMusicVolume(Slider slider)
    {
        GameController.Instance.AudioManager.MusicVolume = slider.value;
    }


    public void End()
    {
        Debug.Log(Test_p);
        float f1 = float.Parse(Test_p);

        System.Random rnd = new System.Random();
        if (f1 >= 93f)
        {
            switch (f1) 
            {
                case (95) : f1 = rnd.Next(93, 94);                    
                    break;
                case ( 96): f1 = rnd.Next(93, 95);                    
                    break;
                case (97) : f1 = rnd.Next(94, 97);
                    break;

                case ( 98): f1 = rnd.Next(97, 99);                    
                    break;
                case (99) : f1 = rnd.Next(97, 99);
                    ;
                    break;
                case ( 100):  f1 = 100;                    
                    break;                    

            }
            
            HUD.Instance.ProcResault(Mathf.Round(f1).ToString());
            GameController.Instance.WON();
            GameController.Instance.lvl_now++;

            

        }
        else
        {

            if (f1>90)
            {
                f1 = 89;


            }
            

            HUD.Instance.ProcResault(Mathf.Round(f1).ToString());
            GameController.Instance.GameOver();
            

        }



    }

}
