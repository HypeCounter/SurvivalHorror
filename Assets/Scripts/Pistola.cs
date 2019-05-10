using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    [SerializeField] GameObject efeitoDisparo;
    [SerializeField] AudioSource somDisparo;
    [SerializeField] GameObject balistica;
    [SerializeField] GameObject textSemBala;

    public static int cartucho;

    private bool estaAtirando = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (cartucho >= 1) {
                textSemBala.SetActive(true);
                if (estaAtirando == false)
                {
                    StartCoroutine(Atirar());
                }

            }
            else
            {

                Debug.Log("SEM BALA");
                NoAmmo();

                /// informar jogador sem bala
            }
        }

        Debug.DrawRay(  balistica.transform.position,
                        transform.TransformDirection(Vector3.forward * 100), 
                        Color.red);
    }

    private void NoAmmo()
    {
        textSemBala.SetActive(true);
        StartCoroutine("WaitText");
        textSemBala.SetActive(false);
    }

    IEnumerator WaitText()
    {
        yield return new WaitForSeconds(2f);
        
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
        cartucho--;
        Debug.Log(cartucho);

    }
}
