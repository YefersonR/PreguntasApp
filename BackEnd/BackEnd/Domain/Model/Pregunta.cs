using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Model
{
    public class Pregunta
    {
        public int? Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Descripcion { get; set; }
        [Required]
        public List<Respuesta> Respuestas { get; set; }
        public int? CuestionarioId { get; set; }
        public Cuestionario? Cuestionario{ get; set; }
    }
}
