using UnityEngine;

public class PlayerUnko : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度（調整可能）

    public float jumpForce = 5f;         // ジャンプの力

    private Rigidbody rb;

    private bool isGrounded = false;     // 地面に接地しているかの判定用

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
            this.transform.position += this.transform.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += this.transform.right * -1 * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += this.transform.forward * -1 * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += this.transform.right * moveSpeed * Time.deltaTime;
        }

        // スペースキーが押されて、かつ地面にいるときジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;  // ジャンプしたので空中状態に
        }
    }

    //地面に接触したらisGroundedをtrueにする
    private void OnCollisionEnter(Collision collision)
    {
        // 例えば地面のタグが"Ground"の場合だけ判定するなら
        if (collision.gameObject.CompareTag("Field"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            Debug.Log("ゲームオーバー！");
            GameManager.Instance.GameOver(); // シングルトンの場合
        }
    }
}
