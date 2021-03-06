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
    public class ListViewEntry : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ListViewEntry(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
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

        private string savedValues;
        public string SavedValues
        {
            get { return savedValues; }
            set { SetPropertyValue(nameof(SavedValues), ref savedValues, value); }
        }

        [Association("EntryListView-Entries")]
        public XPCollection<Entry> Entries
        {
            get { return GetCollection<Entry>(nameof(Entries)); }
        }
    }
}