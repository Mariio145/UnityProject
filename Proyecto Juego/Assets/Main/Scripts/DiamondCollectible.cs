using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        CharController controller = other.GetComponent<CharController>();

        if (controller != null)
        {
            controller.ChangeDiamond(1);
            Destroy(gameObject);
        }
    }
}
