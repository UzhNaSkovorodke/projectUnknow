using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private Transform player;
    private Vector3 tempPos;

    [SerializeField] private float minX = -20f, maxX = 20f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x < minX)
        {
            tempPos.x = minX;
        }
        if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }

        transform.position = tempPos;
    }
}
