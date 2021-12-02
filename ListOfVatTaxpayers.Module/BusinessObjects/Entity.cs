using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ListOfVatTaxpayers.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Entity : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Entity(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }

        private string nip;

        public string Nip
        {
            get { return nip; }
            set { SetPropertyValue(nameof(Nip), ref nip, value); }
        }

        private StatusVat statusVat;

        public StatusVat StatusVat
        {
            get { return statusVat; }
            set { SetPropertyValue(nameof(StatusVat), ref statusVat, value); }
        }

        private string regon;

        public string Regon
        {
            get { return regon; }
            set { SetPropertyValue(nameof(Regon), ref regon, value); }
        }

        private string pesel;

        public string Pesel
        {
            get { return pesel; }
            set { SetPropertyValue(nameof(Pesel), ref pesel, value); }
        }

        private string krs;

        public string Krs
        {
            get { return krs; }
            set { SetPropertyValue(nameof(Krs), ref krs, value); }
        }

        private string residenceAddress;

        public string ResidenceAddress
        {
            get { return residenceAddress; }
            set { SetPropertyValue(nameof(ResidenceAddress), ref residenceAddress, value); }
        }

        private string workingAddress;

        public string WorkingAddress
        {
            get { return workingAddress; }
            set { SetPropertyValue(nameof(WorkingAddress), ref workingAddress, value); }
        }

        [Association("EntityPerson-Representatives")]
        public XPCollection<EntityPerson> Representatives
        {
            get { return GetCollection<EntityPerson>(nameof(Representatives)); }
        }

        [Association("EntityPerson-Partners")]
        public XPCollection<EntityPerson> Partners
        {
            get { return GetCollection<EntityPerson>(nameof(Partners)); }
        }

        [Association("EntityPerson-AuthorizedClerks")]
        public XPCollection<EntityPerson> AuthorizedClerks
        {
            get { return GetCollection<EntityPerson>(nameof(AuthorizedClerks)); }
        }

        private DateTime? registrationLegalDate;

        public DateTime? RegistrationLegalDate
        {
            get { return registrationLegalDate; }
            set { SetPropertyValue(nameof(RegistrationLegalDate), ref registrationLegalDate, value); }
        }

        private DateTime? registrationDenialDate;

        public DateTime? RegistrationDenialDate
        {
            get { return registrationDenialDate; }
            set { SetPropertyValue(nameof(RegistrationDenialDate), ref registrationDenialDate, value); }
        }

        private string registrationDenialBasis;

        public string RegistrationDenialBasis
        {
            get { return registrationDenialBasis; }
            set { SetPropertyValue(nameof(RegistrationDenialBasis), ref registrationDenialBasis, value); }
        }

        private DateTime? restorationDate;

        public DateTime? RestorationDate
        {
            get { return restorationDate; }
            set { SetPropertyValue(nameof(RestorationDate), ref restorationDate, value); }
        }

        private string restorationBasis;

        public string RestorationBasis
        {
            get { return restorationBasis; }
            set { SetPropertyValue(nameof(RestorationBasis), ref restorationBasis, value); }
        }

        private DateTime? removalDate;

        public DateTime? RemovalDate
        {
            get { return removalDate; }
            set { SetPropertyValue(nameof(RemovalDate), ref removalDate, value); }
        }

        private string removalBasis;

        public string RemovalBasis
        {
            get { return removalBasis; }
            set { SetPropertyValue(nameof(RemovalBasis), ref removalBasis, value); }
        }

        [Association("Entity-Values")]
        public XPCollection<Value> AccountNumbers
        {
            get { return GetCollection<Value>(nameof(AccountNumbers)); }
        }

        private bool hasVirtualAccounts;

        public bool HasVirtualAccounts
        {
            get { return hasVirtualAccounts; }
            set { SetPropertyValue(nameof(HasVirtualAccounts), ref hasVirtualAccounts, value); }
        }

        private string field;

        public string Field
        {
            get { return field; }
            set { SetPropertyValue(nameof(Field), ref field, value); }
        }

        private string data;

        public string Data
        {
            get { return data; }
            set { SetPropertyValue(nameof(Data), ref data, value); }
        }

        private ListViewTest listViewTest;
        [Association("EntityListView-Entities")]
        public ListViewTest ListViewTest
        {
            get { return listViewTest; }
            set { SetPropertyValue(nameof(ListViewTest), ref listViewTest, value); }
        }

        private Entry entry;
        [Association("Entry-Entities")]
        public Entry Entry
        {
            get { return entry; }
            set { SetPropertyValue(nameof(Entry), ref entry, value); }
        }

        private EntityView entityView;
        [Association("EntityView-Entities")]
        public EntityView EntityView
        {
            get { return entityView; }
            set { SetPropertyValue(nameof(EntityView), ref entityView, value); }
        }
    }

    public enum StatusVat
    {
        Czynny,
        Zwolniony,
        Niezarejestrowany
    }
}
