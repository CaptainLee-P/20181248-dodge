using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image hpbar;
    // Start is called before the first frame update
   
    public void SetHP(int hp)
    {
        hpbar.fillAmount = (float)hp / 100f;
    }
}
