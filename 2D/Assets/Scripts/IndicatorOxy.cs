using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorOxy : MonoBehaviour
{
    public Image O2;
    public float O2Amount = 100;
    public float secondToEmptyOxy;
    public GameObject other;

    void Start()
    {
        O2.fillAmount= O2Amount / 100;
    }

    void Update()
    {
       if (O2Amount > 0)
       {
        O2Amount -= 100/secondToEmptyOxy * Time.deltaTime;  
        O2.fillAmount= O2Amount / 100;
       } 

       if (O2Amount < 0 )
       { 
       Destroy(other);
       }
    }
}
