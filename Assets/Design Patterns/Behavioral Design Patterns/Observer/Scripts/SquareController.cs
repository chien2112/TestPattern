using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    float horizontal, vertical;
    float speed = 3;
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(horizontal, vertical) * speed * Time.deltaTime);
    }
    
}
