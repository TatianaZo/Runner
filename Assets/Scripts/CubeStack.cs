using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStack : MonoBehaviour
{
    private GameObject player;

    public void OnTriggerEnter(Collider other)
    {
         Debug.Log(other.name);
        if  (other.gameObject.name == "Player")
        {
            transform.parent = player.transform;
            player.GetComponent<PlayerController>().AddCubePlateList(gameObject);
                 
            Debug.Log("Tag Player");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
