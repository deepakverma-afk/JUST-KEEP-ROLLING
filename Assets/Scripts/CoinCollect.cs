using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Coin Collected!");
            Destroy(gameObject);
        }
    }
}