using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float UnityScreenWidthUnit = 16f;
    [SerializeField] float minX = 0f, maxX = 16f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float updateMouseX = Input.mousePosition.x / Screen.width * UnityScreenWidthUnit;
        updateMouseX = Mathf.Clamp(updateMouseX, minX, maxX);
        Vector2 paddlePosition = new Vector2(updateMouseX, transform.position.y);
        transform.position = paddlePosition;
        
    }
}
