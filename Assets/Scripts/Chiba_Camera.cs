using UnityEngine;

public class Chiba_Camera : MonoBehaviour
{
    private float mouseX = 0f;
    private float mouseY = 0f;
    public float mouseSensitivityX = 1000f;
    public float mouseSensitivityY = 500f;
    public Transform playerBody; // �J�����̐e�i�v���C���[�{�́j

    private bool isFirstPerson = false;// ���݂̎��_��ԁi�����͈�l�́j

    // �J�����̈ʒu�i���[�J�����W�j
    private Vector3 firstPersonOffset = new Vector3(0f, 0f, 0f);  // ��l�̎��_
    public static Vector3 thirdPersonOffset = new Vector3(0f, 2f, -4f); // �O�l�̎��_�i����j

    private float camera_y;

    private float xRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera_y = thirdPersonOffset.y;

        //SwitchToFirstPerson();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isFirstPerson)
            {
                SwitchToThirdPerson();
            }
            else
            {
                SwitchToFirstPerson();
            }

            isFirstPerson = !isFirstPerson;
        }

        mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        // �㉺�̎��_�iX����]�j�𐧌��i�񂪉�肷���Ȃ��悤�Ɂj
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // �J�����̏㉺��]
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if(playerBody != null)
        {
            // �v���C���[�̍��E��]
            playerBody.Rotate(Vector3.up * mouseX);
        }

        //KeepCameraYPosition();
    }

    void SwitchToFirstPerson()
    {
        transform.localPosition = firstPersonOffset;
        transform.localRotation = Quaternion.identity; // �K�v�Ȃ��]�����Z�b�g
    }

    void SwitchToThirdPerson()
    {
        transform.localPosition = thirdPersonOffset;
        //transform.localRotation = Quaternion.Euler(19f, 0f, 0f); // �K�v�Ȃ��]������
    }

    void KeepCameraYPosition() //���\
    {
        if (isFirstPerson)
        {
            return;
        }
        // 3�l�̎��_�ŃJ������Y���W����Ɉ��ɕۂ�
        Vector3 pos = this.transform.position;
        pos.y = camera_y;
        this.transform.position = pos;
    }
}
