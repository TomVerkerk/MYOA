using UnityEngine;
using System.Collections;

public class Database : MonoBehaviour {

	public GameObject databaseObject;
	public Pages matchingPages;
	public string AppTitle;
	//public Pages allPages;
	public int selectedPage = -1;
	public string OS;
	public enum language{
		English,Nederlands};
	public language taal;

	void Start(){
		language value = language.Nederlands;
	}
}
