using Unity.Cinemachine;
using UnityEngine;

public class ActivateCamera : MonoBehaviour
{
    // ARRAY DE CÁMARAS
    [SerializeField] 
    private CinemachineCamera[] camaras;

    // EVENTO ONTRIGGER -> LLAMA AL MÉTODO
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Entrada":
                ActivarCamaras(0);
                break;

            case "Hall":
                ActivarCamaras(1);
                break;

            case "Pasillo1":
                ActivarCamaras(2);
                break;

             case "Mesa":
                ActivarCamaras(3);
                break;  

            case "Dormitorio1":
                ActivarCamaras(4);
                break;  

            case "Dormitorio2":
                ActivarCamaras(5);
                break;  

            case "Pasillo2":
                ActivarCamaras(6);
                break;  

            case "Pasillo3":
                ActivarCamaras(7);
                break;  

            case "Victoria1":
                ActivarCamaras(8);
                break;  

            case "Pasillo4":
                ActivarCamaras(9);
                break;  

            case "Pasillo5":
                ActivarCamaras(10);
                break;  

            case "Pasillo6":
                ActivarCamaras(11);
                break;  

            case "Pasillo7":
                ActivarCamaras(12);
                break;  

            case "Pasillo8":
                ActivarCamaras(13);
                break;  

            case "Dormitorio3":
                ActivarCamaras(14);
                break;  

            case "Dormitorio4":
                ActivarCamaras(15);
                break;  

            case "Pasillo9":
                ActivarCamaras(16);
                break;  
            
            case "Victoria2":
                ActivarCamaras(17);
                break; 
            
            case "Ducha":
                ActivarCamaras(18);
                break; 

        }
    }

    // MÉTODO ACTIVAR CÁMARA:
    // Quita prioridad a todas y da prioridad a una
    private void ActivarCamaras(int index)
    {
        for (int i = 0; i < camaras.Length; i++)
        {
            if (i != index)
            {
                camaras[i].Priority = 0;
            }
        }

        camaras[index].Priority = 10;
    }
}
