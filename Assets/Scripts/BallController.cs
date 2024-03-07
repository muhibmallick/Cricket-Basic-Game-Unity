using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    public float ballspeed = 6f;
    private int BallTouchCount = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
        rb.AddForce(Vector3.right * ballspeed, ForceMode.Impulse);
        Invoke("DestroyBall",20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroyBall() {
        Destroy(this.gameObject);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bat"))
        {


            float ballForce = Random.Range(5f, 15f);
            float Ballheight = Random.Range(3f, 6f);
            float BallPosition = Random.Range(-5f, 5f);

            Vector3 ballDirection = new Vector3(-ballForce, Ballheight, BallPosition);

           // Debug.Log("Ball Force +  Ballheight + BallPosition Applied is :" + ballDirection);
            rb.AddForce( ballDirection, ForceMode.Impulse);

        }

        if (other.gameObject.CompareTag("Boundry"))
        {
            if (BallTouchCount <= 1)
            {
                Debug.Log("Hit 6");
                GameManager.instance.UpdateRuns(6);
            }
            else {
                Debug.Log("Hit 4");
                GameManager.instance.UpdateRuns(4);
            }


        }
        if (other.gameObject.CompareTag("Out"))
        {
            
            GameManager.instance.TotalRuns = 0;
            GameManager.instance.UpdateRuns(0);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
           // Debug.Log("Bal Ground Touched" + BallTouchCount);
            BallTouchCount++;
        }
    }
}
