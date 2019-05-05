using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColetarPistola : MonoBehaviour
{
    [SerializeField] private GameObject textoDoBotaoDeAcao;
    [SerializeField] private GameObject textoDaAcao;
    [SerializeField] private GameObject pistolaFalsa;
    [SerializeField] private GameObject pistolaReal;
    [SerializeField] private GameObject jogador;
    [SerializeField] private GameObject indicador;
    [SerializeField] private GameObject miraExtra;
    [SerializeField] private float distancia;
    [SerializeField] private float exibeTexto = 2;
    [SerializeField] private GameObject triggerZumbi;

    private void Update()
    {
        distancia = jogador.GetComponent<ControlaJogador>().DistanciaParaAlvo;
    }

    private void OnMouseOver()
    {
        if(distancia <= exibeTexto)
        {
            textoDaAcao.SetActive(true);
            textoDoBotaoDeAcao.SetActive(true);
            miraExtra.SetActive(true);
            textoDaAcao.GetComponent<Text>().text = "Pegar pistola";
        }
        else
        {
            textoDaAcao.SetActive(false);
            textoDoBotaoDeAcao.SetActive(false);
            miraExtra.SetActive(false);
        }

        if (Input.GetButtonDown("Acao"))
        {            
            if(distancia <= exibeTexto)
            {
                //Debug.Log("pegando arma");
                this.GetComponent<BoxCollider>().enabled = false;
                textoDoBotaoDeAcao.SetActive(false);
                textoDaAcao.SetActive(false);
                pistolaFalsa.SetActive(false);
                pistolaReal.SetActive(true);
                miraExtra.SetActive(false);
                indicador.SetActive(false);
                triggerZumbi.SetActive(true);
            }
        }
    }

    private void OnMouseExit()
    {
        textoDaAcao.SetActive(false);
        textoDoBotaoDeAcao.SetActive(false);
        miraExtra.SetActive(false);
    }
}
