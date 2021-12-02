using System;
using DevExpress.ExpressApp.Xpo;

namespace ListOfVatTaxpayers.Blazor.Server.Services {
    public class XpoDataStoreProviderAccessor {
        public IXpoDataStoreProvider DataStoreProvider { get; set; }
    }
}
