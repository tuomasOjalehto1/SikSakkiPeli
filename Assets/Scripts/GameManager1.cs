using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    
    bool lopetaPeli;

    // Start is called before the first frame update
    void Start()
    {
        lopetaPeli = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public GameManager1 instanssi;
    private void Awake()
    {
        if (instanssi == null)
        {
            instanssi = this;
        }
    }

    public void AloitaPeli()
    {
        UIManager.instanssi.PelinAlku();
        //GameObject.Find("Laajentaja").GetComponent<LaajentajaTO>().AloitaAlustojenKopionti();
        LaajentajaTO.instanssi.AloitaAlustojenKopionti();
    }

    public void LopetaPeli()
    {
        UIManager.instanssi.PelinLoppu();
        PisteManageri.instanssi.LopetaPisteet();
        lopetaPeli =true;
    }


}
