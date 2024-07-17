using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class Utils
{
    /// <summary>
    /// 해당 interface를 상속받는 클래스를 모두 가져온다.
    /// </summary>
    /// <typeparam name="T">interface를 상속받는 클래스</typeparam>
    /// <returns></returns>
    public static IEnumerable<Type> GetAllInterface<T>()
    {
        //class.IsAssignableFrom() => class가 어떤 "클래스 or 인터페이스"를 "상속 or 구현" 했는지 체크
        return Assembly.GetAssembly(typeof(T)).GetTypes().Where(type => type.IsClass && typeof(T).IsAssignableFrom(type));
    }

    /// <summary>
    /// 복사해온 URL 에서 edit?usp=sharing 제거후 제거된 부분에 export?format=tsv&range=시트 범위&gid=시트ID값
    /// </summary>
    /// <param name="address">https:// ~ /</param>
    /// <param name="range">구글 시트 Range</param>
    /// <param name="sheetID">시트 고유 ID</param>
    /// <returns></returns>
    public static string GetGoogleSheetAddress(string address, string range, string sheetID)
    {
        return $"{address}/export?format=tsv&range={range}&gid={sheetID}";
    }

    public static int SumInt(int a, int b)
    {
        return a + b;
    }


}
