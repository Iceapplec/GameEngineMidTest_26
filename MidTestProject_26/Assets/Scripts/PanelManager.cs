using UnityEngine;

public class PanelManager : MonoBehaviour
{
    // Inspector에 LeaderPanel GameObject 할당 (비활성 상태여도 OK)
    public GameObject leaderPanel;
    // STAGE 버튼에 연결할 HighScore 패널들
    public GameObject highScore1Panel;
    public GameObject highScore2Panel;
    public GameObject RankPanel;


    private void Awake()    
    {
        // 안전하게 초기에는 숨김(Inspector에서 이미 비활성화해도 상관 없음)
        if (leaderPanel != null)
            leaderPanel.SetActive(false);
        if (highScore1Panel != null)
            highScore1Panel.SetActive(false);
        if (highScore2Panel != null)
            highScore2Panel.SetActive(false);
    }

    // 버튼에서 호출: 패널을 켬
    public void ShowPanel()
    {
        if (leaderPanel != null)
            leaderPanel.SetActive(true);
    }

    // 버튼에서 호출: 패널을 끔
    public void HidePanel()
    {
        if (leaderPanel != null)
            leaderPanel.SetActive(false);
    }

    // 버튼에서 호출: 토글 동작
    public void TogglePanel()
    {
        if (leaderPanel != null)
            leaderPanel.SetActive(!leaderPanel.activeSelf);
    }

    // STAGE1 버튼에서 호출: HighScore1 패널을 엶
    public void ShowHighScore1()
    {
        if (highScore1Panel != null)
            highScore1Panel.SetActive(true);
    }

    // STAGE2 버튼에서 호출: HighScore2 패널을 엶
    public void ShowHighScore2()
    {
        if (highScore2Panel != null)
            highScore2Panel.SetActive(true);
    }

    // 공용: 모든 HighScore 패널 닫기
    public void HideHighScores()
    {
        if (highScore1Panel != null)
            highScore1Panel.SetActive(false);
        if (highScore2Panel != null)
            highScore2Panel.SetActive(false);
    }

    public void HideSTAGE1()
    {
        if (highScore1Panel != null)
            highScore1Panel.SetActive(false);
    }

    public void HideSTAGE2()
    {
        if (highScore2Panel != null)
            highScore2Panel.SetActive(false);
    }

    public void ShowRankingPanel()
    {
        if (RankPanel != null)
            RankPanel.SetActive(true);
    }

    public void HideRankingPanel()
    {
        if (RankPanel != null)
            RankPanel.SetActive(false);
    }
}
