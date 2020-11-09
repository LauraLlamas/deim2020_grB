using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraLook : MonoBehaviour
{
    [SerializeField] Transform Tarjet;
    [SerializeField] float smoothVelocity = 0.3F;
    [SerializeField] Vector3 camaraVelocity = Vector3.zero;
    [SerializeField] Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Tarjet);
        Vector3 targetPosition = new Vector3(transform.position.x, playerPosition.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);
    }
}
