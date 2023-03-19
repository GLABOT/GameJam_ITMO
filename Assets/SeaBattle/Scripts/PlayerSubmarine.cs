using UnityEngine;

public class PlayerSubmarine : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private GameObject _debugAimTarget;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPosition;

    [SerializeField] private bool _canShoot = true;
    [SerializeField] private float _reloadTime = 1.5f;
    [SerializeField] private float _reloadTimeDelta;

    private int health;
    public int Health 
    { 
        get 
        { 
            return health;
        } 
        set
        {
            health = value;
            if (health <= 0)
            {
                
            }
        }
    }

    private void Awake()
    {
        _camera = Camera.main;
        _reloadTimeDelta = _reloadTime;
    }

    private void Update()
    {
        Aim();
        Shoot();

        if (_reloadTimeDelta <= 0)
        {
            _canShoot = true;
        }
        else
        {
            _reloadTimeDelta -= Time.deltaTime;
        }
    }

    private void Aim()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999.0f))
        {
            _debugAimTarget.transform.position = raycastHit.point;
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _canShoot)
        {
            Instantiate(_bulletPrefab, _bulletSpawnPosition.position, Quaternion.identity).GetComponent<Bullet>().InitializeBullet(_debugAimTarget.transform.position);
            _canShoot = false;
            _reloadTimeDelta = _reloadTime;
        }
    }

    private void Lose()
    {

    }
    private void Win()
    {

    }
}
