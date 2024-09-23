using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

class EunmMaker : MonoBehaviour
{

    [ContextMenu("exe")]
    void Main()
    {
        // 현재 실행 중인 디렉토리 경로 가져오기
        string currentDirectory = Application.dataPath + "\\Scripts\\EnumSet";

        // CSV 파일 경로 (상대 경로)
        string csvPath = Path.Combine(currentDirectory, "CSV_Data.csv");

        // CSV 읽기
        var lines = File.ReadAllLines(csvPath);

        // 첫 번째 라인은 헤더일 수 있으므로, 실제 데이터는 그 다음부터
        var enumEntries = lines.Skip(0)  // 헤더를 건너뜀
                               .Select(line => line.Split(','))
                               .Select(columns => new
                               {
                                   Number = int.Parse(columns[0]),  // 첫 번째 열은 숫자
                                   Letter = columns[1]              // 두 번째 열은 문자
                               })
                               .Select(entry => $"{entry.Letter} = {entry.Number}");

        // Enum 파일 생성 경로 (상대 경로)
        string enumFilePath = Path.Combine(currentDirectory, "TestEnum.cs");

        // Enum 파일에 들어갈 내용
        string enumContent = $@"
public enum TestEnum
{{
    {string.Join(",\n    ", enumEntries)}
}}
";

        // Enum 파일 생성
        File.WriteAllText(enumFilePath, enumContent);

        Console.WriteLine($"Enum 파일이 '{enumFilePath}'에 생성되었습니다.");
    }
}
