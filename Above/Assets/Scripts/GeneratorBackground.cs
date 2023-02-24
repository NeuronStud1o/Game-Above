using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBackground : MonoBehaviour
{
    public GameObject background;
    public Transform generatorPoint;
    public float distanceBetween;

    float platformWidth;

    void Start()
    {
        platformWidth = background.GetComponent<BoxCollider2D>().size.y;
    }

    void Update()
    {
        if (transform.position.y < generatorPoint.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + platformWidth + distanceBetween, transform.position.z);

            Instantiate(background, transform.position, transform.rotation);
        }
    }
}
