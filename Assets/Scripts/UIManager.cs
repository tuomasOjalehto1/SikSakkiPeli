using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UIManager : MonoBehaviour
{
    public GameObject tulosPaneeli;
    public GameObject pelinLoppuPaneeli;
    public TextMeshProUGUI pisteet;
    public TextMeshProUGUI huippuPisteet1;
    public TextMeshProUGUI huippuPisteet2;
    public TextMeshProUGUI aloitusTeksti;
    // Start is called before the first frame update
    void Start()
    {
        PelinAlku();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PelinAlku()
    {
        //aloitusTeksti.enabled = false;

        tulosPaneeli.SetActive(true);
        huippuPisteet1.text = PlayerPrefs.GetInt("huippuPisteet").ToString();

        // Access the animator component
        Animator animator = tulosPaneeli.GetComponent<Animator>();
        animator.SetFloat("Speed", 0.01f);
        animator.Play("PaneeliAnimaatio");


        //tulosPaneeli.GetComponent<Animator>().Play("PaneeliAnimaatio");
       
    }

    public void PelinLoppu()
    {

        pelinLoppuPaneeli.SetActive(true);
        pelinLoppuPaneeli.GetComponent<Animator>().Play("Loppunaytto");
        pisteet.text = PlayerPrefs.GetInt("piste").ToString();
        huippuPisteet2.text = PlayerPrefs.GetInt("huippuPisteet").ToString();
        huippuPisteet1.text = "Huippupisteet: " + PlayerPrefs.GetInt("huippuPisteet").ToString();
    }

    public void AloitaAlusta()
    {
        SceneManager.LoadScene(0);
    }

    public static UIManager instanssi;
    private void Awake()
    {
        if(instanssi == null)
        {
            instanssi = this;
        }
    }
}
