using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LandmineController : MonoBehaviour
{
    [SerializeField] private List<GameObject> LIST_ParticuleExplosion;
    [SerializeField] private int INT_MineDamage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Explode();
            other.transform.root.GetComponent<PlayerLife>().GetDamage(INT_MineDamage);
        }
    }

    private void Explode()
    {
        var RandomExplosion = LIST_ParticuleExplosion[Random.Range(0, LIST_ParticuleExplosion.Count)];
        Instantiate(RandomExplosion, transform.position, RandomExplosion.transform.rotation);
        Destroy(gameObject);
    }
}
