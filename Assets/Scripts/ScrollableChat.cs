using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollableChat : MonoBehaviour {

    /* Variables for Scrollable ListView */

    public int count; //Number of items to produce
    /// Item prefab
    /// </summary>
    public GameObject item;

    //List containing all the items
	List<GameObject> items;
	/// <summary>
	/// Grid which contains the items
	/// </summary>
	public GridLayoutGroup grid;
	public ScrollRect scrollRect;
	// Use this for initialization
	Vector3 autoLocalScale;
	Transform trans;

	// Use this for initialization
	void Awake () {
		items = new List<GameObject>();
		autoLocalScale = new Vector3(1, 1, 1);

        RefreshList();
	}

	public void RefreshList()
    {
		GameObject localItem;
		/*
		//DESTROY all current childs of GRID component to avoid increasing childs at each run
		*/
		Transform t = grid.transform;
		foreach (Transform child in t) {
			if(child.GetSiblingIndex() > 4)
				GameObject.Destroy(child.gameObject);
		}

        for (int i = 0; i < count; i++)
        {
            localItem = Instantiate(item, Vector3.zero, Quaternion.identity) as GameObject;

            trans = localItem.transform;
            ///Setting parent for the item
            trans.SetParent(grid.transform, false);
            trans.SetAsFirstSibling();
            ///Important as instatiated item can have random scale and might not be visible
            trans.localScale = autoLocalScale;
            trans.localPosition = Vector3.zero;
            items.Add(localItem); 
        }
	}
}