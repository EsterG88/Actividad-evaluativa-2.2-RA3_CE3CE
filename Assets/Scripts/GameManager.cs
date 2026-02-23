using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] private CanvasGroup grupoDerrota; // Es mejor usar CanvasGroup para el fade
	[SerializeField] private CanvasGroup grupoVictoria;

	[Header("Configuración")]
	[SerializeField] private float duracionFade = 1f;
    
	private float temporizador;
	private bool perdiendo = false;
	private bool ganando = false;
	public bool tieneLlave = false;

	private void Update()
	{
		if (perdiendo) EjecutarFinal(grupoDerrota);
		if (ganando) EjecutarFinal(grupoVictoria);
	}

	public void JugadorPillado()
	{
		if (!perdiendo && !ganando) perdiendo = true;
	}

	public void JugadorGana()
	{
		if (!perdiendo && !ganando) ganando = true;
	}

	private void EjecutarFinal(CanvasGroup grupoUI)
	{
		temporizador += Time.deltaTime;
		grupoUI.alpha = Mathf.Clamp01(temporizador / duracionFade);

		if (temporizador > duracionFade + 1f)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && tieneLlave)
			JugadorGana();
	}
}