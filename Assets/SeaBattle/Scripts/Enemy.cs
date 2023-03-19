using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    CharacterController characterController;

    [SerializeField] private Vector3 _direction;
    [SerializeField] private int _speed;

    [SerializeField] private float _lifeTime = 10f;
    [SerializeField] private float _currentLifeTime;

    public void InitializeEnemy(Vector3 direction, int speed)
    {
        _direction = direction;
        _speed = speed;
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        _currentLifeTime = _lifeTime;
    }

    private void FixedUpdate()
    {
        _currentLifeTime -= Time.deltaTime;
        if (_currentLifeTime <= 0)
        {

            Destroy(gameObject);
        }
        
        characterController.Move(_direction * _speed * Time.deltaTime);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
