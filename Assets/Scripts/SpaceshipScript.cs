using System.Collections;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    [SerializeField] private float coolDownSeconds;
    bool CanShoot = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    IEnumerator EnableShoot()
    {
        yield return new WaitForSeconds(coolDownSeconds);
        Debug.Log("Ya puedes disparar");
        CanShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && CanShoot)
        {
            Debug.Log("Disparo");
            CanShoot = false;
            //Generar la bala

            //Llamar a la corutina que volverá a activar el disparo
            StartCoroutine(EnableShoot());
        }
    }
}