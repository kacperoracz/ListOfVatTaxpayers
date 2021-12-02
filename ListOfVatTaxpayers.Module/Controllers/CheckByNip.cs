using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using ListOfVatTaxpayers.Module.Api;
using ListOfVatTaxpayers.Module.BusinessObjects;
using ListOfVatTaxpayers.Module.Helpers;
using System;

namespace ListOfVatTaxpayers.Module.Controllers
{
    public partial class CheckByNip : ViewController
    {
        SimpleAction _action;
        ApiConnection _apiConnection = new ApiConnection();

        public CheckByNip()
        {
            TargetObjectType = typeof(EntityCheck);

            _action = new SimpleAction(this, "Check By Nip", PredefinedCategory.Edit);
            _action.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            _action.Execute += Action_CheckByNip;
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

        async void Action_CheckByNip(object sender, SimpleActionExecuteEventArgs e)
        {
            var currentObj = e.CurrentObject as EntityCheck;

            Tuple<string, bool> result = await _apiConnection.InvokeEndpointAsync($"/api/check/nip/{currentObj.Field}/bank-account/{currentObj.AccountNumber}?date={currentObj.Date}");

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
