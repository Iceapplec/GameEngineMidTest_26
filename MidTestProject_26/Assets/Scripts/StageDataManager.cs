using System.Collections.Generic;
using System.IO;
using UnityEngine;

// StageResult: 플레이어의 한 번의 스테이지 결과를 저장하는 데이터 클래스
// - playerName: 플레이어 이름
// - stage: 플레이어가 플레이한 스테이지 번호
// - score: 해당 시도에서 기록한 점수
[System.Serializable]
public class StageResult
{
    public string playerName;
    public int stage;
    public int score;
}

// StageResultList: 여러 StageResult 항목을 담기 위한 래퍼 클래스
// JsonUtility가 제네릭 리스트를 바로 직렬화/역직렬화하지 못하기 때문에
// List를 포함하는 클래스로 감싸서 사용한다.
[System.Serializable]
public class StageResultList
{
    // result: 저장된 StageResult 항목들의 리스트
    public List<StageResult> result = new List<StageResult>();

}

// StageResultSaver: StageResultList를 파일에 저장하고 불러오는 정적 유틸리티 클래스
// 동작 요약:
// - SaveStage(stage, score): 현재 플레이어 이름을 PlayerPrefs에서 가져와 새로운 StageResult를 생성하고
//   기존 저장 리스트에 추가한 후 JSON으로 직렬화하여 persistentDataPath에 파일로 쓴다.
// - LoadInternal(): 파일이 있으면 JSON을 읽어 역직렬화하여 StageResultList를 반환하고,
//   파일이 없거나 역직렬화 실패 시 빈 StageResultList를 반환한다.
public static class StageResultSaver
{
    // 저장할 파일 이름
    private const string FILE = "stage_results.json";
    // PlayerPrefs에서 플레이어 이름을 읽어올 때의 키
    private const string PLAYER_NAME = "PlayerName";
    // 실제 파일 경로: Application.persistentDataPath 내부의 FILE
    private static string filePath = Path.Combine(Application.persistentDataPath, FILE);

    // SaveStage: 주어진 스테이지와 점수를 파일에 저장한다.
    // 1) 기존에 저장된 리스트를 불러온다.
    // 2) PlayerPrefs에서 플레이어 이름을 읽어 새로운 StageResult를 만든다.
    // 3) 리스트에 추가하고 JSON으로 직렬화하여 파일에 쓴다.
    public static void SaveStage(int stage, int score)
    {
        StageResultList list = LoadInternal();
        string playerName = PlayerPrefs.GetString(PLAYER_NAME, "");
        StageResult entry = new StageResult
        {
            playerName = playerName,
            stage = stage,
            score = score
        };
        list.result.Add(entry);
        // pretty print(true)로 보기 좋게 저장
        string json = JsonUtility.ToJson(list, true);
        File.WriteAllText(filePath, json);
    }

    public static StageResultList LoadRank()
    {
        return LoadInternal();
    }

    // LoadInternal: 내부적으로 파일에서 저장된 StageResultList를 읽어 반환한다.
    // 파일이 존재하지 않거나 읽기/역직렬화에 실패하면 빈 리스트를 반환한다.
    private static StageResultList LoadInternal()
    {
        if (!File.Exists(filePath))
        {
            return new StageResultList();
        }
        string json = File.ReadAllText(filePath);
        StageResultList list = JsonUtility.FromJson<StageResultList>(json);
        if (list == null)
        {
            return new StageResultList();
        }
        else
        {
            return list;
        }
    }
}
