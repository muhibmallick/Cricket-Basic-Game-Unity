using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatsmanController : MonoBehaviour
{
    // Start is called before the first frame update
 Animator playerAnimator;
[SerializeField] BoxCollider Batcollider;



    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            StartCoroutine(BatsmanShot());
        }
    }

    IEnumerator BatsmanShot()
    {
        playerAnimator.SetBool("Shot", true);
        Batcollider.enabled = true;

        yield return new WaitForSeconds(.5f);
        playerAnimator.SetBool("Shot", false);

        Batcollider.enabled = false;


    }



}
