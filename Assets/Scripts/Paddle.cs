using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // config params
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;
    [SerializeField] private float screenWidthInUnits = 16f;
    
    // cache reference
    private GameSession _gameSession;
    private Ball _ball;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
        _ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        var paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }


    private float GetXPos()
    {
        if (_gameSession.IsAutoPlayEnabled())
        {
            return _ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        };
    }
}
