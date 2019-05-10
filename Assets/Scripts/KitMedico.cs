using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitMedico : MonoBehaviour
{
    [SerializeField] private GameObject textoDoBotaoDeAcao;
    [SerializeField] private GameObject textoDaAcao;
    [SerializeField] private GameObject kitFalso;
    [SerializeField] private float distancia;
    [SerializeField] private float exibeTexto = 2;
    [SerializeField] private GameObject jogador;



    private void Update()
    {
        distancia = jogador.GetComponent<ControlaJogador>().DistanciaParaAlvo;
    }

    private void OnMouseOver()
    {
        if (distancia <= exibeTexto)
        {
            textoDaAcao.SetActive(true);
            textoDoBotaoDeAcao.SetActive(true);
            ///FAZ A RECARGA
            jogador.GetComponent<ControlaJogador>().resistencia = 100;
            textoDaAcao.GetComponent<Text>().text = "Curar-se";

        }
        else
        {
            textoDaAcao.SetActive(false);
            textoDoBotaoDeAcao.SetActive(false);

        }

        if (Input.GetButtonDown("Acao"))
        {
            if (distancia <= exibeTexto)
            {
                //Debug.Log("pegando arma");
                this.GetComponent<BoxCollider>().enabled = false;
                textoDoBotaoDeAcao.SetActive(false);
                textoDaAcao.SetActive(false);
                jogador.GetComponent<ControlaJogador>().resistencia = 100;
                kitFalso.SetActive(false);

            }
        }

    }
    private void OnMouseExit()
    {
        textoDaAcao.SetActive(false);
        textoDoBotaoDeAcao.SetActive(false);

    }
}
