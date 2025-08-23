using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;

    public float timeBetweenShoot = .2f;

    public float speed = 50f;

    //public AudioSource audioSource;

    private Coroutine _currentCoroutine;

    //private Vector3 direction;

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.G))
    //    {
    //        _currentCoroutine = StartCoroutine(StartShoot());
    //        //PlayShootSound();
    //    }else if (Input.GetKeyUp(KeyCode.G))
    //    {
    //        if(_currentCoroutine != null)
    //        {
    //            StopCoroutine(_currentCoroutine);
    //        }
    //    }
    //}

    protected virtual IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public virtual void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.transform.rotation = positionToShoot.rotation;
    }

    public void StartShoot()
    {
        _currentCoroutine = StartCoroutine(ShootCoroutine());
    }

    public void StopShoot()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
    }

    //public void PlayShootSound()
    //{
    //    audioSource.Play();
    //}
}
