using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasApp.Domain.Validations;

namespace VendasApp.Domain.Entities
{
    public sealed class Person
    {
        /// <summary>
        /// set privados para não permitir que esses atributos sejam acessados fora da classe
        /// </summary>
        public int Id{ get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public  string Phone { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }    

        /// <summary>
        /// Construtor que vai ser responsavel por preencher as variaveis
        /// </summary>
        public Person(string name, string document, string phone)
        {
            Validation(name, document, phone);
        }

        /// <summary>
        /// Construtor para edição
        /// </summary>
        public Person(int id, string name, string document, string phone)
        {
            DomainValidationException.When(id < 0, "Id deve ser maior que zero");
            Id = id;
            Validation(name, document, phone);
        }

        private void Validation(string name, string document, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(document), "Documento deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "Celular deve ser informado");

            Name = name;
            Document = document;
            Phone = phone;

        }
    }
}
