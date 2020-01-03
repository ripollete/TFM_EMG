using signalAcquirer.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace signalAcquirer
{
    public partial class grafico : Form
    {
        
        public grafico(List<double> datos,string title="",string XAxis="",string YAxis="")
        {
            InitializeComponent();
            
            GraphPane Grafico = zedGraphControl1.GraphPane;
            //Títulos de los gráficos            
            Grafico.Title.Text = title;
            Grafico.XAxis.Title.Text = XAxis;
            Grafico.YAxis.Title.Text = YAxis;

            //Se guardan 1.200 puntos.
            //El RollingPointPairList es una clase de almacenamiento eficiente, que siempre
            //mantiene un conjunto de rodadura de punto de datos sin necesidad de cambiar      
            //los valores de datos   
            RollingPointPairList Lista = new RollingPointPairList(datos.Count());

            //En un principio la curva se añade sin puntos de datos (la lista está vacía)
            //El color es azul y no habrá símbolos
            LineItem curva = Grafico.AddCurve("Valores de X", Lista, Color.Blue, SymbolType.None);
            
            // Se controla manualmente que el rango del eje X está continuamente             
            Grafico.XAxis.Scale.Min = 0;

            Grafico.XAxis.Scale.Max = 30;
            Grafico.XAxis.Scale.MinorStep = 1;
            Grafico.XAxis.Scale.MajorStep = 5;
            
            //Escalar los ejes            
            zedGraphControl1.AxisChange();

            representacion(datos);

            MyBL bl = new MyBL();
            //label1.Text = "Cross zero: " + bl.feature_cross(datos).ToString();
            //label1.Text = label1.Text + " Absolute mean value: " + bl.feature_absolute_mean_value(datos).ToString();
            //label1.Text = label1.Text + " Variance: " + bl.feature_variance(datos).ToString();
        }

        private void representacion(List<double> alLista)
        {
            int i;
            //Se asegura que curvelist tiene, al menos, una curva
           if (zedGraphControl1.GraphPane.CurveList.Count <= 0)
                return;
                

                // Obtener el CurveItem por primera vez en el gráfico
            LineItem curvaGrafico = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            if (curvaGrafico == null)
                return;

            //Obtener el PointPairList
            IPointListEdit lista = curvaGrafico.Points as IPointListEdit;

            // Si éste es nulo, significa que la referencia en curve.Points no admite      
            //IPointListEdit, 
            //por lo que no será capaz de modificarlo
            if (lista == null)
                return;
            //Adición de los puntos
            for (i = 0; i <= alLista.Count - 1; i++)
            {
                lista.Add(i, Convert.ToDouble(alLista[i]));
            }
            //Mantener la escala en X en un intervalo continuo de 30 segundos,
            //entre el máximo valor de X y el extremo del eje
            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            if (i > xScale.Max - xScale.MajorStep)
            {
                xScale.Max = i + xScale.MajorStep;
                xScale.Min = xScale.Max - 30.0;
            }
            //Se asegura que el eje Y se reajustará para dar cabida a los datos reales            
            zedGraphControl1.AxisChange();
            //Forzar un redibujo            
            zedGraphControl1.Invalidate();
        }

        private void Grafico_Load(object sender, EventArgs e)
        {

        }
    }


}
