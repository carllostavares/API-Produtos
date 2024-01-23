using System.ComponentModel.DataAnnotations;

namespace ApiProduto.Model
{
    public class Produto
    {
        [Key]
        [Required(ErrorMessage = "O campo Id é obrigatório!")]
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo Nome é obrigatório!")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Preco é obrigatório!")]
        [Range(1,int.MaxValue,ErrorMessage ="O preço deve ser maior que zero!")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é obrigatório!")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa!")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório!")]
        [StringLength (300)]
        public string Descricao { get; set; }
    }
}
