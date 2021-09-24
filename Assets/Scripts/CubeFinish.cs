using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFinish : MonoBehaviour
{
    private GameObject player;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.name == "Player")
        {
            FindObjectOfType<PlayerController>().ShowPopUpWin();

            Debug.Log("Tag Player");
        }
    }
}
