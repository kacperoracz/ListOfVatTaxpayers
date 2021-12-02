using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using ListOfVatTaxpayers.Module.BusinessObjects;

namespace ListOfVatTaxpayers.Module.Controllers
{
    public partial class AddFieldToValues : ViewController
    {
        SimpleAction _action;
        public AddFieldToValues()
        {
            TargetObjectType = typeof(ListViewEntry);

            _action = new SimpleAction(this, "Add Field To Values", PredefinedCategory.Edit);
            _action.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            _action.Execute += Action_AddFieldToValues;
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

        void Action_AddFieldToValues(object sender, SimpleActionExecuteEventArgs e)
        {

            var currentObj = e.CurrentObject as ListViewEntry;

            if(currentObj.SavedValues == "")
            {
                currentObj.SavedValues = currentObj.Field;
            }
            else
            {
                currentObj.SavedValues = currentObj.SavedValues + "," + currentObj.Field;
            }
            

            if (this.ObjectSpace.IsModified)
                this.ObjectSpace.CommitChanges();
        }
    }
}
