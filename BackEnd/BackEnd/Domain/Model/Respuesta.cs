using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Model
{
    public class Respuesta
    {
        public int? Id { get; set; }
        [Required]
        [Column(TypeName ="varchar(150)")]
        public string Descripcion { get; set; }
        [Required]
        public bool EsCorrecta { get; set; }
        public int? PreguntaId { get; set; }
        public Pregunta? Pregunta { get; set; }
    }
}
