using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;

    // cached reference
    private Level _level;
    private GameSession _gameSession;

    private void Start()
    {
        _level = FindObjectOfType<Level>();
        _gameSession = FindObjectOfType<GameSession>();
        _level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        _level.BlockDestroyed();
        _gameSession.AddToScore();
    }
}
