using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColetarRecarga : MonoBehaviour
{
    [SerializeField] private GameObject textoDoBotaoDeAcao;
    [SerializeField] private GameObject textoDaAcao;
    [SerializeField] private GameObject recargaFalsa;
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
            Pistola.cartucho = 12;
            textoDaAcao.GetComponent<Text>().text = "Pegar a Recarga";

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
                Pistola.cartucho = 12;
                recargaFalsa.SetActive(false);

            }
        }

    }
    private void OnMouseExit()
    {
        textoDaAcao.SetActive(false);
        textoDoBotaoDeAcao.SetActive(false);
        
    }
}
