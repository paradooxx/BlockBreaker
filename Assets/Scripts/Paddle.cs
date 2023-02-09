using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float UnityScreenWidthUnit = 16f;
    [SerializeField] float minX = 0f, maxX = 16f;
    GameSession mySession;
    Ball theBall;
    // Start is called before the first frame update
    void Start()
    {
        mySession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        //float updateMouseX = Input.mousePosition.x / Screen.width * UnityScreenWidthUnit;
        
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(getXPos(), minX, maxX);
        transform.position = paddlePosition;
        
    }
    private float getXPos()
    {
        if(mySession.isAutoPlayEnabled())
            return theBall.transform.position.x;
        else
            return Input.mousePosition.x / Screen.width * UnityScreenWidthUnit;
    }
}
