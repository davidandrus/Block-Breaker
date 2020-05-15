using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip blockBreakSound;
    [SerializeField] Level level;
    [SerializeField] GameObject blockSparkles;


    private GameObject blockSparklesInstance;

    private void Start()
    {
       
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameSession>().AddToScore();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparkleVFX();
        PlayBlockDestroyedSound();
    }

    private void PlayBlockDestroyedSound()
    {
        AudioSource.PlayClipAtPoint(blockBreakSound, Camera.main.transform.position);

    }

    private void TriggerSparkleVFX()
    {
        blockSparklesInstance = Instantiate(blockSparkles, transform.position, transform.rotation);
        Destroy(blockSparklesInstance, 1f);
    }
} 
