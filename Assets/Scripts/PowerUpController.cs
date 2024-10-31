using UnityEngine;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{
    public void ApplyImage(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }
}
