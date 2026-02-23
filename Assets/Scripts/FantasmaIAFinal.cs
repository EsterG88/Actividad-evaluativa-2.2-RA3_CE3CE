using UnityEngine;
using UnityEngine.AI;

public class FantasmaIAFinal : MonoBehaviour
{
	[Header("Patrulla")]
	[SerializeField] private Transform[] puntosPatrulla;
	private int indiceActual = 0;

	[Header("Jugador")]
	[SerializeField] private Transform jugador;

	[Header("Persecución")]
	[SerializeField] private float distanciaVision = 10f;
	[SerializeField] private float distanciaCaptura = 1.5f;
	[SerializeField] private float alturaOjos = 1.7f; 

	[Header("Game Manager")]
	[SerializeField] private GameManager gameManager;

	private NavMeshAgent agente;
	private bool persiguiendo = false;

	private void Start()
	{
		agente = GetComponent<NavMeshAgent>();
        
		if (puntosPatrulla.Length > 0)
			agente.SetDestination(puntosPatrulla[0].position);
	}

	private void Update()
	{
		if (jugador == null) return;

		DetectarJugador();

		if (persiguiendo)
			PerseguirJugador();
		else
			Patrullar();
	}

	private void DetectarJugador()
	{
		Vector3 origenRayo = transform.position + Vector3.up * alturaOjos; 
		Vector3 objetivoRayo = jugador.position + Vector3.up * 1.2f; 
		Vector3 direccion = objetivoRayo - origenRayo;

		if (direccion.magnitude <= distanciaVision)
		{
			RaycastHit hit;
			if (Physics.Raycast(origenRayo, direccion.normalized, out hit, distanciaVision))
			{
				Debug.Log(gameObject.name + " está viendo a: " + hit.collider.name);

				if (hit.collider.CompareTag("Player"))
				{
					persiguiendo = true;
					return;
				}
			}
		}
		// Asegúrate de que aquí diga 'persiguiendo' SIN LA G
		persiguiendo = false; 
	}

	private void Patrullar()
	{
		if (puntosPatrulla.Length == 0) return;

		// Si el fantasma llega a su destino, va al siguiente punto
		if (!agente.pathPending && agente.remainingDistance < 0.5f)
		{
			indiceActual = (indiceActual + 1) % puntosPatrulla.Length;
			agente.SetDestination(puntosPatrulla[indiceActual].position);
		}
	}

	private void PerseguirJugador()
	{
		agente.SetDestination(jugador.position);

		if (Vector3.Distance(transform.position, jugador.position) < distanciaCaptura)
		{
			gameManager.JugadorPillado();
		}
	}
}