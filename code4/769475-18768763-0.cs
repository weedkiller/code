    @(Html.Kendo().Grid<Kendo.Mvc.Examples.Models.ClientProductViewModel>()
    .Name("grid")
    .Columns(columns =>
    {
        columns.Bound(p => p.ProductName);
        columns.Bound(p => p.Category).ClientTemplate("#=Category.CategoryName#").Width(160);
        columns.Bound(p => p.UnitPrice).Width(120);
        columns.Command(command => command.Destroy()).Width(90);
    })
    .ToolBar(toolBar =>
        {
            toolBar.Create();
            toolBar.Save();
        })
    .Editable(editable => editable.Mode(GridEditMode.InCell))
    .Pageable()
    .Sortable()
    .Scrollable()
    .HtmlAttributes(new { style = "height:430px;" })
    .DataSource(dataSource => dataSource
        .Ajax()
        .Batch(true)
        .ServerOperation(false)
        .Events(events => events.Error("error_handler"))
        .Model(model =>
        {
            model.Id(p => p.ProductID);
            model.Field(p => p.ProductID).Editable(false);
            model.Field(p => p.Category).DefaultValue(
                ViewData["defaultCategory"] as Kendo.Mvc.Examples.Models.ClientCategoryViewModel);
        })
        .PageSize(20)
        .Read(read => read.Action("EditingCustom_Read", "Grid"))
        .Create(create => create.Action("EditingCustom_Create", "Grid"))
        .Update(update => update.Action("EditingCustom_Update", "Grid"))        
        .Destroy(destroy => destroy.Action("EditingCustom_Destroy", "Grid"))
    )
    )
