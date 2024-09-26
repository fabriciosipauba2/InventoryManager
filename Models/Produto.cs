
using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Categoria { get; set; }

        [Required]
        [StringLength(100)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(100)]
        public string Marca { get; set; }

        [Required]
        [StringLength(100)]
        public string Modelo { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
        public int Quantidade { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser positivo.")]
        public decimal Preco { get; set; }
    }
}
