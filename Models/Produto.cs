
using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser positivo.")]
        public decimal Preco { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
        public int Quantidade { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
