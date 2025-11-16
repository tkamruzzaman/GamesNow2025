using UnityEngine;

public class SubmissionArea : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        // FindFirstObjectByType を使用して警告を解消
        gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("SubmissionArea: GameManagerがシーンに見つかりません。");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ⭐ ⭐ 追加: 何かがトリガーに入ったか確認 ⭐ ⭐
        Debug.Log("トリガーに入ったオブジェクト: Trigger entered object " + other.gameObject.name);

        if (other.CompareTag("Ball"))
        {
            // ⭐ ⭐ 追加: ボールが検出されたか確認 ⭐ ⭐
            Debug.Log("ボールが検出されました。判定処理に進みます。Ball detected. Proceeding to judgment process.");

            // Rigidbodyを一度だけ取得
            Rigidbody ballRb = other.GetComponent<Rigidbody>();

            // 物理演算が動いている状態でのみ処理（掴んでいる状態ではないこと）
            if (ballRb != null && !ballRb.isKinematic)
            {
                // 1. ボールをゲームマネージャーに提出
                gameManager.SubmitBall(other.gameObject);

                // 2. 提出後のボールを固定し、衝突判定を無効化
                ballRb.isKinematic = true;
                Collider ballCollider = other.GetComponent<Collider>();
                if (ballCollider != null)
                {
                    ballCollider.enabled = false;
                }
            }
        } // <- 閉じ括弧が不足していた最初のif文のブロックをここで閉じます。
    }

}