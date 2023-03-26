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
           



            if (HitInfo.transform.parent && HitInfo.transform.parent.name == "Cubes")
            {
                bool Can = HitInfo.transform.gameObject.GetComponent<BaseCube>().onRightClick();

                if (Can)
                {

                    GameObject Block = Instantiate(GameObject.Find("BaseCube"));
                    Block.transform.parent = GameObject.Find("Cubes").transform;

                    Block.name = "NewCube";

                    Vector3 Norm = HitInfo.normal * grid;


                    Block.transform.position = HitInfo.transform.position + Norm;

                } else
                {

                }
                


            }
            else
            {

                GameObject Block = Instantiate(GameObject.Find("BaseCube"));
                Block.transform.parent = GameObject.Find("Cubes").transform;

                Block.name = "NewCube";

                

                Block.transform.position  = new Vector3(Gridify(HitInfo.point.x), Gridify(HitInfo.point.y + grid), Gridify(HitInfo.point.z));
            }

            
        }

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(Cam.transform.position, Cam.transform.forward, out HitInfo, 100.0f) && HitInfo.transform.gameObject.name == "NewCube")
        {
            Destroy(HitInfo.transform.gameObject);
        }


        
    }
}
