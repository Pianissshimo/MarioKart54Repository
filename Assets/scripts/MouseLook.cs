using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivityX = 1000f;
    public float mouseSensitivityY = 500f;
    public Transform playerBody; // �J�����̐e�i�v���C���[�{�́j

    float xRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // �}�E�X�J�[�\�����\������ʒ����ɌŒ�
        Cursor.visible = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        // �㉺�̎��_�iX����]�j�𐧌��i�񂪉�肷���Ȃ��悤�Ɂj
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // �J�����̏㉺��]
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // �v���C���[�̍��E��]
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
