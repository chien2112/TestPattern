using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontal, vertical;
    float speed = 3;
    public bool isMove = false;
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(horizontal, vertical) * speed * Time.deltaTime);

        isMove = (horizontal == 0 && vertical == 0)? false : true;
    }
    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
