    PdfDocument doc = new PdfDocument();
    PdfPageBase page = doc.Pages.Add();
    Rectangle rt = new Rectangle(0, 80, 200, 200); 
    Pdf3DAnnotation annotation = new Pdf3DAnnotation(rt, "teapot.u3d");
    annotation.Activation = new Pdf3DActivation();
    annotation.Activation.ActivationMode = Pdf3DActivationMode.PageOpen; 
    Pdf3DView View= new Pdf3DView();
    View.Background = new Pdf3DBackground(new PdfRGBColor(Color.Purple));
    View.ViewNodeName = "test";
    View.RenderMode = new Pdf3DRendermode(Pdf3DRenderStyle.Solid);
    View.InternalName = "test";
    View.LightingScheme = new Pdf3DLighting();
    View.LightingScheme.Style = Pdf3DLightingStyle.Day;
    annotation.Views.Add(View);
    page.AnnotationsWidget.Add(annotation);
    doc.SaveToFile("Create3DPdf.pdf", FileFormat.PDF);
