using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    [SerializeField] GameObject efeitoDisparo;
    [SerializeField] AudioSource somDisparo;
    [SerializeField] GameObject balistica;

    private bool estaAtirando = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(estaAtirando == false)
            {
                StartCoroutine(Atirar());
            }            
        }

        Debug.DrawRay(  balistica.transform.position,
                        transform.TransformDirection(Vector3.forward * 100), 
                        Color.red);
    }

    private IEnumerator Atirar()
    {
        RaycastHit trajetoria;
        estaAtirando = true;

        
        efeitoDisparo.SetActive(true);
        this.GetComponent<Animation>().Play("tiro-anim01");
        efeitoDisparo.GetComponent<Animation>().Play("disparo-anim01");
        somDisparo.Play();

        if (Physics.Raycast(balistica.transform.position,
                            transform.TransformDirection(Vector3.forward),
                            out trajetoria))
        {

            int dano = 10;

            trajetoria.transform.SendMessage("SofrerDano",
                                            dano,
                                            SendMessageOptions.DontRequireReceiver);
            Debug.Log(dano);
        }
        
        yield return new WaitForSeconds(.5f);
        estaAtirando = false;
        efeitoDisparo.SetActive(false);

    }
}
