using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBuilding : MonoBehaviour
{



    public GameObject Cam;
    public float grid;

    // Start is called before the first frame update
    void Start()
    {

    }

    float Gridify(float num)
    {


        return num - num % grid;
    }

    // Update is called once per frame

    void Update()
    {
        


        RaycastHit HitInfo;

        if (Input.GetMouseButtonDown(1) && Physics.Raycast(Cam.transform.position, Cam.transform.forward, out HitInfo, 100.0f))
        {
            GameObject Block = Instantiate(GameObject.Find("Cube"));
            Block.transform.parent = GameObject.Find("Cubes").transform;

            Block.name = "NewCube";

            Vector3 OgPoint;



            if (HitInfo.transform.gameObject.name == "NewCube")
            {
                Vector3 Norm = HitInfo.normal * grid;


                OgPoint = HitInfo.transform.position + Norm;


            }
            else
            {
                OgPoint = new Vector3(Gridify(HitInfo.point.x), Gridify(HitInfo.point.y + grid), Gridify(HitInfo.point.z));
            }

            Block.transform.position = OgPoint;
        }

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(Cam.transform.position, Cam.transform.forward, out HitInfo, 100.0f) && HitInfo.transform.gameObject.name == "NewCube")
        {
            Destroy(HitInfo.transform.gameObject);
        }


        
    }
}
