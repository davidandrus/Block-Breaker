using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip blockBreakSound;
    [SerializeField] Level level;


    private void Start()
    {
       
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        FindObjectOfType<GameSession>().AddToScore();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(blockBreakSound, Camera.main.transform.position);
        level.BlockDestroyed();
    }
}
