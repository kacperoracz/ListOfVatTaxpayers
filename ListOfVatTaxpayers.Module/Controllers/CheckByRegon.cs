using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using ListOfVatTaxpayers.Module.Api;
using ListOfVatTaxpayers.Module.BusinessObjects;
using ListOfVatTaxpayers.Module.Helpers;
using System;
namespace ListOfVatTaxpayers.Module.Controllers
{
    public partial class CheckByRegon : ViewController
    {
        SimpleAction _action;
        ApiConnection _apiConnection = new ApiConnection();
        public CheckByRegon()
        {
            TargetObjectType = typeof(EntityCheck);

            _action = new SimpleAction(this, "Check By REGON", PredefinedCategory.Edit);
            _action.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            _action.Execute += Action_CheckByRegon;
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

        async void Action_CheckByRegon(object sender, SimpleActionExecuteEventArgs e)
        {
            var currentObj = e.CurrentObject as EntityCheck;

            Tuple<string, bool> result = await _apiConnection.InvokeEndpointAsync($"/api/check/regon/{currentObj.Field}/bank-account/{currentObj.AccountNumber}?date={currentObj.Date}");

            if (result.Item2)
            {
                ObjectsConverter.EntityCheckConverter(
                    Newtonsoft.Json.JsonConvert.DeserializeObject<Models.EntityCheckResponse>(result.Item1).Result, currentObj
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
