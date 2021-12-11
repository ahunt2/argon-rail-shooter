using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] ParticleSystem[] hitVFX;
    GameObject vfxParent;

    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 5;
    [SerializeField] int hitPoints = 4;

    ParticleCollisionEvent[] collEvents;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        vfxParent = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hitPoints <= 0)
            KillEnemy();
    }

    void ProcessHit()
    {
        HitVFX();
        hitPoints--;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void HitVFX()
    {
        foreach(ParticleSystem hit in hitVFX)
        {
            hit.Play();
        }
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = vfxParent.transform;
        Destroy(gameObject);
    }
}
