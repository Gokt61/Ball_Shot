using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            //Top Atma Ýþlevini kilitleyeceðiz
            Debug.Log("KAZANDIN");
        }
        if (MevcutTopSayisi == 0 && GirenTopSayisi != HedefTopSayisi)
        {
            Debug.Log("Kaybettin");
        }

        if ((MevcutTopSayisi + GirenTopSayisi) < HedefTopSayisi)
        {
            Debug.Log("Kaybettin");
        }
    }

    public void TopGirmedi()
    {
        if (MevcutTopSayisi ==0)
        {
            Debug.Log("Kaybettin");
        }
        if ((MevcutTopSayisi + GirenTopSayisi) < HedefTopSayisi)
        {
            Debug.Log("Kaybettin");
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
}
