using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderJuttu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider kolTO)
    {
        if (kolTO.gameObject.tag == "Pallo") 
        {
            //K‰ytet‰‰n Invoke funktiota jotta saadaan myˆs viive
            Invoke("Putoaminen", 0.5f);
        }
    }

    //private void OnTriggerEnter(Collider jotainTO)
    //{
    //    if(jotainTO.gameObject.tag == "Pallo")
    //    {
    //        Destroy(transform.parent.gameObject, 2f);
    //    }
    //}

    void Putoaminen()
    {
        //Kytket‰‰n painovoima p‰‰lle
        GetComponentInParent<Rigidbody>().useGravity = true;
        //Ehk‰ v‰‰rin
        GetComponentInParent<Rigidbody>().isKinematic = false;
        //Tuhotaan viiveell‰
        Destroy(transform.parent.gameObject, 2f);
    }

}
