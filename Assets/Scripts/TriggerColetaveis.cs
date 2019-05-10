using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class TriggerColetaveis : MonoBehaviour
{
    [SerializeField] private GameObject jogador;
    [SerializeField] private GameObject caixaTexto;

    private void OnTriggerEnter(Collider other)
    {
        jogador.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ExibeMensagem());
    }

    private IEnumerator ExibeMensagem()
    {
        caixaTexto.GetComponent<Text>().text = "Munição! Ótimo!";
        yield return new WaitForSeconds(2.5f);
        jogador.GetComponent<FirstPersonController>().enabled = true;
        caixaTexto.GetComponent<Text>().text = "";
        this.gameObject.SetActive(false);
    }
}
