using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackround : MonoBehaviour
{
    public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < (startPosition.x- 75))
        {
            transform.position = startPosition;
        }
    }
}
