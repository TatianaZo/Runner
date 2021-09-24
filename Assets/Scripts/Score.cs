using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]  Text textCubeCounter;
    [SerializeField] float score;
    private PlayerController player;

    public void CubeCounter()
    {
        score = FindObjectOfType<PlayerController>().cubePlateList.Count;
        textCubeCounter.text = score.ToString();
    }
    public void CubeCounterMinus()
    {
        score--;
        textCubeCounter.text = score.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
