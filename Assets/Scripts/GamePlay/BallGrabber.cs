using UnityEngine;

public class BallGrabber : MonoBehaviour
{
    [Header("掴む設定")]
    public float grabDistance = 3f;
    public Transform grabPoint;

    private GameObject heldBall = null;
    private Rigidbody heldBallRb = null;
    private Collider heldBallCollider = null;

    void Update()
    {
        // マウスの左ボタン (Fire1) が押された瞬間
        if (Input.GetButtonDown("Fire1"))
        {
            if (heldBall == null)
            {
                TryGrabBall(); // 掴む
            }
        }
        // マウスの左ボタンが離された瞬間
        else if (Input.GetButtonUp("Fire1"))
        {
            if (heldBall != null)
            {
                DropBall(); // 離す
            }
        }

        // ボールを掴んでいる間はGrabPointへ追従
        if (heldBall != null)
        {
            Vector3 targetPosition = grabPoint.position;

            // スムーズに追従させ、位置を更新
            heldBall.transform.position = Vector3.Lerp(
                heldBall.transform.position, targetPosition, Time.deltaTime * 15f);
        }
    }

    void TryGrabBall()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance))
        {
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null && hit.collider.CompareTag("Ball"))
            {
                heldBall = hit.collider.gameObject;
                heldBallRb = rb;
                heldBallCollider = hit.collider;

                heldBallRb.isKinematic = true;

                // 掴んだ瞬間、GrabPointの位置に強制的に移動させる
                heldBall.transform.position = grabPoint.position;

                // 衝突を完全に無効化する
                if (heldBallCollider != null)
                {
                    heldBallCollider.enabled = false;
                }
            }
        }
    }

    void DropBall()
    {
        if (heldBallCollider != null)
        {
            heldBallCollider.enabled = true;
        }

        heldBallRb.isKinematic = false;

        // 少しだけ前に力を加えて投げ出す
        heldBallRb.AddForce(transform.forward * 2f, ForceMode.Impulse);

        heldBall = null;
        heldBallRb = null;
        heldBallCollider = null;
    }
}