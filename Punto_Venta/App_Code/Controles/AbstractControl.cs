using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace ResizeableForm
{
    /// <summary>
    /// Stores information about a form, and provides a quick means to resize a control when a form is resized
    /// </summary>
    public class AbstractControl
    {
        /// <summary>
        /// The real control associated with this control
        /// </summary>
        Control _associatedControl;

        /// <summary>
        /// The form associated with the control
        /// </summary>
        ResizableForm _parentForm;

        /// <summary>
        /// Original Height ratio
        /// </summary>
        double _originalHeightRatio;

        /// <summary>
        /// Original width ratio
        /// </summary>
        double _originalWidthRatio;
        /// <summary>
        /// Original X Location of the control
        /// </summary>
        double _originalXRatio;

        /// <summary>
        /// Original Y Location of the form
        /// </summary>
        double _originalYRatio;
        /// <summary>
        /// Original Size of the control
        /// </summary>
        float _originalFontControl;
        /// <summary>
        /// Original Width Window
        /// </summary>
        int _originalWidthWindow;
        /// <summary>
        /// Original Height Window
        /// </summary>
        int _originalHeightWindow;
        /// <summary>
        /// Font Original Cell Table
        /// </summary>
        Font _originalFontCell;
        /// <summary>
        /// The handle associated with the associated control
        /// </summary>
        IntPtr _handle;

        public AbstractControl(Control c, ResizableForm originalForm)
        {
            _parentForm = originalForm;

            _originalWidthWindow = originalForm.Width;
            _originalHeightWindow = originalForm.Height;
            _originalFontControl = c.Font.Size;

            if (c is DataGridView)
                _originalFontCell = getFontCell(c);

            _associatedControl = c;
            _handle = c.Handle;
            _originalHeightRatio = (double)c.Height / (double)originalForm.Height;
            _originalWidthRatio = (double)c.Width / (double)originalForm.Width;

            _originalXRatio = (double)c.Location.X / (double)originalForm.Width;
            _originalYRatio = (double)c.Location.Y / (double)originalForm.Height;
        }

        /// <summary>
        /// Public access to this control's handle
        /// </summary>
        public IntPtr Handle
        {
            get { return _handle; }
        }

        /// <summary>
        /// Provides a means to resize the control based on the new form size
        /// </summary>
        public void Resize()
        {
            if (_associatedControl is DataGridView)
                if (_originalFontCell == null)
                    _originalFontCell = getFontCell(_associatedControl);

            float escala_x = ((float)_parentForm.Width / (float)_originalWidthWindow);
            float escala_y = ((float)_parentForm.Height / (float)_originalHeightWindow);

            int newWidth = (int)((double)(_parentForm.Width * _originalWidthRatio));
            int newHeight = (int)((double)(_parentForm.Height * _originalHeightRatio));

            int newX = (int)((double)(_parentForm.Width * _originalXRatio));
            int newY = (int)((double)(_parentForm.Height * _originalYRatio));

            _associatedControl.Width = newWidth;
            _associatedControl.Height = newHeight;
            _associatedControl.Location = new System.Drawing.Point(newX, newY);

            #region (Resize Font)
            if (escala_x > escala_y)
                _associatedControl.Font = new Font(_associatedControl.Font.FontFamily, (float)(_originalFontControl * escala_y), _associatedControl.Font.Style);
            else
                _associatedControl.Font = new Font(_associatedControl.Font.FontFamily, (float)(_originalFontControl * escala_x), _associatedControl.Font.Style);
            #endregion

            #region (Resize DataGridView)
            if (_associatedControl is DataGridView) {
                DataGridView _tabla = (DataGridView)_associatedControl;
                _tabla.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                Array.ForEach(_tabla.Columns.OfType<DataGridViewColumn>().ToArray(), columna => {                    
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                });
                Array.ForEach(_tabla.Rows.OfType<DataGridViewRow>().ToArray(), fila => {
                    Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda =>
                    {
                        if (_originalFontCell != null)
                        {
                            if (escala_x > escala_y)
                                celda.Style.Font = new Font(_originalFontCell.FontFamily, (float)(_originalFontCell.Size * escala_y), _originalFontCell.Style);
                            else
                                celda.Style.Font = new Font(_originalFontCell.FontFamily, (float)(_originalFontCell.Size * escala_x), _originalFontCell.Style);
                        }
                    });
                });
            }
            #endregion
        }
        /// <summary>
        /// get font object to the cell of each table
        /// </summary>
        public Font getFontCell(Control _Ctrl) {
            Font _fontCell = null;
            DataGridView _tabla = _Ctrl as DataGridView  ;

            Array.ForEach(_tabla.Rows.OfType<DataGridViewRow>().ToArray(), fila =>
            {
                Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda =>
                {
                    if (celda.Style.Font != null)
                        _fontCell = celda.Style.Font;
                    else
                        _fontCell = new Font("Arial", 9, FontStyle.Regular);
                });
            });
            return _fontCell;
        }
    }
}
