﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using VendasApp.Domain.Validations;

namespace VendasApp.Domain.Entities
{
    public  sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        /// <summary>
        /// Construtor que vai ser responsavel por preencher as variaveis
        /// </summary>
        public Product(string name, string codErp, decimal price)
        {
            Validation(name, codErp, price);
        }

        /// <summary>
        /// Construtor para editar um produto
        /// </summary>
        public Product(int id, string name, string codErp, decimal price)
        {
            DomainValidationException.When(id < 0, "Id deve ser maior que zero");
            Id = id;
            Validation(name, codErp, price);
        }

        private void Validation(string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "Codigo Erp deve ser informado");
            DomainValidationException.When(price < 0 , "Preço deve ser informado");

            Name = name;
            CodErp = codErp;
            Price = price;
        }
    }
}
