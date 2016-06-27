using UnityEngine;
using System.Collections;

public class Slider : MonoBehaviour {

	public Texture[] images;
	public Texture staticImage;
	public float sliderTime;
	private float timer = 0;
	private bool time=false;
	private bool slide = false;
	public float sliderSpeed;
	private GameObject blankImage;
	private Vector3 sliderPos;
	public GameObject spawnedObject;
	public GameObject oldObject;
	public GameObject oldestObject;
	private ItemVariables blankVar;
	public ItemVariables parentVar;
	private Vector3 scaleOffset;
	private int imageCount = 0;
	private Vector2 objectScale;
	private Vector2 imageScale;
	private float imageRes;
	private float objectRes;
	private Scroller scroller;

	void Start(){
	//	parentVar = GetComponent<ItemVariables> ();
		sliderPos = transform.position + new Vector3 (0, 0, -1);
	//	SpawnStaticImage ();
	//	SpawnImage ();
	}

	void Update(){
		if (!time) {
			timer++;
			if (timer >= sliderTime) {
				slide = true;
				if (oldObject != null) {
					oldObject.transform.position += new Vector3 (0, 0, 0.5f);
				}
				time = true;
				timer = 0;
				oldObject = spawnedObject;
			}
		}
		if(slide){
			spawnedObject.transform.position = Vector3.Lerp(spawnedObject.transform.position,sliderPos,sliderSpeed);
			scaleOffset = new Vector3(5.625f - spawnedObject.transform.localScale.x/2,-10 + spawnedObject.transform.localScale.y/2);
			spawnedObject.GetComponent<ItemVariables>().imageTapple = true;
			spawnedObject.GetComponent<ItemVariables>().button = true;
			spawnedObject.GetComponent<ItemVariables>().buttonLeft = (spawnedObject.transform.position.x-scaleOffset.x) * 0.088888888888888888889f;
			if(oldestObject!=null){
				oldestObject.GetComponent<ItemVariables>().buttonLeft = (spawnedObject.transform.position.x- spawnedObject.transform.localScale.x - scaleOffset.x) * 0.088888888888888888889f;
			}
			if(spawnedObject.transform.position == sliderPos){
				if(oldestObject!=null){
					//scroller.attached.
					Destroy(oldestObject);
				}
				oldestObject = oldObject;
				SpawnImage();
				time = false;
				slide = false;
			}
		}
		if (scroller != null && scroller.on) {
			if(spawnedObject != null){
				scaleOffset = new Vector3(5.625f - spawnedObject.transform.localScale.x/2,-10 + spawnedObject.transform.localScale.y/2);
				spawnedObject.GetComponent<ItemVariables>().buttonTop = ((spawnedObject.transform.position.y + scaleOffset.y)+ scroller.movement.y) * 0.05f;
			}
			if(oldObject != null){
				scaleOffset = new Vector3(5.625f - oldObject.transform.localScale.x/2,-10 + oldObject.transform.localScale.y/2);
				oldObject.GetComponent<ItemVariables>().buttonTop = ((oldObject.transform.position.y + scaleOffset.y) + scroller.movement.y) * 0.05f;
			}
			if(oldestObject != null){
				scaleOffset = new Vector3(5.625f - oldestObject.transform.localScale.x/2,-10 + oldestObject.transform.localScale.y/2);
				oldestObject.GetComponent<ItemVariables>().buttonTop = ((oldestObject.transform.position.y + scaleOffset.y) + scroller.movement.y) * 0.05f;
			}
		}
	}

