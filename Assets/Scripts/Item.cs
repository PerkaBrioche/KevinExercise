using System;
using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public virtual void PlayEffect()
    {
        PowerUpManager.Instance.AddPU(SpritePU, TimeToNormal);
        HideItem();
        StartCoroutine(BackToNormal());
    }
    
    public abstract bool ReturnEffect { get; protected set; }
    public abstract void CancelEffect();
    public abstract float TimeToNormal { get; protected set; }
    public abstract Sprite SpritePU { get; protected set; }

    public void HideItem()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }
    
    public IEnumerator BackToNormal()
    {
        if (!ReturnEffect)
        {
            Destroy(gameObject);
            yield break;
        }
        yield return new WaitForSeconds(TimeToNormal);
        CancelEffect();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayEffect();
        }
    }
}