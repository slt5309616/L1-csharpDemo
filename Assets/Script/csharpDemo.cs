using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class csharpDemo : MonoBehaviour {
    public UIInput inputField;
    public UILabel lblContentArea;
    public UILabel lblSearchResult;
    public UILabel lblList;
    public UILabel lblDict;
    public UILabel lblAry;
    public UILabel lblAryList;
    public UIButton btnAdd;
    public UIButton btnDelete;
    public UIButton btnSort;
    public UIButton btnSearch;
    private bool isNeedUpdate;
    private bool isShowSrch;
    private enum Index {
        LIST=0,
        DIC,
        ARY,
        ARYLIST,
    }
    private CsharpDemoManager manager;
	// Use this for initialization
	void Start () {
        isNeedUpdate = false;
        isShowSrch = false;
        manager = CsharpDemoManager.GetInstance();
        EventDelegate.Add(btnAdd.onClick, OnBtnAddClick);
        EventDelegate.Add(btnDelete.onClick, OnBtnDeleteClick);
        EventDelegate.Add(btnSort.onClick, OnBtnSortClick);
        EventDelegate.Add(btnSearch.onClick, OnBtnSearchClick);
	}
	
	// Update is called once per frame
    void Update() {
        if (!isNeedUpdate){
            return;
        }
        lblList.text = "";
        lblDict.text = "";
        lblAry.text = "";
        lblAryList.text = "";
        lblContentArea.text = "";

        for (int i = 0; i < manager.listData.Count; i++) {
            lblContentArea.text += manager.listData[i];
            lblContentArea.text += "\n";
        }
        lblList.text = "List:"+manager.timeResult[(int)Index.LIST].ToString()+"微妙";
        lblDict.text = "Dict:" + manager.timeResult[(int)Index.DIC].ToString() + "微妙";
        lblAry.text = "Ary:" + manager.timeResult[(int)Index.ARY].ToString() + "微妙";
        lblAryList.text = "AryList:" + manager.timeResult[(int)Index.ARYLIST].ToString() + "微妙";

        isNeedUpdate = false;
        inputField.isSelected = true;

    }


    public  void OnBtnAddClick() {
        
        if (inputField.label.text=="") {
            return;
        }
        
        manager.AddData(int.Parse(inputField.label.text));

        isNeedUpdate = true;
    }
    public void OnBtnDeleteClick() {

        if (inputField.label.text == "") {
            return;
        }

        manager.DeleteData(int.Parse(inputField.label.text));
        isNeedUpdate = true;
    }
    public void OnBtnSortClick() {
        if (inputField.label.text == "") {
            return;
        }

        manager.SortData();
        isNeedUpdate = true;
    }
    public void OnBtnSearchClick() {
        if (inputField.label.text == "") {
            return;
        }

        manager.SearchData(int.Parse(inputField.label.text));
        isNeedUpdate = true;
    }
}
