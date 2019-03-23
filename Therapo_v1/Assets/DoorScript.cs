using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool open;
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0f;
    public float smooth = 2f;

    // Use this for initialization
    private void Start()
    {
    }

    public void ChangeDoorState()
    {
        open = !open;
    }

    // Update is called once per frame
    private void Update()
    {
        if (open)
        {
            var quaternion = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, quaternion, smooth * Time.deltaTime);
        }
        else
        {
            var quaternion1 = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, quaternion1, smooth * Time.deltaTime);
        }
    }
}