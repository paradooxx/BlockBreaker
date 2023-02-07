using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkVFX;
    [SerializeField] Sprite[] hitSprites;
    level lv;                                          //cached reference

    [SerializeField] int timesHit, maxHits = 3;                      //serializing timesHit for debugging only 

    //GameStatus game;
    private void Start() 
    {
        CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(tag == "Breakable")
            HandleHit();
    }

    private void HandleHit()
    {
        timesHit++;
        if(timesHit == maxHits)
            DestroyBlock();
        else
            ShowNextHitSprite();
    }

    private void ShowNextHitSprite()
    {
        GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
    }

    public void DestroyBlock()
    {
        BreakSound();
        Destroy(gameObject);
        lv.BlockDestroyed();
        triggerParticleVFX();
    }

    public void BreakSound()
    {
        FindObjectOfType<GameSession>().updatePoint();
        AudioSource.PlayClipAtPoint(breakSound, new Vector3(8, 6, -10));
    }

    private void CountBreakableBlocks()
    {
        lv = FindObjectOfType<level>();
        if(tag == "Breakable")
        {
            lv.CountBlocks();
        }
    }

    private void triggerParticleVFX()
    {
        GameObject sparkle = Instantiate(blockSparkVFX, transform.position, transform.rotation);
    }
}
