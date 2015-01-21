using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("Logins")]

public class Logon : MonoBehaviour {
	
	//[XmlAttribute("Logins")]
	[XmlArray("Adresses")]
	[XmlArrayItem("Adress")]
	//public List<Adress> Adresses = new List<Logon>();
	private static XmlSerializer serializer;
	private string path;
	private User testLogIn;
	
	void Start(){
		Debug.Log ("hey");
		serializer = new XmlSerializer (typeof(User));
		Debug.Log ("yo");
		Save (Path.Combine (Application.persistentDataPath, "User"));
		testLogIn = Load(Path.Combine(Application.dataPath, "User"));
		Debug.Log (testLogIn.userName);
	}
	
	public void Save(string path){
		using (var stream = new FileStream(path, FileMode.Create)) {
			serializer.Serialize(stream, this);
		}
	}
	public static User Load (string path) {
		using (var stream = new FileStream (path, FileMode.Open)) {
			return serializer.Deserialize(stream) as User;
		}
	}
}
