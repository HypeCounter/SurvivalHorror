using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZumbi : MonoBehaviour
{
    [SerializeField] GameObject portaZumbi;
    [SerializeField] GameObject zumbi;
    [SerializeField] AudioSource portaBatendo;
    [SerializeField] AudioSource musicaSusto;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger ativo");
        GetComponent<BoxCollider>().enabled = false;
        portaZumbi.GetComponent<Animation>().Play("porta2-anim01");
        zumbi.SetActive(true);
        portaBatendo.Play();
        musicaSusto.Play();
    }
}
