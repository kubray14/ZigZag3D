using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera_takip : MonoBehaviour
{
    public GameObject hedef;
    Vector3 uzaklik;

    void Start()
    {
        uzaklik = transform.position - hedef.transform.position; //aralar�ndaki mesafenin korunmas� i�in.    
    }
    private void LateUpdate() //hareketlerin olmas�ndan sonra �al��mas�n� istedi�imiz ve optimizasyon i�in lateupdate kamera i�lemlerinde kullan�l�t.
    {
        if (Player.dustuMu)
        {
            return;
        }
        transform.position = hedef.transform.position + uzaklik;
    }
}
