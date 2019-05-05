using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaPorta : MonoBehaviour {
    [SerializeField] private float distancia;
    [SerializeField] private float exibeTexto = 2;
    [SerializeField] private GameObject textoBotaoDeAcao;
    [SerializeField] private GameObject textoDaAcao;
    [SerializeField] private GameObject porta;
    [SerializeField] private GameObject jogador;
    [SerializeField] private AudioSource somDaPorta;
    [SerializeField] private GameObject miraSecundaria;
    

    void Update () {
        distancia = jogador.GetComponent<ControlaJogador>().DistanciaParaAlvo;
	}

    private void OnMouseOver()
    {
        if(distancia <= exibeTexto)
        {
            textoBotaoDeAcao.SetActive(true);
            textoDaAcao.SetActive(true);
            miraSecundaria.SetActive(true);
            textoDaAcao.GetComponent<Text>().text = "Abrir porta";
        }
        else
        {
            textoBotaoDeAcao.SetActive(false);
            textoDaAcao.SetActive(false);
            miraSecundaria.SetActive(false);
        }

        if (Input.GetButtonDown("Acao"))
        {
            if(distancia <= exibeTexto)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                textoBotaoDeAcao.SetActive(false);
                textoDaAcao.SetActive(false);
                miraSecundaria.SetActive(false);
                porta.GetComponent<Animation>().Play("porta-anim01");
                somDaPorta.Play();
            }
        }
    }

    private void OnMouseExit()
    {
        textoBotaoDeAcao.SetActive(false);
        textoDaAcao.SetActive(false);
        miraSecundaria.SetActive(false);
    }
}
