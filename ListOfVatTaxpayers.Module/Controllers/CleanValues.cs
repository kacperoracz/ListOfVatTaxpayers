using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using ListOfVatTaxpayers.Module.BusinessObjects;

namespace ListOfVatTaxpayers.Module.Controllers
{
    public partial class CleanValues : ViewController
    {
        SimpleAction _action;
        public CleanValues()
        {
            TargetObjectType = typeof(ListViewEntry);

            _action = new SimpleAction(this, "Clean Values", PredefinedCategory.Edit);
            _action.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            _action.Execute += Action_CleanValues;
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

        void Action_CleanValues(object sender, SimpleActionExecuteEventArgs e)
        {

            var currentObj = e.CurrentObject as ListViewEntry;

            currentObj.SavedValues = "";

            if (this.ObjectSpace.IsModified)
                this.ObjectSpace.CommitChanges();
        }
    }
}
