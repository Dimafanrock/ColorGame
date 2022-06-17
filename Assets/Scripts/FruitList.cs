using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FruitList : MonoBehaviour
{

    [SerializeField] private GameObject fruitsContainer;
    [SerializeField] private GameObject mixBox;
    [SerializeField] public List<GameObject> all_fruts;
    [SerializeField] Transform spawnPoint;
    [SerializeField] private Material rttgg;
    
    private float container;
    private Color swichColor;
 
    public delegate void ResaultDelegat();
    ResaultDelegat check;
    


    public List<Color32> fruits;
    private int fruitListLage;
    private Color32 mixColor;

    private bool win;

    private Color32 StartColor;
    private float resoult;

    public float Resoult { get => resoult; set => resoult = value; }
    public bool Win { get => win; set => win = value; }

    static private FruitList _instance;

    public static FruitList Instance
    {
        get
        {
            return _instance;
        }
    }

    public float Container { get => container; set => container = value; }

    void Start()
    {
        GameController.Instance.Lvl();
        StartColor = GameController.Instance.StartMaterial.color;

    }


    public void OnfruitClickApple()    // Яблоко 
    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        GameObject frutadd = Instantiate(all_fruts[0], spawnPoint.position, spawnPoint.rotation);
        fruits.Add( new Color32 (0,255,1,255));


    }

    public void OnfruitClickABanana() // Банан 
    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        GameObject frutadd = Instantiate(all_fruts[1], spawnPoint.position, spawnPoint.rotation);
        fruits.Add(new Color32(255, 255, 1, 255));
    }

    public void OnfruitClickACheries() // Вишня 
    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        GameObject frutadd = Instantiate(all_fruts[2], spawnPoint.position, spawnPoint.rotation);
        fruits.Add(new Color32(255, 1, 1, 255));
    }
    public void OnfruitClickEggplant() // Баклажан 
    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        GameObject frutadd = Instantiate(all_fruts[3], spawnPoint.position, spawnPoint.rotation);
        fruits.Add(new Color32(139, 1, 255, 255));
    }

    public void OnfruitClickLemon() // Лимон
    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        GameObject frutadd = Instantiate(all_fruts[4], spawnPoint.position, spawnPoint.rotation);
        fruits.Add(new Color32(255, 255, 1, 255));
    }
    public void OnfruitClickOrange()   // Апельсин  
    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        GameObject frutadd = Instantiate(all_fruts[5], spawnPoint.position, spawnPoint.rotation);
        fruits.Add(new Color32(255,165, 1, 255));
    }

    public void OnfruitClickRed_apple()   // Яблоко красное  
    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        GameObject frutadd = Instantiate(all_fruts[6], spawnPoint.position, spawnPoint.rotation);
        fruits.Add(new Color32(255, 1,1, 255));
    }
    public void OnfruitClickTomato()  // Помидор 
    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        GameObject frutadd = Instantiate(all_fruts[7], spawnPoint.position, spawnPoint.rotation);
        fruits.Add(new Color32(255, 1, 1, 255));
    }


    public void ButtonMix()     // Кнопка смешивания 
    {
        GameController.Instance.AudioManager.PlaySound("Bip");
        Mixer();
        mixBox.GetComponent<Renderer>().material.color = mixColor;
        DifFruits();
        HUD.Instance.BlenderClosed();
        
       
    }

    private void Mixer()   // Смешивание цветов
    {
        
        fruitListLage = fruits.Count;
        mixColor = fruits[0];
        Color color = mixColor;

        for (int i = 1; i < fruitListLage;)
        {
            mixColor = fruits[i];
            Color color2 = mixColor;
            color = color + color2;

            i++;
        }

        swichColor = new Color(color.r / (fruitListLage + 1), color.g / (fruitListLage + 1), color.b / (fruitListLage + 1));


        mixColor = swichColor;
        Debug.Log(mixColor);
      
    }


    private void DifFruits()

    {

        int  start_r = int.Parse( StartColor.r.ToString());
        int  start_g = int.Parse(StartColor.g.ToString());
        int  start_b = int.Parse(StartColor.b.ToString());
        int  mix_r = int.Parse(mixColor.r.ToString());
        int  mix_g = int.Parse(mixColor.g.ToString());
        int  mix_b = int.Parse(mixColor.b.ToString());

       

        int dif_r = Mathf.Abs(start_r- mix_r);
        int dif_g = Mathf.Abs(start_g- mix_g);
        int dif_b = Mathf.Abs(start_b- mix_b);
        

        int sum  = (dif_r) + (dif_g) + (dif_b); 
        float vOut = (float)(sum);    
        Resoult = 100 - ( (vOut / 765) * 100);

        Resoult = Mathf.Round(Resoult);
        HUD.Instance.Test_p = Resoult.ToString();

    }

    

 

    void Update()
    {
        
    }
}
