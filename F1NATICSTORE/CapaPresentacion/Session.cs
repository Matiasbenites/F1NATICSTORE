using CapaEntidad;

namespace CapaPresentacion
{
 // Clase simple para mantener el usuario logueado accesible desde otros formularios
 public static class Session
 {
 public static Usuario CurrentUser { get; set; }
 }
}
