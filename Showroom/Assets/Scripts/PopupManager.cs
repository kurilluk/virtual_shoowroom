using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{

    public GameObject popUpBubble;
    public GameObject player;
    public Collider my_collider;


    // Start is called before the first frame update
    void Start()
    {
        popUpBubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        popUpBubble.SetActive(true);
    //        StartCoroutine("HidePopUp");
    //    }
    //}

    //IEnumerator HidePopUp()
    //{
    //    yield return new WaitForSeconds(5);
    //    popUpBubble.SetActive(false);
    //}

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision:" + collision.gameObject);

        if (collision.gameObject == player)
        {
            popUpBubble.SetActive(true);
            //StartCoroutine("HidePopUp");
        }
    }
}
