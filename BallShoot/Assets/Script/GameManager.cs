using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("--------TOP AYARLARI------")]
    public GameObject[] Toplar;
    public GameObject FirePoint;
    [SerializeField] private float TopGucu;
    int AktifTopIndex;

    [Header("--------LEVEL AYARLARI------")]
    [SerializeField] private int HedefTopSayisi;
    [SerializeField] private int MevcutTopSayisi;
    int GirenTopSayisi;
    public Slider LevelSlider;
    public TextMeshProUGUI KalanTopSayisi_Text;

    [Header("--------UI AYARLARI------")]
    public GameObject[] Paneller;
    public TextMeshProUGUI YildizSayisi;
    public TextMeshProUGUI Kazandin_LevelSayisi;
    public TextMeshProUGUI Kaybettin_LevelSayisi;


    void Start()
    {
        LevelSlider.maxValue = HedefTopSayisi;
        KalanTopSayisi_Text.text = MevcutTopSayisi.ToString();
    }

    public void TopGirdi()
    {
        GirenTopSayisi++;
        LevelSlider.value = GirenTopSayisi;


        if (GirenTopSayisi == HedefTopSayisi)
        {
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("Yildiz", PlayerPrefs.GetInt("Yildiz") + 15);
            YildizSayisi.text = PlayerPrefs.GetInt("Yildiz").ToString();
            Kazandin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
            Paneller[1].SetActive(true);
        }
        if (MevcutTopSayisi == 0 && GirenTopSayisi != HedefTopSayisi)
        {
            Kaybettin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
            Paneller[2].SetActive(true);
        }

        if ((MevcutTopSayisi + GirenTopSayisi) < HedefTopSayisi)
        {
            Kazandin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
            Paneller[2].SetActive(true);
        }
    }

    public void TopGirmedi()
    {
        if (MevcutTopSayisi ==0)
        {
            Kaybettin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
            Paneller[2].SetActive(true);
        }
        if ((MevcutTopSayisi + GirenTopSayisi) < HedefTopSayisi)
        {
            Kazandin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
            Paneller[2].SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            MevcutTopSayisi--;
            KalanTopSayisi_Text.text = MevcutTopSayisi.ToString();

            Toplar[AktifTopIndex].transform.SetPositionAndRotation(FirePoint.transform.position,FirePoint.transform.rotation);
            Toplar[AktifTopIndex].SetActive(true);

            Toplar[AktifTopIndex].GetComponent<Rigidbody>().AddForce(Toplar[AktifTopIndex].transform.TransformDirection(90, 90, 0) * TopGucu, ForceMode.Force);

            if (Toplar.Length-1 == AktifTopIndex)
            {
                AktifTopIndex = 0;
            }
            else
            {
                AktifTopIndex++;
            }
        }
    }

    public void OyunuDurdur()
    {
        Paneller[0].SetActive(true);
        Time.timeScale = 0;
    }

    public void PanellericinButonIslemi(string islem)
    {
        switch (islem)
        {
            case "Devamet":
                Time.timeScale = 1;
                Paneller[0].SetActive(false);
                break;
            case "Cikis":
                Application.Quit();
                break;
            case "Ayarlar":
                break;
            case "Tekrar":
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case "Birsonraki":
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
                break;  
        }
    }
}