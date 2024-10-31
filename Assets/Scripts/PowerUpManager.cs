using System;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField] private GameObject GO_PUImage;
    public void AddPU(Sprite sprite, float timeBeforeDestroy)
    {
        var PU = Instantiate(GO_PUImage, transform);
        PU.GetComponent<PowerUpController>().ApplyImage(sprite);
        Destroy(PU,timeBeforeDestroy);
    }
}
