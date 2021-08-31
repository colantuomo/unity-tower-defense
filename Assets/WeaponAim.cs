using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    public float turnSpeed = 2f;
    public float searchArea = 2f;
    public float shootDelay = 5f;
    public float weaponDamage = 1f;
    public float raycastLengh = 5f;
    public Transform shootPoint;

    private float _timeRemaining;
    private Animator _anim;

    private void Start()
    {
        _timeRemaining = shootDelay;
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Collider enemy = Physics.OverlapSphere(transform.position, searchArea, LayerMask.GetMask("Enemy")).FirstOrDefault();
        if (enemy != null)
        {
            LookAt(enemy.transform.position);
            if (CanShoot())
            {
                if (IsNear(enemy.transform.position))
                {
                    enemy.GetComponent<HealthManager>().Hit(weaponDamage);
                    _anim.Play("Shoot");
                    _timeRemaining = shootDelay;
                }
            }
        }
    }

    private bool IsNear(Vector3 target)
    {
        float MIN_DISTANCE = 2f;
        return Vector3.Distance(transform.position, target) <= MIN_DISTANCE;
    }

    private void LookAt(Vector3 targetPosition)
    {
        Vector3 lookPos = targetPosition - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
    }

    private bool CanShoot()
    {
        return _timeRemaining <= 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchArea);
    }
}
