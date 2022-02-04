using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code adapted from https://www.youtube.com/watch?v=pNE3rfMGEAw
public class ShootLaser : MonoBehaviour
{
    public Material material;
    LaserBeam beam;

    void Update()
    {
        if (beam != null)
        {
            Destroy(beam.laserObj);
        }
        beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material);
    }
}
