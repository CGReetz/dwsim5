﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DWSIM.Interfaces;
using DWSIM.Interfaces.Enums.GraphicObjects;
using DWSIM.UnitOperations.UnitOperations;
using DWSIM.UnitOperations.Reactors;
using DWSIM.UnitOperations.SpecialOps;
using DWSIM.UnitOperations.Streams;
using DWSIM.Thermodynamics.Streams;

using Eto.Forms;

using cv = DWSIM.SharedClasses.SystemsOfUnits.Converter;
using s = DWSIM.UI.Shared.Common;
using Eto.Drawing;

using StringResources = DWSIM.UI.Desktop.Shared.StringArrays;
using DWSIM.Thermodynamics.PropertyPackages;
using DWSIM.Interfaces.Enums;
using OxyPlot;
using OxyPlot.Axes;

namespace DWSIM.UI.Desktop.Editors
{
    public class Results
    {

        public ISimulationObject SimObject;

        public DynamicLayout container;

        public Results(ISimulationObject selectedobject, DynamicLayout layout)
        {
            SimObject = selectedobject;
            container = layout;
            Initialize();
        }

        void Initialize()
        {
                      
            var su = SimObject.GetFlowsheet().FlowsheetOptions.SelectedUnitSystem;
            var nf = SimObject.GetFlowsheet().FlowsheetOptions.NumberFormat;

            var txtcontrol = s.CreateAndAddMultilineTextBoxRow(container, "", true, null);

            if (SimObject is Pipe)
            {
                var pipe = (Pipe)SimObject;
                string[] datatype = {"Length", "Inclination", "Pressure", "Temperature",
					"Liquid Velocity", "Vapor Velocity", "Heat Flow", "Liquid Holdup",
					"Overall HTC","Internal HTC","Wall k/L","Insulation k/L", "External HTC"};

                string[] units = { su.distance, "degrees", su.pressure, su.temperature, su.velocity, su.velocity,
									su.heatflow, "", su.heat_transf_coeff, su.heat_transf_coeff, su.heat_transf_coeff,
									su.heat_transf_coeff, su.heat_transf_coeff};
                      
                s.CreateAndAddButtonRow(container, "View Pipe Properties Profile", null, (Button arg1, EventArgs ev) =>
                {
                    //var sview = new ScrollView(this.Context);
                    //var myview = new TextAndChartView(this.Context);
                    //myview.Orientation = Orientation.Vertical;
                    //myview.SetBackgroundColor(Color.ParseColor("#ff1e74c9"));

                    //var chart = (PlotView)myview.FindViewById(Resource.IdSens.chartView);
                    //chart.SetBackgroundColor(Color.White);

                    ////chart.Visibility = ViewStates.Gone;

                    //var myl = new LinearLayout(this.Context);
                    //myl.Orientation = Orientation.Vertical;
                    //myl.Id = 1000;
                    //List<double> px, py;
                    //myview.AddView(myl, 0);
                    //var txtres = (EditText)myview.FindViewById(Resource.IdSens.txtResults);
                    //txtres.TextSize = float.Parse(fontsize1);

                    //s.CreateAndAddLabelBoxRow(myview, myl.Id, "PIPE SEGMENT PROFILE RESULTS: " + SimObject.GraphicObject.Tag);
                    //var xsp = s.CreateAndAddSpinnerRow(myview, myl.Id, "X Axis Data", datatype, 0, (arg11, arg22, arg33) => { });
                    //var ysp = s.CreateAndAddSpinnerRow(myview, myl.Id, "Y Axis Data", datatype, 2, (arg11, arg22, arg33) => { });
                    //s.CreateAndAddButtonRow(myview, myl.Id, "Update Chart/Table", (arg11, arg22, arg33) =>
                    //{
                    //    px = PopulateData(pipe, xsp.SelectedItemPosition);
                    //    py = PopulateData(pipe, ysp.SelectedItemPosition);
                    //    var model = CreatePipeResultsModel(px.ToArray(), py.ToArray(),
                    //                                       datatype[xsp.SelectedItemPosition] + " (" + units[xsp.SelectedItemPosition] + ")",
                    //                                       datatype[ysp.SelectedItemPosition] + " (" + units[ysp.SelectedItemPosition] + ")");
                    //    chart.Model = model;
                    //    chart.Visibility = ViewStates.Visible;
                    //    chart.LayoutParameters = paramc;
                    //    chart.InvalidatePlot();
                    //    int i = 0;
                    //    var txt = new System.Text.StringBuilder();
                    //    txt.AppendLine(datatype[xsp.SelectedItemPosition] + " (" + units[xsp.SelectedItemPosition] + ")\t\t" + datatype[ysp.SelectedItemPosition] + " (" + units[ysp.SelectedItemPosition] + ")");
                    //    for (i = 0; i <= px.Count - 1; i++)
                    //    {
                    //        txt.AppendLine(px[i].ToString(nf) + "\t\t" + py[i].ToString(nf));
                    //    }
                    //    txtres.Text = txt.ToString();
                    //});
                    //var alert = new AlertDialog.Builder(this.Context);
                    //var param = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                    //myview.LayoutParameters = param;
                    //sview.VerticalScrollBarEnabled = true;
                    //sview.ScrollbarFadingEnabled = false;
                    //sview.AddView(myview);
                    //alert.SetView(sview);
                    //alert.Create().Show();
                });
            }
            else if (SimObject is Column)
            {
                var column = (Column)SimObject;
                string[] datatype = { "Stage", "Pressure", "Temperature", "Vapor Molar Flow", "Liquid Molar Flow" };

                string[] units = { "", su.pressure, su.temperature, su.molarflow, su.molarflow };

                s.CreateAndAddButtonRow(container, "View Column Profile", null, (Button arg1, EventArgs ev) =>
                {

                    //var sview = new ScrollView(this.Context);
                    //var myview = new TextAndChartView(this.Context);
                    //myview.Orientation = Orientation.Vertical;
                    //myview.SetBackgroundColor(Color.ParseColor("#ff1e74c9"));

                    //var chart = (PlotView)myview.FindViewById(Resource.IdSens.chartView);
                    //chart.SetBackgroundColor(Color.White);

                    ////chart.Visibility = ViewStates.Gone;

                    //var myl = new LinearLayout(this.Context);
                    //myl.Orientation = Orientation.Vertical;
                    //myl.Id = 1000;
                    //List<double> px, py;
                    //myview.AddView(myl, 0);
                    //var ll1 = (LinearLayout)myview.FindViewById(Resource.IdSens.linearLayoutET);
                    //ll1.Visibility = ViewStates.Gone;
                    //var ll2 = (LinearLayout)myview.FindViewById(Resource.IdSens.linearLayoutBTNS);
                    //ll2.Visibility = ViewStates.Gone;

                    //s.CreateAndAddLabelBoxRow(myview, myl.Id, "COLUMN PROFILE RESULTS: " + SimObject.GraphicObject.Tag);
                    //var xsp = s.CreateAndAddSpinnerRow(myview, myl.Id, "X Axis Data", datatype, 2, (arg11, arg22, arg33) => { });
                    //var ysp = s.CreateAndAddSpinnerRow(myview, myl.Id, "Y Axis Data", datatype, 0, (arg11, arg22, arg33) => { });
                    //s.CreateAndAddButtonRow(myview, myl.Id, "Update Chart/Table", (arg11, arg22, arg33) =>
                    //{
                    //    px = PopulateColumnData(column, xsp.SelectedItemPosition);
                    //    py = PopulateColumnData(column, ysp.SelectedItemPosition);
                    //    string xunits, yunits;
                    //    xunits = " (" + units[xsp.SelectedItemPosition] + ")";
                    //    yunits = " (" + units[ysp.SelectedItemPosition] + ")";
                    //    if (xsp.SelectedItemPosition == 0) { xunits = ""; }
                    //    if (ysp.SelectedItemPosition == 0) { yunits = ""; }
                    //    var model = CreateColumnResultsModel(px.ToArray(), py.ToArray(),
                    //                                       datatype[xsp.SelectedItemPosition] + xunits,
                    //                                       datatype[ysp.SelectedItemPosition] + yunits);
                    //    chart.Model = model;
                    //    chart.Visibility = ViewStates.Visible;
                    //    chart.LayoutParameters = paramc;
                    //    chart.InvalidatePlot();
                    //});
                    //var alert = new AlertDialog.Builder(this.Context);
                    //var param = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                    //myview.LayoutParameters = param;
                    //sview.VerticalScrollBarEnabled = true;
                    //sview.ScrollbarFadingEnabled = false;
                    //sview.AddView(myview);
                    //alert.SetView(sview);
                    //alert.Create().Show();
                });
            }
            else if (SimObject is Reactor_PFR)
            {
                var reactor = (Reactor_PFR)SimObject;

                if (reactor.points.Count > 0)
                {
                    s.CreateAndAddButtonRow(container, "View Properties Profile", null, (Button arg1, EventArgs ev) =>
                    {

                        //var sview = new ScrollView(this.Context);
                        //var myview = new TextAndChartView(this.Context);
                        //myview.Orientation = Orientation.Vertical;
                        //myview.SetBackgroundColor(Color.ParseColor("#ff1e74c9"));

                        //var chart = (PlotView)myview.FindViewById(Resource.IdSens.chartView);
                        //chart.SetBackgroundColor(Color.White);

                        ////chart.Visibility = ViewStates.Gone;

                        //var myl = new LinearLayout(this.Context);
                        //myl.Orientation = Orientation.Vertical;
                        //myl.Id = 1000;
                        //myview.AddView(myl, 0);

                        //var txtres = (EditText)myview.FindViewById(Resource.IdSens.txtResults);
                        //txtres.Visibility = ViewStates.Gone;
                        //var ll1 = (LinearLayout)myview.FindViewById(Resource.IdSens.linearLayoutET);
                        //ll1.Visibility = ViewStates.Gone;
                        //var ll2 = (LinearLayout)myview.FindViewById(Resource.IdSens.linearLayoutBTNS);
                        //ll2.Visibility = ViewStates.Gone;

                        //s.CreateAndAddLabelBoxRow(myview, myl.Id, "REACTOR PROFILE: " + SimObject.GraphicObject.Tag);

                        //var model = CreatePFRResultsModel(reactor);
                        //chart.Model = model;
                        //chart.Visibility = ViewStates.Visible;
                        //chart.LayoutParameters = paramc;
                        //chart.InvalidatePlot();

                        //var alert = new AlertDialog.Builder(this.Context);
                        //var param = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                        //sview.LayoutParameters = param;
                        //myview.LayoutParameters = param;
                        //sview.VerticalScrollBarEnabled = true;
                        //sview.ScrollbarFadingEnabled = false;
                        //sview.AddView(myview);
                        //alert.SetView(sview);
                        //alert.Create().Show();
                    });
                }
            }

            var obj = (ISimulationObject)SimObject;

            try
            {
                if (obj.PropertyPackage == null)
                {
                    obj.PropertyPackage = (PropertyPackage)SimObject.GetFlowsheet().PropertyPackages.Values.First();
                }
                if (obj.Calculated)
                {
                    txtcontrol.Text = "Object successfully calculated on " + obj.LastUpdated.ToString() + "\n\n";
                    txtcontrol.Text += obj.GetReport(SimObject.GetFlowsheet().FlowsheetOptions.SelectedUnitSystem,
                                               System.Globalization.CultureInfo.InvariantCulture,
                                                SimObject.GetFlowsheet().FlowsheetOptions.NumberFormat);
                }
                else
                {
                    if (obj.ErrorMessage != "")
                    {
                        txtcontrol.Text = "An error occured during the calculation of this object. Details:\n\n" + obj.ErrorMessage;
                    }
                    else
                    {
                        txtcontrol.Text = "This object hasn't been calculated yet.";
                    }
                }
            }
            catch (Exception ex)
            {
                txtcontrol.Text = "Report generation failed. Please recalculate the flowsheet and try again.";
                txtcontrol.Text += "\n\nError details: " + ex.ToString();
            }


        }

