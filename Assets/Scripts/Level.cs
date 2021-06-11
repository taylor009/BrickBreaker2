using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Level : MonoBehaviour
{

    [SerializeField] private int breakableBlocks;  // Serialized for debugging purposes

    // cached reference
    private SceneLoader _sceneloader;

    private void Start()
    {
        _sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            Debug.Log(_sceneloader);

            Assert.IsNotNull(_sceneloader);

            if (_sceneloader != null)
            {
                _sceneloader.LoadNextScene();
            }
        }
    }
}
