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
    public class EntityCheck : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EntityCheck(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string accountAssigned;
        public string AccountAssigned
        {
            get { return accountAssigned; }
            set { SetPropertyValue(nameof(AccountAssigned), ref accountAssigned, value); }
        }

        private string requestDateTime;
        public string RequestDateTime
        {
            get { return requestDateTime; }
            set { SetPropertyValue(nameof(RequestDateTime), ref requestDateTime, value); }
        }

        private string requestId;
        public string RequestId
        {
            get { return requestId; }
            set { SetPropertyValue(nameof(RequestId), ref requestId, value); }
        }

        private string field;
        public string Field
        {
            get { return field; }
            set { SetPropertyValue(nameof(Field), ref field, value); }
        }

        private string accountNumber;
        public string AccountNumber
        {
            get { return accountNumber; }
            set { SetPropertyValue(nameof(AccountNumber), ref accountNumber, value); }
        }

        private string date;
        public string Date
        {
            get { return date; }
            set { SetPropertyValue(nameof(Date), ref date, value); }
        }
    }
}