using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTaker : MonoBehaviour
{
    private PlayerController player;


    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.name == "Player")
        {
            //Debug.Log("No Tag Player");
            if (player.cubePlateList.Count > 0 )
            {
                player.cubePlateList[0].transform.parent = gameObject.transform;
                transform.GetChild(0).localPosition = Vector3.zero;
                transform.GetChild(0).GetComponent<Collider>().enabled = false;
                GetComponent<Collider>().enabled = false;
                player.cubePlateList.RemoveAt(0);
                player.ChangeHeightCubes();
                player.playerModel.transform.localPosition -= new Vector3(0, 0.05f, 0);
                FindObjectOfType<Score>().CubeCounterMinus();
                if (other.gameObject.name == "Finish")
                {
                    player.ShowPopUpWin();
                }
            }
            else
            {
                player.moveState = MoveState.Idle;
                player.speed = 0;
                player.ShowPopUpLosing();
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
}
