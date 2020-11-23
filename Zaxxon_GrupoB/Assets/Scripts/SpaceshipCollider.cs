using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCollider : MonoBehaviour
{
    [SerializeField] MeshRenderer myMesh;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            myMesh.enabled = false;
            Time.timeScale = 0f;
        }
    }
}
