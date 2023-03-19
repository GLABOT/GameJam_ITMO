using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    [SerializeField] private float _speed;

    public void InitializeBullet(Vector3 direction)
    {
        _direction = direction;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _direction, _speed * Time.deltaTime);
        transform.LookAt(_direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<DeadZone>() != null)
        {
            Destroy(gameObject);
            // TODO particles;
        }

        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            collision.gameObject.GetComponent<Enemy>().Die();
            Destroy(gameObject);
        }
    }
}
