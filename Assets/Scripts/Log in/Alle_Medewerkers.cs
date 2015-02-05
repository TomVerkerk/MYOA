using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class Alle_Medewerkers : MonoBehaviour {
	
	public XmlFile Xml;

	void Start () {
		XmlSerializer xmls = new XmlSerializer(typeof(XmlFile));
		StreamWriter writer = new StreamWriter(Xml.fileName);
		xmls.Serialize(writer,Xml);
		writer.Close();
	}
}
