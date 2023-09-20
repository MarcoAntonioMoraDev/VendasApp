using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VendasApp.Domain.Validations;

namespace VendasApp.Domain.Entities
{
    public sealed class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Product Product { get; set; }

        public Purchase(int productId, int personId, DateTime? date)
        {
            Validation(productId, personId, date);
        }

        /// <summary>
        /// Construtor para edição
        /// </summary>
        public Purchase(int id, int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(id < 0, "Id deve ser maior que zero");
            Id = id;
            Validation(productId, personId, date);
        }

        private void Validation(int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(productId < 0, "Id do Produto deve ser informado");
            DomainValidationException.When(personId < 0, "Id  Pessoa deve ser informado");
            DomainValidationException.When(!date.HasValue, "data da compra deve ser informada");

            PersonId = personId;
            ProductId = productId;
            Date = date.Value;

        }
    }
}
