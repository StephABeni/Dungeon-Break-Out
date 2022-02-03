using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam
{
    Vector3 pos, dir;

    // every update we create and destroy laser beam
    // GameObject allows it to be destroyed easilly every update
    public GameObject laserObj;
    // display and update actual laser and attach it to the GameObject above
    LineRenderer laser;
    // store each point of the laser beam
    List<Vector3> laserIndices = new List<Vector3>();

    // start positon of laser, direction, material
    public LaserBeam(Vector3 pos, Vector3 dir, Material material)
    {
        // set-up laser beam object
        this.laser = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.name = "Laser Beam";
        this.pos = pos;
        this.dir = dir;

        // add line render to GameObject that we create every time a laser beam is created
        this.laser = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.laser.startWidth = 0.1f;
        this.laser.endWidth = 0.1f;
        this.laser.material = material;
        this.laser.startColor = Color.blue;
        this.laser.endColor = Color.blue;

        CastRay(pos, dir, laser);
    }

    void CastRay(Vector3 pos, Vector3 dir, LineRenderer laser)
    {
        laserIndices.Add(pos);

        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        // if ray hits an object, we add the position of where it glides to laser indices list
        // else if it doesn't
        if (Physics.Raycast(ray, out hit, 30, 1))
        {
            // check if rayvast hit mirror or another object
            CheckHit(hit, dir, laser);
        } 
        else
        {
            // add a ray 30 units long to the laser indices list
            laserIndices.Add(ray.GetPoint(30));
            UpdateLaser();
        }
    }

    void UpdateLaser()
    {
        int count = 0;
        laser.positionCount = laserIndices.Count;

        foreach (Vector3 idx in laserIndices)
        {
            laser.SetPosition(count, idx);
            count++;
        }
    }

    void CheckHit(RaycastHit hitInfo, Vector3 direction, LineRenderer laser)
    {
        if (hitInfo.collider.gameObject.tag == "Mirror")
        {
            // we need to get the reflected direction of the beam
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);

            // above gives a new direction that we can use to cast another array
            CastRay(pos, dir, laser);
        }
        else // raycasat doesn't hit a mirror, add the hitpoint to laser indidces list and update the laser
        {
            laserIndices.Add(hitInfo.point);
            UpdateLaser();
        }
    }
}
