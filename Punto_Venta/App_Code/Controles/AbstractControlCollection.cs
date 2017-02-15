using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ResizeableForm
{
    /// <summary>
    /// Represents a collection of abstract controls
    /// </summary>
    public class AbstractControlCollection : List<AbstractControl>
    {
        /// <summary>
        /// Form associated with the control collection
        /// </summary>
        ResizableForm _originalForm;

        /// <summary>
        /// Default constructor - adds controls to the collection based on the controls on the form
        /// </summary>
        /// <param name="originalForm"></param>
        public AbstractControlCollection(ResizableForm originalForm)
        {
            _originalForm = originalForm;
            addControls(originalForm);
        }

        /// <summary>
        /// Method to add all controls and children controls to the collection
        /// </summary>
        /// <param name="baseControl">Control to add child controls from</param>
        private void addControls(Control baseControl)
        {
            foreach (Control c in baseControl.Controls)
            {
                AbstractControl abstractControl = new AbstractControl(c, _originalForm);
                if (!this.Contains(abstractControl, true))
                    this.Add(abstractControl);
                addControls(c);
            }
        }

        /// <summary>
        /// Quick way to resize all the controls on the form at the same time
        /// </summary>
        public void Resize()
        {
            foreach (AbstractControl c in this)
            {
                c.Resize();
            }
        }

        /// <summary>
        /// Separate contains function to check to see if the collection contains a control
        /// </summary>
        /// <param name="control">Control to search for</param>
        /// <param name="overrideIndicator">Overload var</param>
        /// <returns>True if the collection contains the searched control</returns>
        public bool Contains(AbstractControl control, bool overrideIndicator)
        {
            foreach (AbstractControl c in this)
            {
                if (control.Handle == c.Handle)
                    return true;
            }
            return false;
        }
    }
}
