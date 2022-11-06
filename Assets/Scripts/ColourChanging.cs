using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanging : MonoBehaviour
{
    [SerializeField]
    Color[] renkler;
    Color ilkRenk, ikinciRenk;
    int ilk_Renk;

    [SerializeField]
    Material zemin_Materyali;

    void Start() 
    {
        ilk_Renk = Random.Range(0, renkler.Length);
        Camera.main.backgroundColor = renkler[ilk_Renk];
        zemin_Materyali.color = renkler[ilk_Renk];
        ikinciRenk = renkler[ikinciRenkSec()];

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.dustuMu)
        {
            return;
        }
        Color fark = zemin_Materyali.color - ikinciRenk;
        if ((Mathf.Abs(fark.r) + Mathf.Abs(fark.g) + Mathf.Abs(fark.b)) < 0.2f)
        {
            ikinciRenk = renkler[ikinciRenkSec()];
        }
        zemin_Materyali.color = Color.Lerp(zemin_Materyali.color, ikinciRenk, 0.0003f);
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, ikinciRenk, 0.0007f);
    }
    int ikinciRenkSec()
    {
        int ikincilRenk;
        ikincilRenk = Random.Range(0, renkler.Length);
        while (ikincilRenk == ilk_Renk)
        {
            ikincilRenk = Random.Range(0, renkler.Length);
        }

        return ikincilRenk;
    }
}
