using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    Camera fpsCamera;
    public float fireRate = 0.1f;
    public float fireTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fireTimer<fireRate)
        {
            fireTimer += Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1")&&fireTimer>fireRate)
        {
            fireTimer = 0.0f;

            RaycastHit _hit;
            Ray ray = fpsCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray,out _hit,100))
            {
                Debug.Log(_hit.collider.gameObject.name);
            }
        }
    }
}