        List<double> PopulateData(Pipe pipe, int position)
        {
            var su = SimObject.GetFlowsheet().FlowsheetOptions.SelectedUnitSystem;
            List<double> vec = new List<double>();
            switch (position)
            {
                case 0: //distance

                    double comp_ant = 0.0f;
                    foreach (var sec in pipe.Profile.Sections.Values)
                    {
                        foreach (var res in sec.Resultados)
                        {
                            vec.Add(cv.ConvertFromSI(su.distance, comp_ant));
                            comp_ant += sec.Comprimento / sec.Incrementos;
                        }
                    }
                    break;
                case 1: //elevation

                    foreach (var sec in pipe.Profile.Sections.Values)
                    {
                        foreach (var res in sec.Resultados)
                        {
                            vec.Add(Math.Atan(sec.Elevacao / Math.Pow(Math.Pow(sec.Comprimento, 2) - Math.Pow(sec.Elevacao, 2), 0.5) * 180 / Math.PI));
                        }
                    }
                    break;
                case 2: //pressure

                    foreach (var sec in pipe.Profile.Sections.Values)
                    {
                        foreach (var res in sec.Resultados)
                        {
                            vec.Add(cv.ConvertFromSI(su.pressure, res.PressaoInicial.GetValueOrDefault()));
                        }
                    }
                    break;
                case 3: //temperaturee

                    foreach (var sec in pipe.Profile.Sections.Values)
                    {
                        foreach (var res in sec.Resultados)
                        {
                            vec.Add(cv.ConvertFromSI(su.temperature, res.TemperaturaInicial.GetValueOrDefault()));
                        }
                    }
                    break;
                case 4: //vel liqe

                    foreach (var sec in pipe.Profile.Sections.Values)
                    {
                        foreach (var res in sec.Resultados)
                        {
                            vec.Add(cv.ConvertFromSI(su.velocity, res.LiqVel.GetValueOrDefault()));
                        }
                    }
                    break;
                case 5: //vel vape

                    foreach (var sec in pipe.Profile.Sections.Values)
                    {
                        foreach (var res in sec.Resultados)
                        {
                            vec.Add(cv.ConvertFromSI(su.velocity, res.VapVel.GetValueOrDefault()));
                        }
                    }
                    break;
                case 6: //heatflowe

                    foreach (var sec in pipe.Profile.Sections.Values)
                    {
                        foreach (var res in sec.Resultados)
                        {
                            vec.Add(cv.ConvertFromSI(su.heatflow, res.CalorTransferido.GetValueOrDefault()));
                        }
                    }
                    break;
                case 7: //liqholde

                    foreach (var sec in pipe.Profile.Sections.Values)
                    {
                        foreach (var res in sec.Resultados)
                        {
                            vec.Add(res.HoldupDeLiquido.GetValueOrDefault());
                        }
                    }
                    break;
                case 8: //OHTCe

                    foreach (var sec in pipe.Profile.Sections.Values)
                    {
                        foreach (var res in sec.Resultados)
                        {
                            vec.Add(cv.ConvertFromSI(su.heat_transf_coeff, res.HTC.GetValueOrDefault()));
                        }
                    }
                    break;
                case 9: //IHTCC

                    foreach (var sec in pipe.Profile.Sections.Values)
                    {
                        foreach (var res in sec.Resultados)
                        {
                            vec.Add(cv.ConvertFromSI(su.heat_transf_coeff, res.HTC_internal));
                        }
                    }
                    break;
                case 10: //IHTC

                    foreach (var sec in pipe.Profile.Sections.Values)
                    {
                        foreach (var res in sec.Resultados)
                        {
                            vec.Add(cv.ConvertFromSI(su.heat_transf_coeff, res.HTC_pipewall));
                        }
                    }
                    break;
                case 11: //IHTC

                    foreach (var sec in pipe.Profile.Sections.Values)
                    {
                        foreach (var res in sec.Resultados)
                        {
                            vec.Add(cv.ConvertFromSI(su.heat_transf_coeff, res.HTC_insulation));
                        }
                    }
                    break;
                case 12: //EHTC

                    foreach (var sec in pipe.Profile.Sections.Values)
                    {
                        foreach (var res in sec.Resultados)
                        {
                            vec.Add(cv.ConvertFromSI(su.heat_transf_coeff, res.HTC_external));
                        }
                    }
                    break;
            }
            return vec;
        }

