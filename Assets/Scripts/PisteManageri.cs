using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisteManageri : MonoBehaviour
{
    
    public int piste = 0;
    public int huippuPisteet = 0;
    //public int pisteet = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("piste", piste);
    }

    // Update is called once per frame
    void Update()
    {
        print(piste);
    }

    public static PisteManageri instanssi;

    public void Awake()
    {
        if (instanssi == null)
        {
            instanssi = this;
        }
    }


    //void lisaaPiste()
    //{

    //    piste++;
    //    if (piste > huippuPisteet)
    //    {
    //        huippuPisteet = piste;
    //    }
    //}

    public void LisaaPisteita()
    {
        piste += 1;
    }

    public void LopetaPisteet()
    {
        //PlayerPrefs.SetInt("piste", piste);
        //print(piste);
        //if(PlayerPrefs.HasKey("korkeimmatPisteet"))
        //{
        //    if(piste > PlayerPrefs.GetInt("huippuPisteet"))
        //    {
        //        PlayerPrefs.SetInt("huippuPisteet", piste);
        //    }
        //}

        //else
        //{
        //    PlayerPrefs.SetInt("huippuPisteet", piste);
        //}

        PlayerPrefs.SetInt("piste", piste);
        print(piste);

        if (piste > PlayerPrefs.GetInt("huippuPisteet"))
        {
            PlayerPrefs.SetInt("huippuPisteet", piste);
        }


    }

}
