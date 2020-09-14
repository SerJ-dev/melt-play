using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dialog : MonoBehaviour
{
    public GameObject TextOne;
    public GameObject TextTwo;
    int timer = 0 ;
    int timewait = 80;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TextTwo.SetActive(true);     
        }     
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            TextOne.SetActive(true);
            TextTwo.SetActive(false);
    }
    private void Update()
    {
        if (TextOne == true)
        {
            timer++;
            if (timer >= timewait)
            {
               TextOne.SetActive(false);
                timer = 0;
            }
        }
    }
}