        OxyPlot.PlotModel CreatePipeResultsModel(double[] x, double[] y, string xtitle, string ytitle)
        {


            var model = new PlotModel() { Subtitle = "Properties Profile", Title = SimObject.GraphicObject.Tag };
            model.TitleFontSize = 18;
            model.SubtitleFontSize = 16;
            model.Axes.Add(new LinearAxis()
            {
                MajorGridlineStyle = LineStyle.Dash,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Bottom,
                FontSize = 16,
                Title = xtitle
            });
            model.Axes.Add(new LinearAxis()
            {
                MajorGridlineStyle = LineStyle.Dash,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Left,
                FontSize = 16,
                Title = ytitle
            });
            model.LegendFontSize = 16;
            model.LegendPlacement = LegendPlacement.Outside;
            model.LegendOrientation = LegendOrientation.Vertical;
            model.LegendPosition = LegendPosition.BottomCenter;
            model.TitleHorizontalAlignment = TitleHorizontalAlignment.CenteredWithinView;
            //model.AddLineSeries(x, y);

            return model;

        }

        OxyPlot.PlotModel CreatePFRResultsModel(Reactor_PFR reactor)
        {

            var su = SimObject.GetFlowsheet().FlowsheetOptions.SelectedUnitSystem;

            var model = new PlotModel() { Subtitle = "Properties Profile", Title = SimObject.GraphicObject.Tag };
            model.TitleFontSize = 18;
            model.SubtitleFontSize = 16;
            model.Axes.Add(new LinearAxis()
            {
                MajorGridlineStyle = LineStyle.Dash,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Bottom,
                FontSize = 16,
                Title = "Volume (" + su.volume + ")"
            });
            model.Axes.Add(new LinearAxis()
            {
                MajorGridlineStyle = LineStyle.Dash,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Left,
                FontSize = 16,
                Title = "Concentration (" + su.molar_conc + ")",
                Key = "conc"
            });
            model.Axes.Add(new LinearAxis()
            {
                MajorGridlineStyle = LineStyle.Dash,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Right,
                FontSize = 16,
                Title = "Temperature (" + su.temperature + ")",
                Key = "temp",
                PositionTier = 0
            });
            model.Axes.Add(new LinearAxis()
            {
                MajorGridlineStyle = LineStyle.Dash,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Right,
                FontSize = 16,
                Title = "Pressre (" + su.pressure + ")",
                Key = "press",
                PositionTier = 1
            });

            model.LegendFontSize = 16;
            model.LegendPlacement = LegendPlacement.Outside;
            model.LegendOrientation = LegendOrientation.Horizontal;
            model.LegendPosition = LegendPosition.BottomCenter;
            model.TitleHorizontalAlignment = TitleHorizontalAlignment.CenteredWithinView;

            List<double> vx = new List<double>(), vy = new List<double>();
            List<List<double>> vya = new List<List<double>>();
            List<string> vn = new List<string>();

            foreach (var obj in reactor.points)
            {
                vx.Add(((double[])obj)[0]);
            }
            int j;
            for (j = 1; j <= reactor.ComponentConversions.Count + 2; j++)
            {
                vy.Clear();
                foreach (var obj in reactor.points)
                {
                    vy.Add(((double[])obj)[j]);
                }
                vya.Add(vy);
            }
            foreach (var st in reactor.ComponentConversions.Keys)
            {
                vn.Add(st);
            }
            OxyColor color;
            for (j = 0; j <= vn.Count - 1; j++)
            {
                color = OxyColor.FromRgb(Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)));
                //model.Series.Add(cv.ConvertArrayFromSI(su.volume, vx.ToArray()), cv.ConvertArrayFromSI(su.molar_conc, vya[j].ToArray()), color);
                model.Series[model.Series.Count - 1].Title = vn[j];
                ((OxyPlot.Series.LineSeries)(model.Series[model.Series.Count - 1])).YAxisKey = "conc";
            }
            color = OxyColor.FromRgb(Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)));
            //model.AddLineSeries(cv.ConvertArrayFromSI(su.volume, vx.ToArray()), cv.ConvertArrayFromSI(su.temperature, vya[j].ToArray()), color);
            model.Series[model.Series.Count - 1].Title = "Temperature";
            ((OxyPlot.Series.LineSeries)(model.Series[model.Series.Count - 1])).YAxisKey = "temp";
            color = OxyColor.FromRgb(Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)));
            //model.AddLineSeries(cv.ConvertArrayFromSI(su.volume, vx.ToArray()), cv.ConvertArrayFromSI(su.pressure, vya[j + 1].ToArray()), color);
            model.Series[model.Series.Count - 1].Title = "Pressure";
            ((OxyPlot.Series.LineSeries)(model.Series[model.Series.Count - 1])).YAxisKey = "press";

            return model;


        }

        List<double> PopulateColumnData(Column col, int position)
        {
            var su = SimObject.GetFlowsheet().FlowsheetOptions.SelectedUnitSystem;
            List<double> vec = new List<double>();
            switch (position)
            {
                case 0: //distance

                    double comp_ant = 1.0f;
                    foreach (var st in col.Stages)
                    {
                        vec.Add(comp_ant);
                        comp_ant += 1.0f;
                    }
                    break;
                case 1: //pressure
                    vec = cv.ConvertArrayFromSI(su.pressure, col.P0).ToList();
                    break;
                case 2: //temperature
                    vec = cv.ConvertArrayFromSI(su.temperature, col.Tf).ToList();
                    break;
                case 3: //vapor flow
                    vec = cv.ConvertArrayFromSI(su.molarflow, col.Vf).ToList();
                    break;
                case 4: //liquid flow
                    vec = cv.ConvertArrayFromSI(su.molarflow, col.Lf).ToList();
                    break;
            }
            return vec;
        }

        OxyPlot.PlotModel CreateColumnResultsModel(double[] x, double[] y, string xtitle, string ytitle)
        {
            var model = new PlotModel() { Subtitle = "Column Profile", Title = SimObject.GraphicObject.Tag };
            model.TitleFontSize = 18;
            model.SubtitleFontSize = 16;
            model.Axes.Add(new LinearAxis()
            {
                MajorGridlineStyle = LineStyle.Dash,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Bottom,
                FontSize = 16,
                Title = xtitle
            });
            if (Math.Abs(y[0] - 1.0f) < 0.0001)
            {
                model.Axes.Add(new LinearAxis()
                {
                    MajorGridlineStyle = LineStyle.Dash,
                    MinorGridlineStyle = LineStyle.Dot,
                    Position = AxisPosition.Left,
                    FontSize = 16,
                    Title = ytitle,
                    StartPosition = 1,
                    EndPosition = 0,
                    MajorStep = 1.0f,
                    MinorStep = 0.5f
                });
            }
            else
            {
                model.Axes.Add(new LinearAxis()
                {
                    MajorGridlineStyle = LineStyle.Dash,
                    MinorGridlineStyle = LineStyle.Dot,
                    Position = AxisPosition.Left,
                    FontSize = 16,
                    Title = ytitle
                });
            }
            model.LegendFontSize = 16;
            model.LegendPlacement = LegendPlacement.Outside;
            model.LegendOrientation = LegendOrientation.Vertical;
            model.LegendPosition = LegendPosition.BottomCenter;
            model.TitleHorizontalAlignment = TitleHorizontalAlignment.CenteredWithinView;
            //model.AddLineSeries(x, y);

            return model;

        }

    }

}