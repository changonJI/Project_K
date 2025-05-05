using System.Collections;
using System.Collections.Generic;
using Test_Speak;
using UnityEngine;


public class CSPractice : MonoBehaviour
{
    TestSpeak testSpeak = new TestSpeak();
    testData data;

    private void Start()
    {
        test();
        
        Debug.Log(data.b);

    }

    public void test()
    {
        testSpeak.Test();

        data = new testData { a = 0, b = 1 };

        Debug.Log(data.b);
        
        data = new testData();
    }
}

namespace Test_Speak
{
    public class TestSpeak
    {
        public void Test() {}
    }

    public struct testData
    {
        public int a;
        public int b;

        public int Get()
        {
            return a;
        }

        HashSet<int> set;
        Hashtable table;
        
    }
}