using System;
using System.IO;
using System.Linq;
using UnityEngine;

public class EnumMaker : MonoBehaviour
{
    private static readonly string EnumScriptName = "DataEnum";


    //[MenuItem("EnumMaker/Execute", false, 100)]

    private static void MakeEnum()
    {
        try
        {
            // 현재 실행 중인 디렉토리 경로 가져오기
            var currentDirectory = Application.dataPath + "\\Scripts\\EnumSet";

            // CSV 파일 경로 (상대 경로)
            var csvPath = Path.Combine(currentDirectory, "CSV_Data.csv");

            // CSV 읽기
            var lines = File.ReadAllLines(csvPath);

            var enumEntries = lines.Skip(0)
                .Select(line => line.Split(','))
                .Select(columns => new
                {
                    Number = int.Parse(columns[0]),
                    Letter = columns[1]
                })
                .Select(entry => $"{entry.Letter} = {entry.Number}");

            // Enum 파일 생성 경로 (상대 경로)
            var enumFilePath = Path.Combine(currentDirectory, EnumScriptName + ".cs");

            // Enum 파일에 들어갈 내용
            var enumContent = $@"
public enum {EnumScriptName}
{{
    {string.Join(",\n    ", enumEntries)}
}}
";

            // Enum 파일 생성
            File.WriteAllText(enumFilePath, enumContent);

            Debug.Log($"Enum 파일이 '{enumFilePath}'에 생성되었습니다.");
        }
        catch (Exception e)
        {
            Debug.Log(e);

            throw;
        }
    }
}