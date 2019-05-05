using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour {


    [SerializeField] private float distanciaParaAlvo;

    public float DistanciaParaAlvo
    {
        get
        {
            return distanciaParaAlvo;
        }
    }

    void Update () {
        RaycastHit raioAuxiliar;
        if(Physics.Raycast(this.transform.position, 
            this.transform.TransformDirection(Vector3.forward), out raioAuxiliar)){
            distanciaParaAlvo = raioAuxiliar.distance;
        }

        Debug.DrawRay(this.transform.position,
            this.transform.TransformDirection(Vector3.forward) * 100, Color.yellow);
	}
}
