using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnarZumbi : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject zumbi;

    void OnTriggerEnter(Collider other)
    {
        Zumbi.Instantiate(zumbi, spawnPoint.transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
    }

    
}
