using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Parallaxing : MonoBehaviour {

	public List<ParallaxLayer> parallaxLayers = new List<ParallaxLayer> ();

	public Transform Pointer; 
	private Vector3 previousPointerPosition; 

	public float PointerXMax;
	public float PointerXMin;

	public float PointerYMax;
	public float PointerYMin;	



	// Use this for initialization
	void Start () {
		previousPointerPosition = Pointer.position;
	}
	
	// Update is called once per frame
	void Update () {
		StringBuilder log = new StringBuilder ();
		log.AppendLine ("Update");
		log.AppendLine ("PointerX = " + Pointer.position.x.ToString());
		log.AppendLine ("PreviousPointerX = " + previousPointerPosition.x.ToString());



		float currentPointerX = Pointer.position.x;

		bool isPointerOverLimitX = (currentPointerX > PointerXMax) || (currentPointerX < PointerXMin);

		if (isPointerOverLimitX)
						return;



		var deltaX = currentPointerX - previousPointerPosition.x;
		log.AppendLine ("deltaX = " + deltaX);


		foreach(var layer in parallaxLayers)
		{
			var layerTargetX = layer.transform.position.x + (layer.Speed * deltaX);
			log.AppendLine ("layerTargetX = " + layerTargetX);

			Vector3 layerTargetPosition = new Vector3 (layerTargetX, layer.transform.position.y, layer.transform.position.z);

			//layer.transform.position = Vector3.Lerp(layer.transform.position, layerTargetPosition, Time.deltaTime);
			layer.transform.position = layerTargetPosition;
		}

		previousPointerPosition = Pointer.position;

		Debug.Log (log.ToString());
	}
}
