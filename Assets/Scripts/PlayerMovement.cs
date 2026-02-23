using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movimiento")]
	[SerializeField] private float velocidadMovimiento = 2f;
	[SerializeField] private float velocidadGiro = 20f;
    
	private Animator animator;
	private Rigidbody rb;
	private AudioSource audioSource;

	private Vector3 direccionMovimiento;
	private Quaternion rotacionObjetivo = Quaternion.identity;
	private bool caminando = false;

	private void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}

	private void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		direccionMovimiento = new Vector3(horizontal, 0f, vertical).normalized;
		caminando = direccionMovimiento.sqrMagnitude > 0.01f;

		animator.SetBool("IsWalking", caminando);

		// Gestión de Audio
		if (caminando)
		{
			if (!audioSource.isPlaying) audioSource.Play();
		}
		else
		{
			audioSource.Stop();
		}

		// Cálculo de rotación
		if (caminando)
		{
			Vector3 direccionSuavizada = Vector3.RotateTowards(
				transform.forward,
				direccionMovimiento,
				velocidadGiro * Time.deltaTime,
				0f
			);
			rotacionObjetivo = Quaternion.LookRotation(direccionSuavizada);
		}
	}

	private void OnAnimatorMove()
	{
		// Aplicamos el movimiento físico
		rb.MovePosition(rb.position + direccionMovimiento * velocidadMovimiento * Time.deltaTime);
		rb.MoveRotation(rotacionObjetivo);
	}

	public bool EstaCaminando() => caminando;
}