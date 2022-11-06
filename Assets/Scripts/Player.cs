using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Vector3 yon;
    [SerializeField]
    float hiz;

    [SerializeField]
    GameObject startPanel;

    [SerializeField]
    GameObject RestartPanel;

    public Zemin_Olusturma zeminSinifi;
    public static bool dustuMu = true;
    float hizlanmaZorlugu = 0.01f;
    float skor=0f, artisMiktar� = 1f;
    int maxSkor;

    [SerializeField]
    Text skorText;

    [SerializeField]
    Text maxSkorText;

    [SerializeField]
    Text maxSkorText2;

    [SerializeField]
    Text maxSkorText3;

    [SerializeField]
    Text SkorText2;

    void Start()
    {
        yon = Vector3.left;
        maxSkor = PlayerPrefs.GetInt("MaxSkor");
        maxSkorText.text = "Highest score: " + maxSkor.ToString();
        maxSkorText2.text = "Highest score: " + maxSkor.ToString();
        maxSkorText3.text = "Highest score: " + maxSkor.ToString();
        
        if (GameManager.isRestart == true)
        {
            skorText.gameObject.SetActive(true);
            maxSkorText.gameObject.SetActive(true);
            startPanel.SetActive(false);
            dustuMu = false;
        
        }
    }
    public void startGame()
    {
        startPanel.SetActive(false);
        skorText.gameObject.SetActive(true);
        maxSkorText.gameObject.SetActive(true);
        dustuMu = false;
        
    }

    void Update()                                                       //y�n i�lemleri Update i�erisinde yap�lmal�d�r. Art�rma i�lemleri her framede olur
    {
        if (dustuMu)
        {
            return;
        }
       
        
        if (Input.GetMouseButtonDown(0))                                // Mobilde de ekrana dokunmak olarak �al���r.
        {
            if (yon.z == 0)
            {
                yon = Vector3.back;
            }
            else
            {
                yon = Vector3.left;
            }
        }
        if (transform.position.y <= 0f)
        {
            SkorText2.text = "Skor: " + ((int)skor).ToString();
            dustuMu = true;
            Destroy(gameObject, 1f);
            RestartPanel.SetActive(true);
            if (skor > maxSkor)
            {
                maxSkor = (int)skor;
                PlayerPrefs.SetInt("MaxSkor", maxSkor);
                PlayerPrefs.Save();
                
            }
        }
        
    }
    private void FixedUpdate()                                          // hareket i�lemlerini FixedUpdate i�erisinde yap�lmas� uygundur.Art�rma i�elemleri her saniye olur. 
    {
        if (dustuMu)
        {
            return;
        }
        
        Vector3 hareket = yon * hiz * Time.deltaTime;                   // Player i�in pozisyon olu�turduk.
        transform.position += hareket;                                  //Hareketi s�rekli playerin pozisyonuna ekler.
        hiz += hizlanmaZorlugu * Time.deltaTime;

        skor += artisMiktar� * hiz * Time.deltaTime;
        skorText.text = "Score: " + ((int)skor).ToString();
    }
    private void OnCollisionExit(Collision collision)                   // Player zemini terk etti�inde yeni zemin olu�mas� i�in zemini terk edince �al���r.
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
           StartCoroutine(yokEt(collision.gameObject));
            zeminSinifi.zeminOlustur();
        }        
    } 
    IEnumerator yokEt(GameObject obje)
    {
        yield return new WaitForSeconds(0.1f);
        obje.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(1f);
        Destroy(obje);
    }
     
  
}
