using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
      float h = Input.GetAxisRaw("Horizontal");
      float v = Input.GetAxisRaw("Vertical");

        Vector2 pos = transform.position;

        pos.x += h * speed * Time.deltaTime;
        pos.y+= v * speed * Time.deltaTime;
    
        transform.position = pos;
    }
}
