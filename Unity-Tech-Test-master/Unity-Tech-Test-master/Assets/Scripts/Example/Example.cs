// (C) king.com Ltd 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Services;

public class Example : MonoBehaviour {

    struct Level : IToplistIdentifier
    {
        public int LevelIndex
        {
            get;
            set;
        }
    }

    Toplist toplist;

    Level current;
    LocalToplist provider;

    void Awake()
    {
        provider = new LocalToplist();
        toplist = FindObjectOfType<Toplist>();
    }

    void Start()
    {
        SetLevel(1);
    }

    public void SetLevel(int level)
    {
        current = new Level { LevelIndex = level };
    }

    public void SetUsername(string username)
    {
        provider.SetLocalUsername(username);
    }

    public void ReportScore(int score)
    {
        provider.ReportResult(current, score);
    }

    public void ShowToplist()
    {
        toplist.Display(provider, current);
    }
}
