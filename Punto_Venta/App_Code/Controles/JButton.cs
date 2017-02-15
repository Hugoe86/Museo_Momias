using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_BASE.App_Code.Controles
{
    class JButton : Button
    {
        #region (Variables Privadas)
        private Image Imagen;
        private Size Tamano_Imagen;
        private Boolean Estatus_Imagen = false;
        private Point Localizacion;
        public int _originalWidth;
        public int _originalHeight;
        private String Texto_Boton;
        #endregion

        #region (Variables Públicas)
        public Image P_Imagen
        {
            get { return Imagen; }
            set { Imagen = value; }
        }
        public Size P_Tamano_Imagen
        {
            get { return Tamano_Imagen; }
            set { Tamano_Imagen = value; }
        }
        public Point P_Localizacion
        {
            get { return Localizacion; }
            set { Localizacion = value; }
        }
        public String P_Texto_Boton
        {
            get { return Texto_Boton; }
            set { Texto_Boton = value; }
        }
        public Boolean P_Estatus_Imagen
        {
            get { return Estatus_Imagen; }
            set { Estatus_Imagen = value; }
        }
        
        #endregion

        #region(Constructor)
        /// <summary>
        /// Nombre: JButton
        /// 
        /// Descripción: Constructor de la clase JButon
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 24 Octubre 2013 09:12 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Imagen">Imagen que se le agregara al botón</param>
        /// <param name="Tamano">Tamaño del botón</param>
        public JButton(Image Imagen, Size Tamano)
        {
            this.Imagen = Imagen;
            this.Size = Tamano;

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);
        }
        /// <summary>
        /// Nombre: JButton
        /// 
        /// Descripción: Constructor de la clase JButon
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 24 Octubre 2013 09:12 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Imagen">Imagen que se le agregara al botón</param>
        /// <param name="Tamano">Tamaño del botón</param>
        public JButton(Image Imagen, Size Tamano, Size Tamano_Imagen, Point Localizacion, String Texto_Boton, Boolean Estatus_Imagen)
        {
            this.Imagen = Imagen;
            this.Size = Tamano;
            this.Tamano_Imagen = Tamano_Imagen;
            this.Localizacion = Localizacion;
            this.Texto_Boton = Texto_Boton;
            this.Estatus_Imagen = Estatus_Imagen;
            this.DoubleBuffered = true;
            _originalWidth = this.Width;
            _originalHeight = this.Height;

            this.SetStyle(
                ControlStyles.Opaque |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
            this.BackColor = Color.Transparent;


        }
        #endregion

        #region (Métodos)
        /// <summary>
        /// Nombre: OnPaint
        /// 
        /// Descripción: Método que se encarga del dibujado del botón.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 24 Octubre 2013 09:16 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            float Escala_X = (float)this.Width / (float)this._originalWidth;//Obtenemos el factor de escala en X.
            float Escala_Y = (float)this.Height / (float)this._originalHeight;//Obtenemos el factor de escala en Y. 
            int Espacio_Precio = (int)(((float)this.Height * (float)80) / this._originalHeight);//Obtenemos el valor para restarselo a la altura de la imagen.
            Font Fuente_Texto_Detalle = new Font("Arial", 10, FontStyle.Bold);
            Font Fuente_Texto = new Font("Arial", 9, FontStyle.Bold);

            base.OnPaint(pevent);
            Graphics Graficos = pevent.Graphics;


            if (this.Estatus_Imagen == true)
            {
                //create a Bitmap the size of the image provided  
                Bitmap bmp = new Bitmap(this.Imagen.Width, this.Imagen.Height);

                //create a graphics object from the image  
                using (Graphics gfx = Graphics.FromImage(bmp))
                {

                    //create a color matrix object  
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = (float)0.25;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    gfx.DrawImage(this.Imagen, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, this.Imagen.Width, this.Imagen.Height, GraphicsUnit.Pixel, attributes);
                }

                this.Imagen = bmp;
                this.Estatus_Imagen = false;
            }

            //Dibujamos la imagen sobre el botón.
            if (Tamano_Imagen.IsEmpty)
                Graficos.DrawImage(this.Imagen, new Rectangle(new Point(0, 0), new Size(this.Width, this.Height)));
            else
            {
                Rectangle Marco = new Rectangle(
                    ((this.Width - (this.Width - 30)) / 2),
                    5,
                    (this.Width - 30),
                    (this.Height - Espacio_Precio));

                //Instaciamos un objeto de la clase GraphicsPath que utilizaremos para dibujar figuras primitivas.
                GraphicsPath Dibujar_Figuras = new GraphicsPath();
                ////Agregamos una elipse a objeto de dibujo.
                Dibujar_Figuras.AddEllipse(Marco);
                //Dibujamos el gráfico sobre la pantalla.
                Graficos.DrawPath(Pens.Transparent, Dibujar_Figuras);
                ////Establece la región de recorte.
                //Graficos.SetClip(Dibujar_Figuras);
                ////Dibujamos un rectágulo.
                //Graficos.FillRectangle(SystemBrushes.Window, Marco);
                //Dibujamos la imagen aplicando los factores de escala que calculamos previamente.
                Graficos.DrawImage(this.Imagen,
                    ((this.Width - (this.Tamano_Imagen.Width * Escala_X)) / 2),
                    (this.Localizacion.Y),
                    (this.Tamano_Imagen.Width * Escala_X),
                    (this.Tamano_Imagen.Height * Escala_Y));
              

                SizeF SzF_Str_Tamaño_Texto = new SizeF();
                Single Tamaño = 0;
                RectangleF Rectangulo = new RectangleF();
                StringFormat Formato_Centrado = new StringFormat();

                Formato_Centrado.Alignment = StringAlignment.Center;
                Formato_Centrado.LineAlignment = StringAlignment.Center;

           
                Graphics Graficos_Texto = pevent.Graphics;
                //  se toma el tamaño del producto
                SzF_Str_Tamaño_Texto = Graficos_Texto.MeasureString(this.Texto_Boton, Fuente_Texto_Detalle);
                Font Fuente_Final;

                if (this.Texto_Boton.Length > 40)
                    Fuente_Final = Fuente_Texto;
                else
                    Fuente_Final = Fuente_Texto_Detalle;

                
                // se crea el rectangulo con el texto
                Tamaño = Graficos_Texto.MeasureString(this.Texto_Boton, Fuente_Final, this.Width, Formato_Centrado).Height;
                Rectangulo = new RectangleF(10, this.Height / 2, this.Width - 10, Tamaño);
                Graficos_Texto.DrawString(this.Texto_Boton, Fuente_Final, Brushes.Black, Rectangulo, Formato_Centrado);

                //Liberamos los recursos utilizados por elobjeto graphics.
                Dibujar_Figuras.Dispose();


            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
            this.Update();
        }


        #endregion
    }
}
