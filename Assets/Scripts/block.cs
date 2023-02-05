using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    level lv;
    //GameStatus game;
    private void Start() 
    {
        lv = FindObjectOfType<level>();
        //game = FindObjectOfType<GameStatus>();
        lv.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        DestroyBlock();
    }

    public void DestroyBlock()
    {
        FindObjectOfType<GameSession>().updatePoint();
        AudioSource.PlayClipAtPoint(breakSound, new Vector3(8, 6, -10));
        Destroy(gameObject);
        lv.BlockDestroyed();
    }
}
