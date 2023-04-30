using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float speed;
    float Range;
    // Start is called before the first frame update
    void Start()
    {
        speed = 6.0f;
        Range = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float yOffset = move * Time.deltaTime * speed;
        float rawYPos = transform.localPosition.y + yOffset;
        float moveY = Mathf.Clamp(rawYPos, -Range, Range);
        transform.position = new Vector3(transform.localPosition.x, moveY, 0);


    }
}
