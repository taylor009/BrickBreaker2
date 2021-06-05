using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;
    [SerializeField] private float screenWidthInUnits = 16f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        var paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = paddlePos;
    }
}
