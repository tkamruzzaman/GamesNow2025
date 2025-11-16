using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Header("生成設定")]
    public GameObject ballPrefab;
    public int numberOfBalls = 1500;
    public Vector3 spawnArea = new Vector3(10, 10, 10); // 部屋のサイズに合わせる

    [Header("設定データへの参照")]
    public BallTraitConfig configManager;

    void Start()
    {
        SpawnBalls();
    }

    void SpawnBalls()
    {
        if (configManager == null || configManager.traitSets == null || configManager.traitSets.Length == 0)
        {
            Debug.LogError("BallTraitConfigが設定されていないか、特徴セットが定義されていません。");
            return;
        }

        for (int i = 0; i < numberOfBalls; i++)
        {
            // 1. 設定リストからランダムな特徴セットを選択
            BallTraitSet randomTraitSet = configManager.traitSets[
                Random.Range(0, configManager.traitSets.Length)
            ];

            // 2. ランダムな位置を計算 (部屋のサイズ内に収まるように)
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                spawnArea.y,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // 3. ボールを生成
            GameObject newBall = Instantiate(ballPrefab, randomPosition, Quaternion.identity);

            // 4. 見た目（マテリアル）を適用
            Renderer ballRenderer = newBall.GetComponent<Renderer>();
            if (ballRenderer != null && randomTraitSet.ballMaterial != null)
            {
                ballRenderer.material = randomTraitSet.ballMaterial;
            }

            // 5. 判定データ（特徴）を適用
            BallData ballData = newBall.GetComponent<BallData>();
            if (ballData != null)
            {
                ballData.hasBigEyes = randomTraitSet.hasBigEyes;
            }
        }
    }
}