using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;

public class LaajentajaTO : MonoBehaviour
{
    public GameObject palikkaTO;
    public GameObject timantti;
    Vector3 viimeinenSijaintiTO;
    float kokoTO;
    public bool peliLoppu = false;

    public void AloitaAlustojenKopionti()
    {
        InvokeRepeating("AlustaSiirtymat", 2f, 0.2f);
    }


    // Start is called before the first frame update
    public void Start()
    {
       
            viimeinenSijaintiTO = palikkaTO.transform.position;
            kokoTO = palikkaTO.transform.localScale.x;
            
        
    }

    static public LaajentajaTO instanssi;
    public void Awake()
    {
        if(instanssi == null)
        {
            instanssi = this;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        //InvokeRepeating("AlustaSiirtymat", 2f, 0.2f);
        if (peliLoppu)
        {
            CancelInvoke("AlustaSiirtymat");
        }
    }

    public void SiirtymaX()
    {
        Vector3 sijTO = viimeinenSijaintiTO;
        sijTO.x += kokoTO;
        viimeinenSijaintiTO = sijTO;

        Instantiate(palikkaTO,sijTO,Quaternion.identity) ;

        //Luo timantteja
        int satTO = Random.Range(0, 4);

        if (satTO < 1)
        {

            Instantiate(timantti, new Vector3(sijTO.x, sijTO.y + 1.4f, sijTO.z), timantti.transform.rotation);
        }

    }

    public void SiirtymaZ()
    {
        Vector3 sijTO = viimeinenSijaintiTO;
        sijTO.z += kokoTO;
        viimeinenSijaintiTO = sijTO;

        Instantiate(palikkaTO, sijTO, Quaternion.identity);

        //Luo timantteja
        int satTO = Random.Range(0, 4);

        if (satTO < 1)
        {
            Instantiate(timantti, new Vector3(sijTO.x, sijTO.y + 1.4f, sijTO.z), timantti.transform.rotation);
        }
    }


    public void AlustaSiirtymat()
    {   //Ehkä väärin
        if (peliLoppu)
        {
            return;
        }
        int satuTO = Random.Range(0, 6);
        if (satuTO < 3)
        {
            SiirtymaX();
        }
        else if (satuTO >= 3)
        {
            SiirtymaZ();

        }


        

    }


}
