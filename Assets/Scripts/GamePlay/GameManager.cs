using UnityEngine;
using TMPro;
using System.Text;

public class GameManager : MonoBehaviour
{
    [Header("UI設定")]
    public TextMeshProUGUI criteriaText;

    [Header("現在のCUTE Criteria")]
    public GameObject criteriaHolder;

    [Header("NPC設定")]
    public Animator npcAnimator;
    public string successTriggerName = "SUCCESS";
    public string failTriggerName = "FAIL";

    [Header("時間管理")]
    public float roundTime = 60f;
    private float currentTime;
    private bool isGameOver = false;

    [Header("UI")]
    [SerializeField] private GameUI gameUI;

    void Start()
    {
        if (criteriaHolder == null)
        {
            Debug.LogError("GameManager: Criteria HolderがInspectorで割り当てられていません！GameManager: Criteria Holder is not assigned in the Inspector!");
            return;
        }

        currentTime = roundTime;
        StartNewRound();
    }

    void Update()
    {
        if (isGameOver) return;

        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;
            EndGame(false);
        }
    }

    public void StartNewRound()
    {
        if (isGameOver || criteriaHolder == null) return;

        BallData criteria = criteriaHolder.GetComponent<BallData>();
        if (criteria == null)
        {
            Debug.LogError("Criteria HolderにBallDataコンポーネントが見つかりません。BallData component not found on Criteria Holder");
            return;
        }

        currentTime = roundTime;
        Debug.Log("--- 新しいラウンドを開始します ------ Starting a new round ---");

        // ⭐ ⭐ ⭐ テストのため、正解条件を必ず TRUE に固定する ⭐ ⭐ ⭐
        // これで、BallTraitConfigで hasBigEyes=true に設定されたボールだけが正解になります。
        criteria.hasBigEyes = true;

        // (UI更新処理は省略)
    }

    // SubmissionAreaから呼ばれる提出処理
    public void SubmitBall(GameObject submittedBall)
    {
        BallData criteria = criteriaHolder.GetComponent<BallData>();
        BallData submittedData = submittedBall.GetComponent<BallData>();

        if (criteria == null || submittedData == null) return;

        // 判定ロジック: hasBigEyes の値が一致するかどうかをチェック
        bool isCorrect = (criteria.hasBigEyes == submittedData.hasBigEyes);

        if (isCorrect)
        {
            Debug.Log("🎉 正解です！ (特徴が一致)Correct! (Traits matched)");

            if (npcAnimator != null)
            {
                npcAnimator.SetTrigger(successTriggerName);
            }
            //Invoke("StartNewRound", 5f);
            EndGame(true);
        }
        else
        {
            Debug.Log("😭 不正解です。特徴が一致しませんでした。Incorrect. Traits did not match.");

            if (npcAnimator != null)
            {
                npcAnimator.SetTrigger(failTriggerName);
            }
            currentTime -= 10f;
        }
    }

    public void EndGame(bool won)
    {
        isGameOver = true;
        Debug.Log(won ? "ゲームクリア！" : "時間切れでゲームオーバー。");
        gameUI.ShowGameOverPanel(won);
    }
}