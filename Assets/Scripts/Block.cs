using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockSparklesVFX;
    [SerializeField] private int maxHits;
    
    // cached reference
    private Level _level;
    private GameSession _gameSession;
    
    // State variables
    [SerializeField] private int timesHit;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        _level = FindObjectOfType<Level>();
        _gameSession = FindObjectOfType<GameSession>();
        if (CompareTag("Breakable"))
        {
            _level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable"))
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySfx();
        Destroy(gameObject);
        _level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySfx()
    {
        _gameSession.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        var sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
