using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
public class CsharpDemoManager {
    public List<int> listData;
    public Dictionary<int, int> dicData;
    public int[] aryData;
    public ArrayList aryListData;
    private static CsharpDemoManager instance;
    public List<double> timeResult;//顺序是List、Dic、Ary、AryList

    private int aryIndex = 0;
    public static CsharpDemoManager GetInstance() {
        if (instance==null) {
            instance = new CsharpDemoManager();
        }
        return instance;
    }
    private CsharpDemoManager() {
        aryData = new int[1024];
        for (int i = 0; i < 1024;i++ ) {
            aryData[i] = 0;
        }
        aryListData = new ArrayList();
        dicData = new Dictionary<int, int>();
        listData = new List<int>();
        timeResult = new List<double>();
    }

    public void AddData(int data) {
        timeResult.Clear();
        timeResult.Add(AddList(data));
        timeResult.Add(AddDict(data));
        timeResult.Add(AddAry(data));
        timeResult.Add(AddAryList(data));
        
    }

    private double AddList(int data) {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        listData.Add(data);
        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
    private double AddDict(int data) {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        dicData.Add(data,0);
        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
    private double AddAry(int data) {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        aryData[aryIndex++] = data;
        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
    private double AddAryList(int data) {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        aryListData.Add(data);
        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
    public void DeleteData(int data) {
        timeResult.Clear();
        timeResult.Add(DeleteList(data));
        timeResult.Add(DeleteDict(data));
        timeResult.Add(DeleteAry(data));
        timeResult.Add(DeleteAryList(data));
        
    }
    private double DeleteList(int data) {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        if (!listData.Remove(data)){
            return -1;
        }
        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
    private double DeleteDict(int data) {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        if (!dicData.Remove(data)) {
            return -1;
        }
        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
    private double DeleteAry(int data) {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        bool deleted = false;
        for (int i=0;i<1024;i++){
            if (aryData[i]==data){
                deleted = true;
                for (int j = 1023; j > i; j--) {
                    aryData[j - 1] = aryData[j];
                }
            }
        }
        
        if (!deleted){
            return -1;
        }
        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
    private double DeleteAryList(int data) {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        var cout1=aryListData.Count;
        aryListData.Remove(data);
        var cout2 = aryListData.Count;

        if (cout1==cout2){
            return -1;
        }
        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
    public void SortData() {
        timeResult.Clear();
        timeResult.Add(SortList());
        timeResult.Add(SortDict());
        timeResult.Add(SortAry());
        timeResult.Add(SortAryList());
    }
    private double SortList() {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        listData.Sort();
        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
    private double SortDict() {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        dicData.OrderBy(i=>i.Value);
        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
    private double SortAry() {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        Array.Sort(aryData);
        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
    private double SortAryList() {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();

        aryListData.Sort();

        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
    public void SearchData(int data) {
        timeResult.Clear();
        timeResult.Add(SearchList(data));
        timeResult.Add(SearchDict(data));
        timeResult.Add(SearchAry(data));
        timeResult.Add(SearchAryList(data));

    }
    private double SearchList(int data) {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        
        if (listData.IndexOf(data)==-1){
            return -1;
        }
        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
    private double SearchDict(int data) {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        if (dicData.ContainsKey(data) ==false) {
            return -1;
        }
        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
    private double SearchAry(int data) {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        bool found = false;
        for (int i = 0; i < 1024; i++) {
            if (aryData[i] == data) {
                found=true;
            }
        }
        if (!found) {
            return -1;
        }
        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
    private double SearchAryList(int data) {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        if (aryListData.IndexOf(data) == -1) {
            return -1;
        }
        stopwatch.Stop();
        System.TimeSpan timespan = stopwatch.Elapsed;
        double milliseconds = timespan.TotalMilliseconds;

        return milliseconds;
    }
}
