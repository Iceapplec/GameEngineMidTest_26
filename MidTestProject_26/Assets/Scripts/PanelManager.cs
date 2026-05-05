using UnityEngine;

public class PanelManager : MonoBehaviour
{
    // Inspector에 LeaderPanel GameObject 할당 (비활성 상태여도 OK)
    public GameObject leaderPanel;

    private void Awake()
    {
        // 안전하게 초기에는 숨김(Inspector에서 이미 비활성화해도 상관 없음)
        if (leaderPanel != null)
            leaderPanel.SetActive(false);
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
}
