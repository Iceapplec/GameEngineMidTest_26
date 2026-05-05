using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string nextLevel;

    public void MoveToNextLevel()
    {
        if (string.IsNullOrEmpty(nextLevel))
        {
            Debug.LogWarning("SceneLoader.nextLevel이 설정되지 않았습니다.");
            return;
        }
        SceneManager.LoadScene(nextLevel);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void QuitGame()
    {
        // 유니티 에디터 내에서는 Application.Quit()이 작동하지 않아 로그로 확인합니다.
        Debug.Log("게임을 종료합니다!");

        // 실제 빌드된 게임(.exe, .apk 등)에서 프로그램을 종료시키는 명령어
        Application.Quit();

        // (선택) 에디터의 플레이 모드에서도 종료되게 하려면 아래 코드를 씁니다.
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        }

    }
