﻿Imports System.Reflection
Imports System.IO

Public Class Utility

    Shared Sub UpdateElement(xel As XElement)

        If xel.Name = "TipoObjeto" Then xel.Name = "ObjectType"
        If xel.Name = "Nome" Then xel.Name = "Name"
        If xel.Name = "Descricao" Then xel.Name = "Description"
        If xel.Name = "Tipo" Then xel.Name = "Type"
        If xel.Name = "FracaoMolar" Then xel.Name = "MoleFraction"
        If xel.Name = "FracaoMassica" Then xel.Name = "MassFraction"
        If xel.Name = "FracaoDePetroleo" Then xel.Name = "PetroleumFraction"
        If xel.Value = "Nenhum" Then xel.Value = "None"
        If xel.Value = "Destino" Then xel.Value = "Target"
        If xel.Value = "Fonte" Then xel.Value = "Source"
        If xel.Value = "Manipulada" Then xel.Value = "Manipulated"
        If xel.Value = "Referencia" Then xel.Value = "Referenced"
        If xel.Value = "Controlada" Then xel.Value = "Controlled"

        If xel.Value.EndsWith("Streams.MaterialStream") Then xel.Value = "DWSIM.Thermodynamics.Streams.MaterialStream"

        If xel.Value.EndsWith("Streams.EnergyStream") Then xel.Value = "DWSIM.UnitOperations.Streams.EnergyStream"

        If xel.Value.EndsWith("UnitOps.Vessel") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Vessel"
        If xel.Value.EndsWith("UnitOps.Compressor") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Compressor"
        If xel.Value.EndsWith("UnitOps.Expander") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Expander"
        If xel.Value.EndsWith("UnitOps.Heater") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Heater"
        If xel.Value.EndsWith("UnitOps.Cooler") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Cooler"
        If xel.Value.EndsWith("UnitOps.HeatExchanger") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.HeatExchanger"
        If xel.Value.EndsWith("UnitOps.Filter") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Filter"
        If xel.Value.EndsWith("UnitOps.Mixer") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Mixer"
        If xel.Value.EndsWith("UnitOps.Splitter") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Splitter"
        If xel.Value.EndsWith("UnitOps.ComponentSeparator") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.ComponentSeparator"
        If xel.Value.EndsWith("UnitOps.ShortcutColumn") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.ShortcutColumn"
        If xel.Value.EndsWith("UnitOps.CustomUO") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.CustomUO"
        If xel.Value.EndsWith("UnitOps.CapeOpenUO") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.CapeOpenUO"
        If xel.Value.EndsWith("UnitOps.Flowsheet") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Flowsheet"
        If xel.Value.EndsWith("UnitOps.OrificePlate") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.OrificePlate"
        If xel.Value.EndsWith("UnitOps.SolidsSeparator") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.SolidsSeparator"
        If xel.Value.EndsWith("UnitOps.ExcelUO") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.ExcelUO"
        If xel.Value.EndsWith("UnitOps.Tank") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Tank"
        If xel.Value.EndsWith("UnitOps.Valve") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Valve"
        If xel.Value.EndsWith("UnitOps.Pump") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Pump"
        If xel.Value.EndsWith("UnitOps.Pipe") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Pipe"
        If xel.Value.EndsWith("UnitOps.DistillationColumn") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.DistillationColumn"
        If xel.Value.EndsWith("UnitOps.AbsorptionColumn") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.AbsorptionColumn"
        If xel.Value.EndsWith("UnitOps.ReboiledAbsorber") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.ReboiledAbsorber"
        If xel.Value.EndsWith("UnitOps.RefluxedAbsorber") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.RefluxedAbsorber"

        If xel.Value.EndsWith("Reactors.Reactor_Conversion") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_Conversion"
        If xel.Value.EndsWith("Reactors.Reactor_Equilibrium") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_Equilibrium"
        If xel.Value.EndsWith("Reactors.Reactor_Gibbs") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_Gibbs"
        If xel.Value.EndsWith("Reactors.Reactor_PFR") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_PFR"
        If xel.Value.EndsWith("Reactors.Reactor_CSTR") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_CSTR"

        If xel.Value.EndsWith("SpecialOps.Adjust") Then xel.Value = "DWSIM.UnitOperations.SpecialOps.Adjust"
        If xel.Value.EndsWith("SpecialOps.Spec") Then xel.Value = "DWSIM.UnitOperations.SpecialOps.Spec"
        If xel.Value.EndsWith("SpecialOps.Recycle") Then xel.Value = "DWSIM.UnitOperations.SpecialOps.Recycle"
        If xel.Value.EndsWith("SpecialOps.EnergyRecycle") Then xel.Value = "DWSIM.UnitOperations.SpecialOps.EnergyRecycle"

        If xel.Value.EndsWith("DWSIM.MaterialStream") Then xel.Value = "DWSIM.Thermodynamics.Streams.MaterialStream"

        If xel.Value.EndsWith("DWSIM.EnergyStream") Then xel.Value = "DWSIM.UnitOperations.Streams.EnergyStream"

        If xel.Value.EndsWith("DWSIM.Vessel") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Vessel"
        If xel.Value.EndsWith("DWSIM.Compressor") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Compressor"
        If xel.Value.EndsWith("DWSIM.Expander") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Expander"
        If xel.Value.EndsWith("DWSIM.Heater") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Heater"
        If xel.Value.EndsWith("DWSIM.Cooler") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Cooler"
        If xel.Value.EndsWith("DWSIM.HeatExchanger") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.HeatExchanger"
        If xel.Value.EndsWith("DWSIM.Filter") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Filter"
        If xel.Value.EndsWith("DWSIM.Mixer") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Mixer"
        If xel.Value.EndsWith("DWSIM.Splitter") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Splitter"
        If xel.Value.EndsWith("DWSIM.ComponentSeparator") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.ComponentSeparator"
        If xel.Value.EndsWith("DWSIM.ShortcutColumn") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.ShortcutColumn"
        If xel.Value.EndsWith("DWSIM.CustomUO") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.CustomUO"
        If xel.Value.EndsWith("DWSIM.CapeOpenUO") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.CapeOpenUO"
        If xel.Value.EndsWith("DWSIM.Flowsheet") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Flowsheet"
        If xel.Value.EndsWith("DWSIM.OrificePlate") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.OrificePlate"
        If xel.Value.EndsWith("DWSIM.SolidsSeparator") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.SolidsSeparator"
        If xel.Value.EndsWith("DWSIM.ExcelUO") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.ExcelUO"
        If xel.Value.EndsWith("DWSIM.Tank") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Tank"
        If xel.Value.EndsWith("DWSIM.Valve") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Valve"
        If xel.Value.EndsWith("DWSIM.Pump") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Pump"
        If xel.Value.EndsWith("DWSIM.Pipe") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Pipe"
        If xel.Value.EndsWith("DWSIM.DistillationColumn") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.DistillationColumn"
        If xel.Value.EndsWith("DWSIM.AbsorptionColumn") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.AbsorptionColumn"
        If xel.Value.EndsWith("DWSIM.ReboiledAbsorber") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.ReboiledAbsorber"
        If xel.Value.EndsWith("DWSIM.RefluxedAbsorber") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.RefluxedAbsorber"

        If xel.Value.EndsWith("DWSIM.Reactor_Conversion") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_Conversion"
        If xel.Value.EndsWith("DWSIM.Reactor_Equilibrium") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_Equilibrium"
        If xel.Value.EndsWith("DWSIM.Reactor_Gibbs") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_Gibbs"
        If xel.Value.EndsWith("DWSIM.Reactor_PFR") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_PFR"
        If xel.Value.EndsWith("DWSIM.Reactor_CSTR") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_CSTR"

        If xel.Value.EndsWith("DWSIM.Adjust") Then xel.Value = "DWSIM.UnitOperations.SpecialOps.Adjust"
        If xel.Value.EndsWith("DWSIM.Spec") Then xel.Value = "DWSIM.UnitOperations.SpecialOps.Spec"
        If xel.Value.EndsWith("DWSIM.Recycle") Then xel.Value = "DWSIM.UnitOperations.SpecialOps.Recycle"
        If xel.Value.EndsWith("DWSIM.EnergyRecycle") Then xel.Value = "DWSIM.UnitOperations.SpecialOps.EnergyRecycle"

    End Sub

    Shared Sub UpdateElementForNewUI(xel As XElement)

        If xel.Name = "TipoObjeto" Then xel.Name = "ObjectType"
        If xel.Name = "Nome" Then xel.Name = "Name"
        If xel.Name = "Descricao" Then xel.Name = "Description"
        If xel.Name = "Tipo" Then xel.Name = "Type"
        If xel.Name = "FracaoMolar" Then xel.Name = "MoleFraction"
        If xel.Name = "FracaoMassica" Then xel.Name = "MassFraction"
        If xel.Name = "FracaoDePetroleo" Then xel.Name = "PetroleumFraction"
        If xel.Value = "Nenhum" Then xel.Value = "None"
        If xel.Value = "Destino" Then xel.Value = "Target"
        If xel.Value = "Fonte" Then xel.Value = "Source"
        If xel.Value = "Manipulada" Then xel.Value = "Manipulated"
        If xel.Value = "Referencia" Then xel.Value = "Referenced"
        If xel.Value = "Controlada" Then xel.Value = "Controlled"

        If xel.Name = "Fill" Then xel.Value = "True"

        If xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.ReactorEquilibriumGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.EquilibriumReactorGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.ReactorConversionGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.ConversionReactorGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.ReactorGibbsGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.GibbsReactorGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.ReactorCSTRGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.CSTRGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.ReactorPFRGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.PFRGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.NodeInGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.MixerGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.NodeOutGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.SplitterGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.HeaterGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.HeaterGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.CoolerGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.CoolerGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.CompressorGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.CompressorGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.ExpanderGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.ExpanderGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.ShorcutColumnGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.ShortcutColumnGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.DistillationColumnGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.RigorousColumnGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.AbsorptionColumnGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.AbsorptionColumnGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.FlowsheetUOGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.FlowsheetGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.CustomUOGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.ScriptGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.CapeOpenUOGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.CAPEOPENGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.ExcelUOGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.SpreadsheetGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.PipeGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.PipeSegmentGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.TextGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.TextGraphic"
        End If

        If xel.Value.StartsWith("DWSIM.DrawingTools.GraphicObjects") And xel.Name = "Type" Then
            xel.Value = xel.Value.Replace("DWSIM.DrawingTools.GraphicObjects", "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes")
        End If

        If xel.Value.StartsWith("DWSIM.GraphicObjects") And xel.Name = "Type" Then
            xel.Value = xel.Value.Replace("DWSIM.GraphicObjects", "DWSIM.Drawing.SkiaSharp.GraphicObjects.Tables")
        End If

    End Sub

    Shared Sub UpdateElementFromNewUI(xel As XElement)

        If xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.EquilibriumReactorGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.ReactorEquilibriumGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.ConversionReactorGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.ReactorConversionGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.GibbsReactorGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.ReactorGibbsGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.CSTRGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.ReactorCSTRGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.PFRGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.ReactorPFRGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.MixerGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.NodeInGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.SplitterGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.NodeOutGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.HeaterGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.HeaterGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.CoolerGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.CoolerGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.CompressorGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.CompressorGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.ExpanderGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.ExpanderGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.ShortcutColumnGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.ShorcutColumnGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.RigorousColumnGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.DistillationColumnGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.AbsorptionColumnGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.AbsorptionColumnGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.FlowsheetGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.FlowsheetUOGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.ScriptGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.CustomUOGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.CAPEOPENGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.CapeOpenUOGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.SpreadsheetGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.ExcelUOGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.PipeSegmentGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.PipeGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.TextGraphic") Then
            xel.Value = "DWSIM.DrawingTools.GraphicObjects.TextGraphic"
        End If

        If xel.Value.StartsWith("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes") And xel.Name = "Type" Then
            xel.Value = xel.Value.Replace("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes", "DWSIM.DrawingTools.GraphicObjects")
        End If

        If xel.Value.StartsWith("DWSIM.Drawing.SkiaSharp.GraphicObjects.Tables") And xel.Name = "Type" Then
            xel.Value = xel.Value.Replace("DWSIM.Drawing.SkiaSharp.GraphicObjects.Tables", "DWSIM.GraphicObjects")
        End If

        If xel.Value.StartsWith("DWSIM.Drawing.SkiaSharp.GraphicObjects.Charts") And xel.Name = "Type" Then
            xel.Value = xel.Value.Replace("DWSIM.Drawing.SkiaSharp.GraphicObjects.Charts", "DWSIM.DrawingTools.GraphicObjects")
        End If

    End Sub

    Shared Sub UpdateElementForMobileXMLLoading(xel As XElement)

        If xel.Name = "TipoObjeto" Then xel.Name = "ObjectType"
        If xel.Name = "Nome" Then xel.Name = "Name"
        If xel.Name = "Descricao" Then xel.Name = "Description"
        If xel.Name = "Tipo" Then xel.Name = "Type"
        If xel.Name = "FracaoMolar" Then xel.Name = "MoleFraction"
        If xel.Name = "FracaoMassica" Then xel.Name = "MassFraction"
        If xel.Name = "FracaoDePetroleo" Then xel.Name = "PetroleumFraction"
        If xel.Value = "Nenhum" Then xel.Value = "None"
        If xel.Value = "Destino" Then xel.Value = "Target"
        If xel.Value = "Fonte" Then xel.Value = "Source"
        If xel.Value = "Manipulada" Then xel.Value = "Manipulated"
        If xel.Value = "Referencia" Then xel.Value = "Referenced"
        If xel.Value = "Controlada" Then xel.Value = "Controlled"

        If xel.Name = "Fill" Then xel.Value = "True"

        If xel.Value.Equals("PortableFlowsheetDrawing.GraphicObjects.Shapes.EquilibriumReactorGraphic") Then
            xel.Value = "DWSIM.rawing.SkiaSharp.GraphicObjects.ReactorEquilibriumGraphic"
        ElseIf xel.Value.Equals("PortableFlowsheetDrawing.GraphicObjects.Shapes.ConversionReactorGraphic") Then
            xel.Value = "DWSIM.rawing.SkiaSharp.GraphicObjects.ReactorConversionGraphic"
        ElseIf xel.Value.Equals("PortableFlowsheetDrawing.GraphicObjects.Shapes.CSTRGraphic") Then
            xel.Value = "DWSIM.rawing.SkiaSharp.GraphicObjects.ReactorCSTRGraphic"
        ElseIf xel.Value.Equals("PortableFlowsheetDrawing.GraphicObjects.Shapes.PFRGraphic") Then
            xel.Value = "DWSIM.rawing.SkiaSharp.GraphicObjects.ReactorPFRGraphic"
        ElseIf xel.Value.Equals("PortableFlowsheetDrawing.GraphicObjects.Shapes.MixerGraphic") Then
            xel.Value = "DWSIM.rawing.SkiaSharp.GraphicObjects.NodeInGraphic"
        ElseIf xel.Value.Equals("PortableFlowsheetDrawing.GraphicObjects.Shapes.SplitterGraphic") Then
            xel.Value = "DWSIM.rawing.SkiaSharp.GraphicObjects.NodeOutGraphic"
        ElseIf xel.Value.Equals("PortableFlowsheetDrawing.GraphicObjects.Shapes.HeaterCoolerGraphic") Then
            xel.Value = "DWSIM.rawing.SkiaSharp.GraphicObjects.HeaterGraphic"
        ElseIf xel.Value.Equals("PortableFlowsheetDrawing.GraphicObjects.Shapes.CompressorExpanderGraphic") Then
            xel.Value = "DWSIM.rawing.SkiaSharp.GraphicObjects.CompressorGraphic"
        ElseIf xel.Value.Equals("PortableFlowsheetDrawing.GraphicObjects.Shapes.RigorousColumnGraphic") Then
            xel.Value = "DWSIM.rawing.SkiaSharp.GraphicObjects.DistillationColumnGraphic"
        ElseIf xel.Value.Equals("PortableFlowsheetDrawing.GraphicObjects.Shapes.AbsorptionColumnGraphic") Then
            xel.Value = "DWSIM.rawing.SkiaSharp.GraphicObjects.AbsorptionColumnGraphic"
        End If

        If xel.Value.StartsWith("PortableFlowsheetDrawing.GraphicObjects.Shapes") And xel.Name = "Type" Then
            xel.Value = xel.Value.Replace("PortableFlowsheetDrawing.GraphicObjects.Shapes", "DWSIM.Drawing.SkiaSharp.GraphicObjects")
        End If

        If xel.Value.EndsWith("Streams.MaterialStream") Then xel.Value = "DWSIM.Thermodynamics.Streams.MaterialStream"
        If xel.Value.EndsWith("Streams.EnergyStream") Then xel.Value = "DWSIM.UnitOperations.Streams.EnergyStream"

        If xel.Value.EndsWith("UnitOperations.Separator") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Vessel"
        If xel.Value.EndsWith("UnitOperations.AdiabaticExpanderCompressor") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Compressor"
        If xel.Value.EndsWith("UnitOperations.HeaterCooler") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Heater"
        If xel.Value.EndsWith("UnitOperations.HeatExchanger") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.HeatExchanger"
        If xel.Value.EndsWith("UnitOperations.Mixer") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Mixer"
        If xel.Value.EndsWith("UnitOperations.Splitter") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Splitter"
        If xel.Value.EndsWith("UnitOperations.ComponentSeparator") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.ComponentSeparator"
        If xel.Value.EndsWith("UnitOperations.ShortcutColumn") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.ShortcutColumn"
        If xel.Value.EndsWith("UnitOperations.Valve") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Valve"
        If xel.Value.EndsWith("UnitOperations.Pump") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Pump"
        If xel.Value.EndsWith("UnitOperations.Pipe") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Pipe"
        If xel.Value.EndsWith("UnitOperations.DistillationColumn") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.DistillationColumn"
        If xel.Value.EndsWith("UnitOperations.AbsorptionColumn") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.AbsorptionColumn"

        If xel.Value.EndsWith("Reactors.Reactor_Conversion") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_Conversion"
        If xel.Value.EndsWith("Reactors.Reactor_Equilibrium") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_Equilibrium"
        If xel.Value.EndsWith("Reactors.Reactor_PFR") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_PFR"
        If xel.Value.EndsWith("Reactors.Reactor_CSTR") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_CSTR"

        If xel.Value.EndsWith("UnitOperations.Adjust") Then xel.Value = "DWSIM.UnitOperations.SpecialOps.Adjust"
        If xel.Value.EndsWith("UnitOperations.Recycle") Then xel.Value = "DWSIM.UnitOperations.SpecialOps.Recycle"

    End Sub

    Shared Sub UpdateElementForMobileXMLLoading_CrossPlatformUI(xel As XElement)

        If xel.Name = "TipoObjeto" Then xel.Name = "ObjectType"
        If xel.Name = "Nome" Then xel.Name = "Name"
        If xel.Name = "Descricao" Then xel.Name = "Description"
        If xel.Name = "Tipo" Then xel.Name = "Type"
        If xel.Name = "FracaoMolar" Then xel.Name = "MoleFraction"
        If xel.Name = "FracaoMassica" Then xel.Name = "MassFraction"
        If xel.Name = "FracaoDePetroleo" Then xel.Name = "PetroleumFraction"
        If xel.Value = "Nenhum" Then xel.Value = "None"
        If xel.Value = "Destino" Then xel.Value = "Target"
        If xel.Value = "Fonte" Then xel.Value = "Source"
        If xel.Value = "Manipulada" Then xel.Value = "Manipulated"
        If xel.Value = "Referencia" Then xel.Value = "Referenced"
        If xel.Value = "Controlada" Then xel.Value = "Controlled"

        If xel.Name = "Fill" Then xel.Value = "True"

        If xel.Value.Equals("PortableFlowsheetDrawing.GraphicObjects.Shapes.HeaterCoolerGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.HeaterGraphic"
        ElseIf xel.Value.Equals("PortableFlowsheetDrawing.GraphicObjects.Shapes.CompressorExpanderGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.CompressorGraphic"
        End If

        If xel.Value.StartsWith("PortableFlowsheetDrawing.GraphicObjects.Shapes") And xel.Name = "Type" Then
            xel.Value = xel.Value.Replace("PortableFlowsheetDrawing.GraphicObjects.Shapes", "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes")
        End If

        If xel.Value.StartsWith("PortableFlowsheetDrawing.GraphicObjects.Tables") And xel.Name = "Type" Then
            xel.Value = xel.Value.Replace("PortableFlowsheetDrawing.GraphicObjects.Tables", "DWSIM.Drawing.SkiaSharp.GraphicObjects.Tables")
        End If

        If xel.Value.EndsWith("Streams.MaterialStream") Then xel.Value = "DWSIM.Thermodynamics.Streams.MaterialStream"
        If xel.Value.EndsWith("Streams.EnergyStream") Then xel.Value = "DWSIM.UnitOperations.Streams.EnergyStream"

        If xel.Value.EndsWith("UnitOperations.Separator") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Vessel"
        If xel.Value.EndsWith("UnitOperations.AdiabaticExpanderCompressor") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Compressor"
        If xel.Value.EndsWith("UnitOperations.HeaterCooler") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Heater"
        If xel.Value.EndsWith("UnitOperations.HeatExchanger") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.HeatExchanger"
        If xel.Value.EndsWith("UnitOperations.Mixer") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Mixer"
        If xel.Value.EndsWith("UnitOperations.Splitter") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Splitter"
        If xel.Value.EndsWith("UnitOperations.ComponentSeparator") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.ComponentSeparator"
        If xel.Value.EndsWith("UnitOperations.ShortcutColumn") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.ShortcutColumn"
        If xel.Value.EndsWith("UnitOperations.Valve") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Valve"
        If xel.Value.EndsWith("UnitOperations.Pump") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Pump"
        If xel.Value.EndsWith("UnitOperations.Pipe") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.Pipe"
        If xel.Value.EndsWith("UnitOperations.DistillationColumn") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.DistillationColumn"
        If xel.Value.EndsWith("UnitOperations.AbsorptionColumn") Then xel.Value = "DWSIM.UnitOperations.UnitOperations.AbsorptionColumn"

        If xel.Value.EndsWith("Reactors.Reactor_Conversion") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_Conversion"
        If xel.Value.EndsWith("Reactors.Reactor_Equilibrium") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_Equilibrium"
        If xel.Value.EndsWith("Reactors.Reactor_PFR") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_PFR"
        If xel.Value.EndsWith("Reactors.Reactor_CSTR") Then xel.Value = "DWSIM.UnitOperations.Reactors.Reactor_CSTR"

        If xel.Value.EndsWith("UnitOperations.Adjust") Then xel.Value = "DWSIM.UnitOperations.SpecialOps.Adjust"
        If xel.Value.EndsWith("UnitOperations.Recycle") Then xel.Value = "DWSIM.UnitOperations.SpecialOps.Recycle"

    End Sub

    Shared Sub UpdateElementForMobileXMLSaving(xel As XElement)

        If xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.ReactorEquilibriumGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.EquilibriumReactorGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.ReactorConversionGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.ConversionReactorGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.ReactorCSTRGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.CSTRGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.ReactorPFRGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.PFRGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.ReactorGibbsGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.GibbsGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.NodeInGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.MixerGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.NodeOutGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.SplitterGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.HeaterGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.HeaterCoolerGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.CoolerGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.HeaterCoolerGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.CompressorGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.CompressorExpanderGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.TurbineGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.CompressorExpanderGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.DistillationColumnGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.RigorousColumnGraphic"
        ElseIf xel.Value.Equals("DWSIM.DrawingTools.GraphicObjects.AbsorptionColumnGraphic") Then
            xel.Value = "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.AbsorptionColumnGraphic"
        End If

        If xel.Value.StartsWith("DWSIM.Thermodynamics.PropertyPackages") And xel.Name = "Type" Then
            xel.Value = xel.Value.Replace("DWSIM.Thermodynamics.PropertyPackages", "PortableDTL.DTL.SimulationObjects.PropertyPackages")
        End If

        If xel.Value.StartsWith("DWSIM.DrawingTools.GraphicObjects") And xel.Name = "Type" Then
            xel.Value = xel.Value.Replace("DWSIM.DrawingTools.GraphicObjects", "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes")
        End If

        If xel.Value.Equals("DWSIM.Thermodynamics.Streams.MaterialStream") Then xel.Value = "PortableDTL.DTL.SimulationObjects.Streams.MaterialStream"
        If xel.Value.Equals("DWSIM.UnitOperations.Streams.EnergyStream") Then xel.Value = "PortableDTL.DTL.SimulationObjects.Streams.EnergyStream"

        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Vessel") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Separator"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Compressor") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.AdiabaticExpanderCompressor"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Expander") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.AdiabaticExpanderCompressor"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Heater") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.HeaterCooler"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Cooler") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.HeaterCooler"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.HeatExchanger") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.HeatExchanger"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Mixer") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Mixer"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Splitter") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Splitter"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.ComponentSeparator") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.ComponentSeparator"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.ShortcutColumn") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.ShortcutColumn"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Valve") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Valve"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Pump") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Pump"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Pipe") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Pipe"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.DistillationColumn") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.DistillationColumn"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.AbsorptionColumn") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.AbsorptionColumn"

        If xel.Value.Equals("DWSIM.UnitOperations.Reactors.Reactor_Conversion") Then xel.Value = "PortableDTL.DTL.SimulationObjects.Reactors.Reactor_Conversion"
        If xel.Value.Equals("DWSIM.UnitOperations.Reactors.Reactor_Equilibrium") Then xel.Value = "PortableDTL.DTL.SimulationObjects.Reactors.Reactor_Equilibrium"
        If xel.Value.Equals("DWSIM.UnitOperations.Reactors.Reactor_PFR") Then xel.Value = "PortableDTL.DTL.SimulationObjects.Reactors.Reactor_PFR"
        If xel.Value.Equals("DWSIM.UnitOperations.Reactors.Reactor_CSTR") Then xel.Value = "PortableDTL.DTL.SimulationObjects.Reactors.Reactor_CSTR"
        If xel.Value.Equals("DWSIM.UnitOperations.Reactors.Reactor_Gibbs") Then xel.Value = "PortableDTL.DTL.SimulationObjects.Reactors.Reactor_Gibbs"

        If xel.Value.Equals("DWSIM.UnitOperations.SpecialOps.Adjust") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Adjust"
        If xel.Value.Equals("DWSIM.UnitOperations.SpecialOps.Recycle") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Recycle"

    End Sub

    Shared Sub UpdateElementForMobileXMLSaving_CrossPlatformUI(xel As XElement)

        If xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.HeaterGraphic") Then
            xel.Value = "PortableFlowsheetDrawing.GraphicObjects.Shapes.HeaterCoolerGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.CoolerGraphic") Then
            xel.Value = "PortableFlowsheetDrawing.GraphicObjects.Shapes.HeaterCoolerGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.CompressorGraphic") Then
            xel.Value = "PortableFlowsheetDrawing.GraphicObjects.Shapes.CompressorExpanderGraphic"
        ElseIf xel.Value.Equals("DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes.TurbineGraphic") Then
            xel.Value = "PortableFlowsheetDrawing.GraphicObjects.Shapes.CompressorExpanderGraphic"
        End If

        If xel.Value.StartsWith("DWSIM.Thermodynamics.PropertyPackages") And xel.Name = "Type" Then
            xel.Value = xel.Value.Replace("DWSIM.Thermodynamics.PropertyPackages", "PortableDTL.DTL.SimulationObjects.PropertyPackages")
        End If

        If xel.Value.StartsWith("DWSIM.DrawingTools.GraphicObjects") And xel.Name = "Type" Then
            xel.Value = xel.Value.Replace("DWSIM.DrawingTools.GraphicObjects", "DWSIM.Drawing.SkiaSharp.GraphicObjects.Shapes")
        End If

        If xel.Value.Equals("DWSIM.Thermodynamics.Streams.MaterialStream") Then xel.Value = "PortableDTL.DTL.SimulationObjects.Streams.MaterialStream"
        If xel.Value.Equals("DWSIM.UnitOperations.Streams.EnergyStream") Then xel.Value = "PortableDTL.DTL.SimulationObjects.Streams.EnergyStream"

        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Vessel") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Separator"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Compressor") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.AdiabaticExpanderCompressor"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Expander") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.AdiabaticExpanderCompressor"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Heater") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.HeaterCooler"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Cooler") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.HeaterCooler"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.HeatExchanger") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.HeatExchanger"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Mixer") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Mixer"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Splitter") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Splitter"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.ComponentSeparator") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.ComponentSeparator"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.ShortcutColumn") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.ShortcutColumn"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Valve") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Valve"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Pump") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Pump"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.Pipe") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Pipe"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.DistillationColumn") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.DistillationColumn"
        If xel.Value.Equals("DWSIM.UnitOperations.UnitOperations.AbsorptionColumn") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.AbsorptionColumn"

        If xel.Value.Equals("DWSIM.UnitOperations.Reactors.Reactor_Conversion") Then xel.Value = "PortableDTL.DTL.SimulationObjects.Reactors.Reactor_Conversion"
        If xel.Value.Equals("DWSIM.UnitOperations.Reactors.Reactor_Equilibrium") Then xel.Value = "PortableDTL.DTL.SimulationObjects.Reactors.Reactor_Equilibrium"
        If xel.Value.Equals("DWSIM.UnitOperations.Reactors.Reactor_PFR") Then xel.Value = "PortableDTL.DTL.SimulationObjects.Reactors.Reactor_PFR"
        If xel.Value.Equals("DWSIM.UnitOperations.Reactors.Reactor_CSTR") Then xel.Value = "PortableDTL.DTL.SimulationObjects.Reactors.Reactor_CSTR"
        If xel.Value.Equals("DWSIM.UnitOperations.Reactors.Reactor_Gibbs") Then xel.Value = "PortableDTL.DTL.SimulationObjects.Reactors.Reactor_Gibbs"

        If xel.Value.Equals("DWSIM.UnitOperations.SpecialOps.Adjust") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Adjust"
        If xel.Value.Equals("DWSIM.UnitOperations.SpecialOps.Recycle") Then xel.Value = "PortableDTL.DTL.SimulationObjects.UnitOperations.Recycle"

    End Sub

    Shared Function CheckSimulationForMobileCompatibility(fs As IFlowsheet) As String

        Dim report As String = ""

        Dim unsupp_uocount = fs.SimulationObjects.Values.Where(Function(x) Not x.MobileCompatible).Count
        Dim unsupp_ppcount = fs.PropertyPackages.Values.Where(Function(x) Not x.MobileCompatible).Count
        Dim unsupp_fscount = fs.FlowsheetOptions.FlashAlgorithms.Where(Function(x) Not x.MobileCompatible).Count

        If unsupp_uocount > 0 Then
            report += "Unsupported Unit Operations: "
            For Each obj In fs.SimulationObjects.Values.Where(Function(x) Not x.MobileCompatible).ToList
                report += obj.GraphicObject.Tag + ", "
            Next
        End If

        If unsupp_ppcount > 0 Then
            report += "Unsupported Property Packages: "
            For Each obj In fs.PropertyPackages.Values.Where(Function(x) Not x.MobileCompatible).ToList
                report += obj.Tag + " (" + obj.Name + ")" + ", "
            Next
        End If

        If unsupp_fscount > 0 Then
            report += "Unsupported Flash Algorithms: "
            For Each obj In fs.FlowsheetOptions.FlashAlgorithms.Where(Function(x) Not x.MobileCompatible).ToList
                report += obj.Tag + " (" + obj.Name + ")" + ", "
            Next
        End If

        Return report

    End Function

    Shared Function LoadAdditionalPropertyPackages() As List(Of IPropertyPackage)

        Dim ppacks As New List(Of IPropertyPackage)

        Dim adveos As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly.Location) + Path.DirectorySeparatorChar + "DWSIM.Thermodynamics.AdvancedEOS.dll"
        If File.Exists(adveos) Then
            Dim pplist As List(Of Interfaces.IPropertyPackage) = GetPropertyPackages(Assembly.LoadFile(adveos))
            For Each pp In pplist
                ppacks.Add(pp)
            Next
        End If

        Dim thermoceos As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly.Location) + Path.DirectorySeparatorChar + "DWSIM.Thermodynamics.ThermoC.dll"
        If File.Exists(thermoceos) Then
            Dim pplist As List(Of Interfaces.IPropertyPackage) = GetPropertyPackages(Assembly.LoadFile(thermoceos))
            For Each pp In pplist
                ppacks.Add(pp)
            Next
        End If

        Dim creos As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly.Location) + Path.DirectorySeparatorChar + "DWSIM.Thermodynamics.COSMO-RS.dll"
        If File.Exists(creos) Then
            Dim pplist As List(Of Interfaces.IPropertyPackage) = GetPropertyPackages(Assembly.LoadFile(creos))
            For Each pp In pplist
                ppacks.Add(pp)
            Next
        End If

        Return ppacks

    End Function

    Shared Function GetPropertyPackages(ByVal assmbly As Assembly) As List(Of Interfaces.IPropertyPackage)

        Dim availableTypes As New List(Of Type)()

        Try
            availableTypes.AddRange(assmbly.GetTypes())
        Catch ex As Exception
            Console.WriteLine("Error loading types from assembly '" + assmbly.FullName + "': " + ex.ToString)
        End Try

        Dim ppList As List(Of Type) = availableTypes.FindAll(Function(t) t.GetInterfaces().Contains(GetType(Interfaces.IPropertyPackage)) And Not t.IsAbstract)

        Return ppList.ConvertAll(Of Interfaces.IPropertyPackage)(Function(t As Type) TryCast(Activator.CreateInstance(t), Interfaces.IPropertyPackage))

    End Function

    Shared Function GetRuntimeVersion() As String

        If GlobalSettings.Settings.IsRunningOnMono Then

            If GlobalSettings.Settings.RunningPlatform = GlobalSettings.Settings.Platform.Mac Then

                Return "Xamarin.Mac (CLR v" & Environment.Version.ToString() & ")"

            Else

                Dim t As Type = Type.GetType("Mono.Runtime")
                Dim displayName As MethodInfo = t.GetMethod("GetDisplayName", BindingFlags.NonPublic + BindingFlags.Static)
                Dim verstr As String = "Mono Framework v" & displayName.Invoke(Nothing, Nothing)
                If verstr.Contains("(") Then verstr = verstr.Substring(0, verstr.IndexOf("(") - 1)
                If displayName IsNot Nothing Then Return verstr Else Return ""

            End If

        Else

            Return ".NET Framework (CLR v" & Environment.Version.ToString() & ")"

        End If


    End Function

End Class