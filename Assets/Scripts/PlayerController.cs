using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> cubePlateList = new List<GameObject>();
    private GameObject player;
    public GameObject playerModel;
    public float speed = 5;
    public float speedRotation = 3;
    public MoveState moveState;
    private Vector3 prevPosition = Vector3.zero;
    [SerializeField] Move move;

    public GameObject PopUpLosing;
    public GameObject PopUpWin;
    public GameObject buttonRest;
    public GameObject buttonNew;


    private void Start()
    {
        player = gameObject;
        playerModel = player.transform.GetChild(0).gameObject;
    }
    private void Update()
    {
        switch (moveState)
        {
            case MoveState.Up:
                UpMove();
                break;
            case MoveState.Down:
                DownMove();
                break;
            case MoveState.Left:
                LeftMove();
                break;
            case MoveState.Right:
                RightMove();
                break; 
        }
        
        if (diff(prevPosition, player.transform.position)<= 0.001f)
        {
            moveState = MoveState.Idle;
        }
        prevPosition = player.transform.position; 

        if (moveState != MoveState.Idle)
        {
            move.switcher = false;
        }
        else move.switcher = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public async void ShowPopUpLosing()
    {
        PopUpLosing.SetActive(true);
        await Task.Delay(1000);
        buttonNew.SetActive(true);
    }

    public async void ShowPopUpWin()
    {
        PopUpWin.SetActive(true);
        await Task.Delay(1000);
        buttonRest.SetActive(true);
    }

    public void AddCubePlateList(GameObject cube)
    {
        cubePlateList.Add(cube);
        Debug.Log(cubePlateList.Count);
        playerModel.transform.localPosition += new Vector3(0, 0.05f, 0);
        ChangeHeightCubes();
        FindObjectOfType<Score>().CubeCounter();
    }

    public void ChangeHeightCubes()
    {
        foreach (GameObject cube in cubePlateList)
        {
            cube.transform.localPosition = new Vector3(0, ((cubePlateList.IndexOf(cube) * 0.05f)-0.05f), 0);
        }
    }

    private float diff(Vector3 oldPoint, Vector3 newPoint)
    {
        return Vector3.Distance(oldPoint, newPoint);
    }

    public void UpMove()
    {
        playerModel.transform.eulerAngles = new Vector3 (0, 180, 0);
        player.transform.position += player.transform.forward * speed * Time.deltaTime;
    }

    public void DownMove()
    {
        playerModel.transform.eulerAngles = new Vector3(0, 0, 0);
        player.transform.position -= player.transform.forward * speed * Time.deltaTime;
    }

    public void LeftMove()
    {
        playerModel.transform.eulerAngles = new Vector3(0, 90, 0);
        player.transform.position -= player.transform.right * speed * Time.deltaTime;
    }

    public void RightMove()
    {
        playerModel.transform.eulerAngles = new Vector3(0, 270, 0);
        player.transform.position += player.transform.right * speed * Time.deltaTime;
    }
}

public enum MoveState
{
   Up,
   Down,
   Left,
   Right,
   Idle
}
