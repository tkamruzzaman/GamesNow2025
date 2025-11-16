using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public Transform playerBody;     // プレイヤー本体（Capsuleなど）
    public float mouseSensitivity = 200f;

    float xRotation = 0f;

    void Start()
    {
        // マウスカーソルを画面中央に固定＆非表示
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // マウスの動き取得
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 上下の回転（カメラだけ）
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);  // 見上げすぎ／見下ろしすぎ防止

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 左右の回転（プレイヤー本体を回す）
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
