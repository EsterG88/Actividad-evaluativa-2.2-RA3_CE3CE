using UnityEngine;

public class Gargola : MonoBehaviour
{
	[Header("Jugador")]
	[SerializeField] private Transform jugador;

	[Header("Game Manager")]
	[SerializeField] private GameManager gameManager;

	[Header("Configuración")]
	[SerializeField] private float distanciaActivacion = 4f;
	[SerializeField] private float distanciaCaptura = 1.5f;
	[SerializeField] private bool soloSiSeMueve = false;

	private PlayerMovement movimientoJugador;

	private void Start()
	{
		if (jugador != null)
			movimientoJugador = jugador.GetComponent<PlayerMovement>();
	}

	private void Update()
	{
		if (jugador == null) return;

		float distancia = Vector3.Distance(transform.position, jugador.position);

		if (distancia < distanciaActivacion)
		{
			Vector3 dir = jugador.position - transform.position;
			dir.y = 0;
			transform.rotation = Quaternion.LookRotation(dir);

			if (distancia < distanciaCaptura)
			{
				if (!soloSiSeMueve || movimientoJugador.EstaCaminando())
				{
					gameManager.JugadorPillado();
				}
			}
		}
	}
}

