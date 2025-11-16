using UnityEngine;

[System.Serializable]
public struct BallTraitSet
{
    [Header("見た目（マテリアル）")]
    public Material ballMaterial;

    [Header("判定データ（特徴）")]
    // 特徴を一つに絞る
    public bool hasBigEyes;

    public int colorID;
}

public class BallTraitConfig : MonoBehaviour
{
    [Tooltip("利用可能なすべてのボールの特徴セットを設定してください。")]
    public BallTraitSet[] traitSets;
}