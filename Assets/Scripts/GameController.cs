using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState { Play, Pause }

public class GameController : MonoBehaviour
{
    static private GameController _instance;
    private int score;
    [SerializeField] private Audio audioManager;
    private float resoultProc;
    [SerializeField] private GameObject Blender;
    public byte lvl_now = 1 ;
    [SerializeField] private Material startMaterial;
    public float MusickGet ;




    public float ResoultProc
    {

        get
        {
            return resoultProc;

        }

        set
        {
            if (value != resoultProc)
            {
                resoultProc = value;
                HUD.Instance.ProcResault(resoultProc.ToString());
            }
        }

    }
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gameController =
                Instantiate(Resources.Load("Prefabs/GameController")) as GameObject;
                _instance = gameController.GetComponent<GameController>();
            }

            return _instance;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            if (value != score)
            {
                score = value;
                HUD.Instance.SetScore(score.ToString());
            }
        }
    }

    public Audio AudioManager { get => audioManager; set => audioManager = value; }
    public Material StartMaterial { get => startMaterial; set => startMaterial = value; }
    

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
         
        DontDestroyOnLoad(gameObject);
        InitializeAudioManager();     

    }

  
    public void LoadNextLevel()
    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1,
LoadSceneMode.Single);
        Debug.Log("Push");
        


    }
    public void RestartLevel()
    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,
LoadSceneMode.Single);
    }
    public void LoadMainMenu()
    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }



    public void WON()
    {
        
        Score += 25;                
        HUD.Instance.ShowLevelWonWindow();
        
    }

    public void GameOver()
    {
        HUD.Instance.ShowLevelLoseWindow();       
        

    }

    public void Lvl()
    {
        switch (lvl_now)
        {
            case 1 : StartMaterial.color = new Color32(51, 204, 1, 255);
                break;
            case 2 : StartMaterial.color = new Color32(204, 99, 1, 255);
                break;
            case 3 : StartMaterial.color = new Color32(169, 1, 110, 255);
                break;
            case 4:
                lvl_now = 1;
                break;

        }
        Debug.Log(lvl_now);
    }



    void Start()
    {
        AudioManager.PlaySound("1 - Joyful Journey");
        Lvl();


    }

   
    void Update()
    {
    }


    private void InitializeAudioManager()
    {
        AudioManager.SourceSFX = gameObject.AddComponent<AudioSource>();
        AudioManager.SourceMusic = gameObject.AddComponent<AudioSource>();
        AudioManager.SourceRandomPitchSFX = gameObject.AddComponent<AudioSource>();
        gameObject.AddComponent<AudioListener>();
    }

}
