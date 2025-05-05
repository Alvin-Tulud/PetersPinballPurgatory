using UnityEngine;

public class Rarity : MonoBehaviour
{
    public QuarterRarity rarity;

    public int getRarity()
    {
        Debug.Log((int)rarity);
        return (int)rarity;
    }
}
