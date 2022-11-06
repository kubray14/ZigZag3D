using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zemin_Olusturma : MonoBehaviour
{
    public GameObject sonZemin;
   
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            zeminOlustur();
        }
    }

    void Update()
    {
        
    }
    public void zeminOlustur()
    {
        Vector3 yon;
        int randomSayi = Random.Range(0, 2); // 0 yada 1 gelir 2 gelmez.

        if (randomSayi == 0)
        {
            yon = Vector3.left;
        }
        else
        {
            yon = Vector3.back;
        }
        sonZemin = Instantiate(sonZemin, sonZemin.transform.position + yon, sonZemin.transform.rotation);
    }
}
