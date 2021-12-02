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
    public class EntityPerson : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EntityPerson(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string companyName;
        public string CompanyName
        {
            get { return companyName; }
            set { SetPropertyValue(nameof(CompanyName), ref companyName, value); }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetPropertyValue(nameof(FirstName), ref firstName, value); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetPropertyValue(nameof(LastName), ref lastName, value); }
        }

        private string pesel;
        public string Pesel
        {
            get { return pesel; }
            set { SetPropertyValue(nameof(Pesel), ref pesel, value); }
        }

        private string nip;
        public string Nip
        {
            get { return nip; }
            set { SetPropertyValue(nameof(Nip), ref nip, value); }
        }

        private Entity entityRepresentatives;
        [Association("EntityPerson-Representatives")]
        public Entity EntityRepresentatives
        {
            get { return entityRepresentatives; }
            set { SetPropertyValue(nameof(EntityRepresentatives), ref entityRepresentatives, value); }
        }

        private Entity entityPartners;
        [Association("EntityPerson-Partners")]
        public Entity EntityPartners
        {
            get { return entityPartners; }
            set { SetPropertyValue(nameof(EntityPartners), ref entityPartners, value); }
        }

        private Entity entityAuthorizedClerks;
        [Association("EntityPerson-AuthorizedClerks")]
        public Entity EntityAuthorizedClerks
        {
            get { return entityAuthorizedClerks; }
            set { SetPropertyValue(nameof(Entity), ref entityAuthorizedClerks, value); }
        }
    }
}