using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{


    public float speed = 3.0f;
    public float obstacleRange = 5.0f;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //        Непрерывно движемся вперед в каждом
        //кадре, несмотря на повороты.
        transform.Translate(0, 0, speed * Time.deltaTime);
        //    Луч находится в том же положении и нацеливается в том же
        //направлении, что и персонаж.
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}

