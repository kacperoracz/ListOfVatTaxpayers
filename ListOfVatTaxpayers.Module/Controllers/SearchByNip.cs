using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using ListOfVatTaxpayers.Module.Api;
using ListOfVatTaxpayers.Module.BusinessObjects;
using ListOfVatTaxpayers.Module.Helpers;
using System;
using System.Linq;

namespace ListOfVatTaxpayers.Module.Controllers
{
    public partial class SearchByNip : ViewController
    {
        SimpleAction _action;
        ApiConnection _apiConnection = new ApiConnection();

        public SearchByNip()
        {
            TargetObjectType = typeof(EntityView);

            _action = new SimpleAction(this, "Search By Nip", PredefinedCategory.Edit);
            _action.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            _action.Execute += Action_SearchByNip;
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

        async void Action_SearchByNip(object sender, SimpleActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;

            var currentObj = e.CurrentObject as EntityView;

            Tuple<string, bool> result = await _apiConnection.InvokeEndpointAsync($"/api/search/nip/{currentObj.Field}?date={currentObj.Data}");

            if (result.Item2)
            {
                currentSession.Delete(currentObj.Entities);
                currentObj.Entities.Add(new Entity(currentSession));
                ObjectsConverter.EntityConverter(
                    Newtonsoft.Json.JsonConvert.DeserializeObject<Models.EntityResponse>(result.Item1).Result.Subject, currentObj.Entities.FirstOrDefault(), currentSession
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
