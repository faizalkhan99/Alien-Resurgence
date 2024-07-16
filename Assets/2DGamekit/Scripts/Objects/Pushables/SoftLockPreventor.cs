using System.Collections;
using UnityEngine;

public class SoftLockPreventor : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("box"))
        {
            StartCoroutine(WaitbeforeReset(collision));
        }
    }

    private IEnumerator WaitbeforeReset(Collider2D col)
    {
        yield return new WaitForSeconds(1.0f);
        col.transform.position = _target.position;
        StopCoroutine(WaitbeforeReset(col));
    }
}
