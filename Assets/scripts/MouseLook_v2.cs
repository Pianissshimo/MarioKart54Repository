using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerBody;        // �v���C���[�̑́i�e�I�u�W�F�N�g�j
    public Transform cameraRig;         // CameraRig�i��I�u�W�F�N�g�j�AplayerBody�̎q
    public Transform cameraTransform;   // Main Camera�icameraRig�̎q�j

    public Vector3 firstPersonOffset = new Vector3(0f, 1.6f, 0f);
    public Vector3 thirdPersonOffset = new Vector3(0f, 3f, -6f);

    public float mouseSensitivityX = 1000f;
    public float mouseSensitivityY = 500f;

    private float xRotation = 0f;
    private bool isFirstPerson = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // �}�E�X����ʒ����ɌŒ�
        Cursor.visible = false;

        // �����͈�l�̎��_�ɃZ�b�g
        SwitchToFirstPerson();
    }

    void Update()
    {
        // �}�E�X����
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        // �v���C���[�̍��E��]�iY���j
        playerBody.Rotate(Vector3.up * mouseX);

        // �㉺���_�̉�]�ʂ𐧌�
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        if (isFirstPerson)
        {
            // ��l�̎��_�FcameraRig��playerBody�̎q�Ȃ̂Ń��[�J����]�ŏ㉺���_�𑀍�
            cameraRig.localPosition = firstPersonOffset;
            cameraRig.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
        else
        {
            // �O�l�̎��_�FcameraRig�̈ʒu��playerBody�̌���ɐݒ�
            cameraRig.localPosition = thirdPersonOffset;

            // �J�����icameraTransform�j��playerBody�̓��̕����Ɍ�����
            Vector3 lookTarget = playerBody.position + Vector3.up * 1.6f;
            cameraTransform.LookAt(lookTarget);
            // cameraRig��playerBody�̎q�̂܂܉�]�̓��Z�b�g���Ă����i��]��cameraTransform�ɔC����j
            cameraRig.localRotation = Quaternion.identity;
        }

        // ���_�؂�ւ�
        if (Input.GetKeyDown(KeyCode.C))
        {
            isFirstPerson = !isFirstPerson;
            if (isFirstPerson) SwitchToFirstPerson();
            else SwitchToThirdPerson();
        }
    }

    void SwitchToFirstPerson()
    {
        // ��l�̎��_�̏����ݒ�
        cameraRig.localPosition = firstPersonOffset;
        cameraRig.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void SwitchToThirdPerson()
    {
        // �O�l�̎��_�̏����ݒ�
        cameraRig.localPosition = thirdPersonOffset;
        cameraRig.localRotation = Quaternion.identity;
    }
}
