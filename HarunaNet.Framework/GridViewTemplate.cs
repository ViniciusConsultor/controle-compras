using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HarunaNet.Framework
{
    // Create a template class to represent a dynamic template column.
    public class GridViewCheckBox : ITemplate
    {
        private DataControlRowType templateType;
        private string columnName;
        private string columnVisible;

        public GridViewCheckBox(DataControlRowType type, string colname)
        {
            templateType = type;
            columnName = colname;
            columnVisible = string.Empty;
        }

        public GridViewCheckBox(DataControlRowType type, string colname, string colvisible)
        {
            templateType = type;
            columnName = colname;
            columnVisible = colvisible;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            // Create the content for the different row types.
            switch (templateType)
            {
                case DataControlRowType.Header:
                    // Create the controls to put in the header
                    // section and set their properties.
                    Literal lc = new Literal();
                    lc.Text = "<b>" + columnName + "</b>";

                    // Add the controls to the Controls collection
                    // of the container.
                    container.Controls.Add(lc);
                    break;
                case DataControlRowType.DataRow:
                    // Create the controls to put in a data row
                    // section and set their properties.
                    CheckBox chkCampo = new CheckBox();
                    chkCampo.ID = "chk" + columnName;
                    //Image imgCampo = new Image();

                    // To support data binding, register the event-handling methods
                    // to perform the data binding. Each control needs its own event
                    // handler.
                    chkCampo.DataBinding += new EventHandler(this.chkCampo_DataBinding);
                    //imgCampo.DataBinding += new EventHandler(this.imgCampo_DataBinding);

                    // Add the controls to the Controls collection
                    // of the container.
                    container.Controls.Add(chkCampo);
                    //container.Controls.Add(imgCampo);
                    break;

                // Insert cases to create the content for the other 
                // row types, if desired.

                default:
                    // Insert code to handle unexpected values.
                    break;
            }
        }

        private void chkCampo_DataBinding(Object sender, EventArgs e)
        {
            // Get the CheckBox control to bind the value. The CheckBox control
            // is contained in the object that raised the DataBinding 
            // event (the sender parameter).
            CheckBox c = (CheckBox)sender;
            
            // Get the GridViewRow object that contains the CheckBox control. 
            GridViewRow row = (GridViewRow)c.NamingContainer;

            // Get the field value from the GridViewRow object and 
            // assign it to the Text property of the Label control.
            if (columnName != string.Empty)
            {
                c.Checked = Convert.ToBoolean(DataBinder.Eval(row.DataItem, columnName));
            }
            if (columnVisible != string.Empty)
            {
                c.Visible = Convert.ToBoolean(DataBinder.Eval(row.DataItem, columnVisible));
            }
        }

        private void imgCampo_DataBinding(Object sender, EventArgs e)
        {
            // Get the Image control to bind the value. The Image control
            // is contained in the object that raised the DataBinding 
            // event (the sender parameter).
            Image i = (Image)sender;

            // Get the GridViewRow object that contains the Image control.
            GridViewRow row = (GridViewRow)i.NamingContainer;

            // Get the field value from the GridViewRow object and 
            // assign it to the Text property of the Image control.
            i.ImageUrl = DataBinder.Eval(row.DataItem, columnName).ToString();
        }
    }
}
