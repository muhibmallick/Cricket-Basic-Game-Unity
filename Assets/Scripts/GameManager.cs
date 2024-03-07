using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject ballPrefab;
    public GameObject CurrentBall;
    public Vector3 ballSpawnPosition;

    public Text RunsText;
    public int TotalRuns = 0;
    // Start is called before the first frame update
    // To use the acript in other Scripts
    private void Awake()
    {

        instance = this;
        UpdateRuns(0);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Invoke("ThrowBall", 0f);
        }
    }



    public void ThrowBall() {
        Instantiate(ballPrefab,ballSpawnPosition,Quaternion.identity);
    }


    public void UpdateRuns(int Score)
    {
        TotalRuns = TotalRuns + Score;
        RunsText.text = "Runs - " + TotalRuns;
    }
}
