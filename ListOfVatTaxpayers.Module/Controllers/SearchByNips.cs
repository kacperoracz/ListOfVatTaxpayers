using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using ListOfVatTaxpayers.Module.Api;
using ListOfVatTaxpayers.Module.BusinessObjects;
using ListOfVatTaxpayers.Module.Helpers;
using System;

namespace ListOfVatTaxpayers.Module.Controllers
{
    public partial class SearchByNips : ViewController
    {
        SimpleAction _action;
        ApiConnection _apiConnection = new ApiConnection();
        public SearchByNips()
        {
            TargetObjectType = typeof(ListViewEntry);

            _action = new SimpleAction(this, "Search By Nips", PredefinedCategory.Edit);
            _action.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            _action.Execute += Action_SearchByNips;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }

        async void Action_SearchByNips(object sender, SimpleActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;

            var currentObj = e.CurrentObject as ListViewEntry;

            Tuple<string, bool> result = await _apiConnection.InvokeEndpointAsync($"/api/search/nips/{currentObj.SavedValues}?date={currentObj.Data}");

            if (result.Item2)
            {
                ObjectsConverter.EntryTableConverter(
                    Newtonsoft.Json.JsonConvert.DeserializeObject<Models.EntryListResponse>(result.Item1).Result.Entries, currentObj.Entries, currentSession
                    );
            }
            else
            {
                Application.ShowViewStrategy.ShowMessage(result.Item1, InformationType.Error, 2000, InformationPosition.Bottom);
            }

            if (this.ObjectSpace.IsModified)
                this.ObjectSpace.CommitChanges();
        }
    }
}
