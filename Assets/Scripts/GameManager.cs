using UnityEngine;

public class GameManager : MonoBehaviour
{
    // GameManager���ǂ�����ł��g����悤�ɂ���
    public static GameManager Instance;

    // �Q�[���I�[�o�[��ʁiCanvas��UI�j
    public GameObject gameOverUI;

    public GameObject player;

    void Awake()
    {
        // �V���O���g���i1�������݂�����j
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[���؂�ւ��ł������Ȃ�
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �Q�[���I�[�o�[����
    public void GameOver()
    {
        // �q����؂藣��
        Camera.main.transform.parent = null;

        // �v���C���[������
        if (player != null)
        {
            Destroy(player);
        }

        // UI��\��
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        // ���Ԃ��~�߂�i�C�Ӂj
        Time.timeScale = 0f;
    }
}
