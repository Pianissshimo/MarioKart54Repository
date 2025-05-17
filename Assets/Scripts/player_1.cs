using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f; // �ړ����x�i�����\�j

    public float jumpForce = 5f;         // �W�����v�̗�

    private Rigidbody rb;

    private bool isGrounded = false;     // �n�ʂɐڒn���Ă��邩�̔���p

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

        // �X�y�[�X�L�[��������āA���n�ʂɂ���Ƃ��W�����v
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;  // �W�����v�����̂ŋ󒆏�Ԃ�
        }
    }

    //�n�ʂɐڐG������isGrounded��true�ɂ���
    private void OnCollisionEnter(Collision collision)
    {
        // �Ⴆ�Βn�ʂ̃^�O��"Ground"�̏ꍇ�������肷��Ȃ�
        if (collision.gameObject.CompareTag("Field"))
        {
            isGrounded = true;
        }
    }
}
