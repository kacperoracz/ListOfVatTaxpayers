using System;

namespace ListOfVatTaxpayers.Module.Models
{
    class Entity
    {
        public string Name { get; set; }
        public string Nip { get; set; }
        public StatusVat StatusVat { get; set; }
        public string Regon { get; set; }
        public string Pesel { get; set; }
        public string KRS { get; set; }
        public string ResidenceAddress { get; set; }
        public string WorkingAddress { get; set; }
        public EntityPerson[] Representatives { get; set; }
        public EntityPerson[] AuthorizedClerks { get; set; }
        public EntityPerson[] Partners { get; set; }
        public DateTime? RegistrationLegalDate { get; set; }
        public DateTime? RegistrationDenialDate { get; set; }
        public string RegistrationDenialBasis { get; set; }
        public DateTime? RestorationDate { get; set; }
        public string RestorationBasis  { get; set; }
        public DateTime? RemovalDate { get; set; }
        public string RemovalBasis { get; set; }
        public string[] AccountNumbers { get; set; }
        public bool HasVirtualAccounts { get; set; }
    }

    public enum StatusVat
    {
        Czynny,
        Zwolniony,
        Niezarejestrowany
    }
}