	public void SpawnStaticImage(){
		blankImage = Resources.Load ("BlankElement") as GameObject;
		blankImage.transform.name = "Slider StaticImage";
		blankVar = blankImage.GetComponent<ItemVariables> ();
		blankVar.position = new Vector3 (parentVar.position.x, parentVar.position.y, parentVar.position.z - 2);
		scaleOffset = new Vector3(5.625f - parentVar.scale.x/2,-10 + parentVar.scale.y/2);
		blankVar.scale = parentVar.scale;
		imageCount = 0;
		imageScale = new Vector2(images [imageCount].width , images [imageCount].height);
		imageRes = imageScale.x / imageScale.y;
		blankVar.transform.localScale = new Vector3(blankVar.scale.x,blankVar.scale.y,1);
		objectScale = new Vector2(blankVar.gameObject.transform.localScale.x,blankVar.gameObject.transform.localScale.y);
		objectRes = objectScale.x / objectScale.y;
		if (imageRes > objectRes) {
			//image is smaller
			blankVar.imageTiling = new Vector2((1/imageRes),1);
			blankVar.imageOffset = new Vector2((1/imageRes)/4,0);
		} else {
			//image is higher
			blankVar.imageTiling = new Vector2(1,imageRes);
			blankVar.imageOffset = new Vector2(0,imageRes/4);
		}
		blankVar.imageTiling = new Vector2(1,1);
		blankVar.imageOffset = new Vector2(0,0);
		blankVar.image = true;
		blankVar.imageMaterial = staticImage;
		blankVar.imageOverlaying = true;
		blankVar.imageTapple = false;
		blankVar.button = false;
		//blankVar.buttonVisable = false;
		imageCount++;
		Instantiate (blankImage, blankVar.position - scaleOffset, transform.rotation);
		//scroller = GameObject.FindGameObjectWithTag ("Scroller").GetComponent<Scroller> ();
	//	scroller.attached.Add (spawnedObject);
	}

	public void SpawnImage(){
		blankImage = Resources.Load ("BlankElement") as GameObject;
		blankImage.transform.name = "Slider " + images [imageCount].name;
		blankVar = blankImage.GetComponent<ItemVariables> ();
		blankVar.position = new Vector3 (parentVar.position.x + parentVar.scale.x, parentVar.position.y, parentVar.position.z - 1);
		blankVar.scale = parentVar.scale;
		scaleOffset = new Vector3(5.625f - blankVar.scale.x/2,-10 + blankVar.scale.y/2);
		imageScale = new Vector2(images [imageCount].width , images [imageCount].height);
		imageRes = imageScale.x / imageScale.y;
		blankVar.transform.localScale = new Vector3(blankVar.scale.x,blankVar.scale.y,1);
		objectScale = new Vector2(blankVar.gameObject.transform.localScale.x,blankVar.gameObject.transform.localScale.y);
		objectRes = objectScale.x / objectScale.y;
		if (imageRes > objectRes) {
			//image is smaller
			blankVar.imageTiling = new Vector2((1/imageRes),1);
			blankVar.imageOffset = new Vector2((1/imageRes)/4,0);
		} else {
			//image is higher
			blankVar.imageTiling = new Vector2(1,imageRes);
			blankVar.imageOffset = new Vector2(0,imageRes/4);
		}
		blankVar.image = true;
		blankVar.imageMaterial = images [imageCount];
		blankVar.imageOverlaying = true;
		blankVar.imageTapple = false;
		blankVar.button = false;
		blankVar.buttonVisable = false;
		blankVar.slider = false;
		blankVar.buttonLeft = parentVar.position.x + parentVar.scale.x * 0.088888888888888888889f;
		blankVar.buttonTop = parentVar.position.y * 0.05f;
		scaleOffset = new Vector3(5.625f - parentVar.transform.localScale.x/2,-10 + parentVar.transform.localScale.y/2);
		blankVar.buttonTopStart = ((parentVar.transform.position.y+ scaleOffset.y)) * 0.05f;
		blankVar.buttonWidth = parentVar.scale.x * 0.088888888888888888889f;
		blankVar.buttonHeight = parentVar.scale.y * 0.05f;
		imageCount++;
		imageCount%=images.GetLength(0);
		spawnedObject = Instantiate (blankImage, blankVar.position - scaleOffset, transform.rotation) as GameObject;
		if (GameObject.FindGameObjectWithTag ("Scroller") != null) {
			scroller = GameObject.FindGameObjectWithTag ("Scroller").GetComponent<Scroller>();
			scroller.GetComponent<Scroller>().attached.Add (spawnedObject);
		}
	}
}
