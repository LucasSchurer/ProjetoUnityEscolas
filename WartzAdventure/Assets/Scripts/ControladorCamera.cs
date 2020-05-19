using UnityEngine;
using System.Collections;


public class ControladorCamera : MonoBehaviour
{
	public Transform target;
	public float smoothDampTime = 0.2f;
	[HideInInspector]
	public new Transform transform;
	public Vector3 cameraOffset;
	private Jogador jogador;
	private Vector3 _smoothDampVelocity;

	public Color corCima;
	public Color corBaixo;
	public bool estaCorCima = true;
	public float posicaoY;
	private Camera cam;

	void Awake()
	{
		transform = gameObject.transform;
		jogador = target.GetComponent<Jogador>();
		cam = GetComponent<Camera>();
	}
	
	
	void LateUpdate()
	{
		if (target != null)
		{
			updateCameraPosition();

			if (transform.position.y > posicaoY && !estaCorCima)
			{
				cam.backgroundColor = corCima;
				estaCorCima = true;
			}
			
			if (transform.position.y < posicaoY && estaCorCima)
			{
				cam.backgroundColor = corBaixo;
				estaCorCima = false;
			}
		}
	}

	void updateCameraPosition()
	{
		if( jogador == null )
		{
			transform.position = Vector3.SmoothDamp( transform.position, target.position - cameraOffset, ref _smoothDampVelocity, smoothDampTime );
			return;
		}
		
		if( jogador.estaCorrendo )
		{
			transform.position = Vector3.SmoothDamp( transform.position, target.position - cameraOffset, ref _smoothDampVelocity, smoothDampTime );
		}
		else
		{
			var leftOffset = cameraOffset;
			leftOffset.x *= -1;
			transform.position = Vector3.SmoothDamp( transform.position, target.position - leftOffset, ref _smoothDampVelocity, smoothDampTime );
		}
	}
}
