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
    public partial class SearchByAccountNumer : ViewController
    {
        SimpleAction _action;
        ApiConnection _apiConnection = new ApiConnection();

        public SearchByAccountNumer()
        {
            TargetObjectType = typeof(ListViewTest);

            _action = new SimpleAction(this, "Search By Account Numer", PredefinedCategory.Edit);
            _action.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            _action.Execute += Action_SearchByAccountNumer;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        async void Action_SearchByAccountNumer(object sender, SimpleActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;

            var currentObj = e.CurrentObject as ListViewTest;

            Tuple<string, bool> result = await _apiConnection.InvokeEndpointAsync($"/api/search/bank-account/{currentObj.Field}?date={currentObj.Data}");

            if (result.Item2)
            {
                //theSession.Delete(colDelete); 
                currentSession.Delete(currentObj.Entities);
                ObjectsConverter.EntityTableConverter(
                    Newtonsoft.Json.JsonConvert.DeserializeObject<Models.EntityListResponse>(result.Item1).Result.Subjects, currentObj.Entities, currentSession
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
