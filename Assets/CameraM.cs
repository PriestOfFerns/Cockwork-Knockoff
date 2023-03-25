using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraM : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;
    public float Sensitivity;

    private Camera cam;


    public static float ClampAngle(float current, float min, float max)
    {
        float dtAngle = Mathf.Abs(((min - max) + 180) % 360 - 180);
        float hdtAngle = dtAngle * 0.5f;
        float midAngle = min + hdtAngle;

        float offset = Mathf.Abs(Mathf.DeltaAngle(current, midAngle)) - hdtAngle;
        if (offset > 0)
            current = Mathf.MoveTowardsAngle(current, midAngle, offset);
        return current;
    }


    void Start()
    {
        cam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame

    void Update()
    {
        transform.position = Player.transform.position;



        Vector3 Current = transform.rotation.eulerAngles;


        Vector3 CurrentP = Player.transform.rotation.eulerAngles;

        Player.transform.eulerAngles = new Vector3(CurrentP.x, CurrentP.y + Input.GetAxis("Mouse X") * Sensitivity, CurrentP.z);

        transform.eulerAngles = new Vector3(ClampAngle(Current.x - Input.GetAxis("Mouse Y") * Sensitivity, -90f, 90f), Player.transform.eulerAngles.y, Current.z);


    }
}
