using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // A/D = Horizontal, W/S = Vertical
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0f, v);

        if (dir.sqrMagnitude > 0.01f)
        {
            dir = dir.normalized;

            // 位置を動かす
            transform.position += dir * moveSpeed * Time.deltaTime;

            // 進行方向を向かせる（お好みで）
            transform.forward = dir;
        }
    }
}
