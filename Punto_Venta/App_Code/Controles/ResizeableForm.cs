using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ResizeableForm
{
    public class ResizableForm : Form
    {
        /// <summary>
        /// Abstract controls on the form
        /// </summary>
        AbstractControlCollection _controls;

        public ResizableForm()
        {
            this.Paint += new PaintEventHandler(onFormPaint);
            this.Resize += new EventHandler(onFormResize);
        }

        private void onFormPaint(object sender, PaintEventArgs e)
        {
            if (_controls == null)
                _controls = new AbstractControlCollection(this);
        }

        private void onFormResize(object sender, EventArgs e)
        {
            if (_controls == null)
                return;

            _controls.Resize();
        }
    }
}
