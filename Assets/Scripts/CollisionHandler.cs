using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("Amount of time after crash before level reloads.")]
    [SerializeField] float levelLoadDelay = 1f;

    [Tooltip("Place particle explosions here.")]
    [SerializeField] ParticleSystem[] deathVFX;

    void OnTriggerEnter(Collider other) 
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        PlayExplosion();
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    void PlayExplosion()
    {
        foreach (ParticleSystem explosion in deathVFX)
        {
            explosion.Play();
        }
    }
}
