using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera_takip : MonoBehaviour
{
    public GameObject hedef;
    Vector3 uzaklik;

    void Start()
    {
        uzaklik = transform.position - hedef.transform.position; //aralarýndaki mesafenin korunmasý için.    
    }
    private void LateUpdate() //hareketlerin olmasýndan sonra çalýþmasýný istediðimiz ve optimizasyon için lateupdate kamera iþlemlerinde kullanýlýt.
    {
        if (Player.dustuMu)
        {
            return;
        }
        transform.position = hedef.transform.position + uzaklik;
    }
}
