using UnityEngine;

public class MousePickup : MonoBehaviour
{
    [Header("Setup")]
    public Transform holdPoint;      // ボールを持つ位置（カメラ or プレイヤーの子）
    public float pickupRange = 3f;   // 何メートル先まで拾えるか
    public LayerMask pickupLayer;    // 拾えるレイヤー（未設定なら無視してもOK）

    private Rigidbody heldRb;        // いま持っているボール
    private Camera cam;

    void Start()
    {
        // このスクリプトはカメラに付ける想定
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    void Update()
    {
        // 左クリックで「つかむ / 離す」
        if (Input.GetMouseButtonDown(0))
        {
            if (heldRb == null)
            {
                TryPickup();
            }
            else
            {
                Drop();
            }
        }

        // 持っている間は、常に HoldPoint にくっつける
        if (heldRb != null && holdPoint != null)
        {
            heldRb.MovePosition(holdPoint.position);
        }
    }

    void TryPickup()
    {
        if (cam == null) return;

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        // pickupLayer を設定していない場合は、普通の Raycast でOK
        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Ball"))
            {
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    heldRb = rb;
                    heldRb.isKinematic = true;                // 物理を止める
                    heldRb.transform.SetParent(holdPoint);    // カメラの子にする
                    heldRb.transform.localPosition = Vector3.zero;
                }
            }
        }
    }

    void Drop()
    {
        if (heldRb == null) return;

        heldRb.isKinematic = false;
        heldRb.transform.SetParent(null);
        heldRb = null;
    }
}
