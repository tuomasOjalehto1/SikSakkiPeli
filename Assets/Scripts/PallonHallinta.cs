using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PallonHallinta : MonoBehaviour
{
    //Oma koodi:

    public float nopeusTO;
    ////Muuttuja suunnalle mihin pelaaja liikkuu
    //public Vector3 suuntaTO;
    //public bool pelinLoppu;
    int clickLaskuriTO = 0;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    pelinLoppu = false;
    //    //Hakee alkuarvon suunnalle joka on siis eteen
    //    suuntaTO = Vector3.forward;
    //}

    //// Update is called once  per frame
    //void Update()
    //{


    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        clickLaskuriTO++;
    //        Vector3 mousePosition = Input.mousePosition;
    //        //K‰‰nt‰‰ vasemmallee
    //        if (mousePosition.x < Screen.width / 2) 
    //        {

    //            suuntaTO = Vector3.left;

    //            //Jos on klikattu jo niin seuraava klikkaus saa jatkamaan matkaa eteenp‰in.
    //            if (clickLaskuriTO > 1)
    //            {
    //                suuntaTO = Vector3.forward;
    //                //Nollataan klikkauslaskuri jotta homma toimmii ja voidaan k‰‰nnell‰ lis‰‰
    //                clickLaskuriTO = 0;
    //            }
    //        }
    //        //K‰‰nt‰‰ oikealle
    //        else if(mousePosition.x > Screen.width /2)
    //        {

    //            suuntaTO = Vector3.right;
    //            if (clickLaskuriTO > 1)
    //            {
    //                suuntaTO = Vector3.forward;
    //                clickLaskuriTO = 0;
    //            }
    //        }
    //    }

    //    // Katsoo nopeuden mill‰ liikutaan
    //    float liikeMaaraTO = nopeusTO * Time.deltaTime;
    //    //Liikuttaa varsinaisesti palloa
    //    transform.Translate(suuntaTO * liikeMaaraTO);


    //    // K‰ytt‰‰ raycast toimintoa jolla katsotaan osuuko pallo alustaan jos ei osu = pallo putoaa peli p‰‰ttyy
    //    RaycastHit osumaTO;
    //    float raycastEtaisyysTO = 1.0f; // Racaystin s‰teen pituus tai et‰isyys

    //    if (!Physics.Raycast(transform.position, Vector3.down, out osumaTO, raycastEtaisyysTO))
    //    {
    //        Debug.Log("No collision detected. Stopping the game...");
    //        Time.timeScale = 0;
    //        pelinLoppu = true;
    //        Camera.main.GetComponent<KameraSeuranta>().peliLoppu = true;
    //    }

    //}

    [SerializeField]
    private float nopeus;
    Rigidbody rb;
    bool alku;
    public bool pelinLoppu;
    Vector3 suuntaTO;
    public GameObject partikkeli;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        alku = false;
        pelinLoppu = false;
        
    }

    void Update()
    {
        if (!alku)
        {
            if (Input.anyKeyDown)
            {
                UIManager.instanssi.aloitusTeksti.enabled = false;
                GameManager1.instanssi.AloitaPeli();
                suuntaTO = Vector3.forward;
            }
            if (Input.GetMouseButtonDown(0))
            {
                clickLaskuriTO++;
                Vector3 mousePosition = Input.mousePosition;
                //K‰‰nt‰‰ vasemmallee
                if (mousePosition.x < Screen.width / 2)
                {
                    /*
                     * Heippa Ope!

                    Ohjelmassa siis pallo l‰htee liikkelle kun klikataan ensikerran ^ kuten ylh‰ll‰ n‰kkyy. Sen j‰lkeen palloa voi liikuttaa oikealle tai vasemmalle vasemmalle
                    Vasemmalle klikkaamalla oikea puolelta ja oikealle klikkaamalla vasemmmalta. Tein oman kontrollerin koska mielest‰ni t‰m‰ on parempi.
                    */
                    suuntaTO = Vector3.left;

                    //Jos on klikattu jo niin seuraava klikkaus saa jatkamaan matkaa eteenp‰in.
                    if (clickLaskuriTO > 1)
                    {
                        suuntaTO = Vector3.forward;
                        //Nollataan klikkauslaskuri jotta homma toimmii ja voidaan k‰‰nnell‰ lis‰‰
                        clickLaskuriTO = 0;
                    }
                }
                //K‰‰nt‰‰ oikealle
                else if (mousePosition.x > Screen.width / 2)
                {

                    suuntaTO = Vector3.right;
                    if (clickLaskuriTO > 1)
                    {
                        suuntaTO = Vector3.forward;
                        clickLaskuriTO = 0;
                    }
                }
            }

            // Katsoo nopeuden mill‰ liikutaan
            float liikeMaaraTO = nopeusTO * Time.deltaTime;
            //Liikuttaa varsinaisesti palloa
            transform.Translate(suuntaTO * liikeMaaraTO);
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            pelinLoppu = true;
            rb.velocity = new Vector3(0, -25f, 0);
            Camera.main.GetComponent<KameraSeuranta>().peliLoppu = true;
            GameManager1.instanssi.LopetaPeli();
        }
    }

    private void OnTriggerEnter(Collider jotainTO)
    {
        if (jotainTO.gameObject.CompareTag("Timantti"))
        {
            PisteManageri.instanssi.LisaaPisteita();
            GameObject osaTO = Instantiate(partikkeli, jotainTO.gameObject.transform.position, Quaternion.identity);
            if (jotainTO.gameObject.tag != null)
            {
                //Haastavuuden lis‰‰miseksi pallo kiihtyy kun saa pisteit‰.
                nopeusTO += 0.2f;
                //PisteManageri.instanssi.LisaaPisteita();
                Destroy(jotainTO.gameObject);
                Destroy(osaTO, 1f);
            }
        }

    }
    //if (Input.GetMouseButton(0) && !pelinLoppu)
    //{
    //    SuunnanVaihto();
    //}


    //void SuunnanVaihto()
    //    {
    //        if(rb.velocity.z > 0)
    //        {
    //            rb.velocity = new Vector3(nopeus, 0, 0);
    //        }
    //        else if(rb.velocity.x > 0)
    //        {
    //            rb.velocity = new Vector3(0, 0, nopeus);
    //        }
    //    }

    //}
}
