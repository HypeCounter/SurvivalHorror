using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PrimeiroTrigger : MonoBehaviour
{
    [SerializeField] private GameObject jogador;
    [SerializeField] private GameObject indicador;
    [SerializeField] private GameObject caixaTexto;

    private void OnTriggerEnter(Collider other)
    {
        jogador.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ExibeMensagem());
    }

    private IEnumerator ExibeMensagem()
    {
        caixaTexto.GetComponent<Text>().text = "Parece que tem uma arma em cima da mesa";
        yield return new WaitForSeconds(2.5f);
        jogador.GetComponent<FirstPersonController>().enabled = true;
        caixaTexto.GetComponent<Text>().text = "";
        indicador.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
