using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject item;
    public IEnumerator Respawnx (Collider2D collision, int time)
    {
        yield return new WaitForSeconds(time);
        item.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            item.gameObject.SetActive(false);
            StartCoroutine(Respawnx(collision, 4));
        }
    }

}
