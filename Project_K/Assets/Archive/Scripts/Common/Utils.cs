using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class Utils
{
    /// <summary>
    /// �ش� interface�� ��ӹ޴� Ŭ������ ��� �����´�.
    /// </summary>
    /// <typeparam name="T">interface�� ��ӹ޴� Ŭ����</typeparam>
    /// <returns></returns>
    public static IEnumerable<Type> GetAllInterface<T>()
    {
        //class.IsAssignableFrom() => class�� � "Ŭ���� or �������̽�"�� "��� or ����" �ߴ��� üũ
        return Assembly.GetAssembly(typeof(T)).GetTypes().Where(type => type.IsClass && typeof(T).IsAssignableFrom(type));
    }

    /// <summary>
    /// �����ؿ� URL ���� edit?usp=sharing ������ ���ŵ� �κп� export?format=tsv&range=��Ʈ ����&gid=��ƮID��
    /// </summary>
    /// <param name="address">https:// ~ /</param>
    /// <param name="range">���� ��Ʈ Range</param>
    /// <param name="sheetID">��Ʈ ���� ID</param>
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
