using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip blockBreakSound;
    [SerializeField] Level level;
    [SerializeField] GameObject blockSparkles;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;


    // state
    [SerializeField] int timesHit;

    private void Start()
    {
       
        level = FindObjectOfType<Level>();
        if (gameObject.tag == "Breakable") level.CountBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayBlockHitSound();
        if (gameObject.tag == "Breakable") HandleHit();
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits) {
            DestroyBlock();
        } else
        {
            showNextHitSprites();
        }

    }

    private void showNextHitSprites()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameSession>().AddToScore();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparkleVFX();
    }

    private void PlayBlockHitSound()
    {
        AudioSource.PlayClipAtPoint(blockBreakSound, Camera.main.transform.position);
    }

    private void TriggerSparkleVFX()
    {
        GameObject blockSparklesInstance = Instantiate(blockSparkles, transform.position, transform.rotation);
        Destroy(blockSparklesInstance, 1f);
    }
} 
