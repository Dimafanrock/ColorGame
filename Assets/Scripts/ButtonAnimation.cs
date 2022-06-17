using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    public  void Button_Animation()
    {
         transform.localScale -= new Vector3(0.1F, 0.1F, 0.1F);

    } public  void Button_Animation_2()
    {
         transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);

    }
}
