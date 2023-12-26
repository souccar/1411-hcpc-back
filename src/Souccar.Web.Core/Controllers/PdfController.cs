using Abp.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PdfController : SouccarControllerBase
    {
        private readonly IOutputRequestAppService _outputRequestAppService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public int PlanId { get; set; }

        public PdfController(IOutputRequestAppService outputRequestAppService, IWebHostEnvironment hostingEnvironment)
        {
            _outputRequestAppService = outputRequestAppService;
            _hostingEnvironment = hostingEnvironment;
        }

        private IList<OutputRequestWithDetailDto> GetOutputRequestsForPlan(int planId)
        {
            var outputRequests = AsyncHelper.RunSync(() => _outputRequestAppService.GetWithDetail(planId));
            return outputRequests;
        }

        [HttpGet]
        public void GenerateDailyProductionsReport(int planId)
        {
            PlanId = planId;
            Document document = Document.Create(Compose);
            document.GeneratePdfAndShow();
        }

        private void Compose(IDocumentContainer container)
        {
            var rootPath = _hostingEnvironment.WebRootPath;
            Image logoImage = Image.FromFile(rootPath + "\\Images\\logo.png");
            var outputRequests = GetOutputRequestsForPlan(PlanId);

            container
            .Page(page =>
             {
                 page.Margin(50);

                 page.Header()
                 .Row(row =>
                 {
                     row.RelativeItem().Column(column =>
                     {
                         column.Item().AlignMiddle().Text(text =>
                         {
                             text.Span("Date: ").SemiBold();
                             text.Span(DateTime.Now.ToString("dd/MM/yyyy"));
                         });
                     });

                     row.ConstantItem(175).Image(logoImage);
                 });

                 page.Content()
                .PaddingVertical(25).Table(table =>
                {
                    var headerStyle = TextStyle.Default.SemiBold();

                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(75);
                        columns.RelativeColumn(40);
                        columns.RelativeColumn(60);
                        columns.RelativeColumn(50);
                    });

                    table.Header(header =>
                    {
                        header.Cell().AlignCenter().Text(L("RequestTitle")).Style(headerStyle);
                        header.Cell().AlignCenter().Text(L("RequestDate")).Style(headerStyle);
                        header.Cell().AlignCenter().Text(L("Products")).Style(headerStyle);
                        header.Cell().AlignCenter().Text(L("DailyProduction")).Style(headerStyle);
                    });

                    foreach (var item in outputRequests)
                    {
                        var count = (uint)(item.OutputRequestProducts.Count * item.DailyProductions.Count);
                        if (count == 0)
                        {
                            table.Cell().Element(CellStyle).AlignCenter().AlignMiddle().ShowOnce().Text(item.Title);
                            table.Cell().Element(CellStyle).AlignCenter().AlignMiddle().Text(item.OutputDate.ToString("dd/MM/yyyy"));
                            table.Cell().Element(CellStyle).AlignCenter().AlignMiddle().Text("-")
                            .FontSize(12).FontColor(Colors.BlueGrey.Medium);
                            table.Cell().Element(CellStyle).AlignCenter().AlignMiddle().Text("-")
                            .FontSize(12).FontColor(Colors.BlueGrey.Medium);
                        }
                        else
                        {
                            table.Cell().RowSpan(count).Element(CellStyle).AlignCenter().AlignMiddle().ShowOnce().Text(item.Title);
                            table.Cell().RowSpan(count).Element(CellStyle).AlignCenter().AlignMiddle().Text(item.OutputDate.ToString("dd/MM/yyyy"));

                            int colorNum = 0;


                            foreach (var product in item.OutputRequestProducts)
                            {
                                var numberOfDaily = item.DailyProductions
                                .Where(x => x.DailyProductionDetails.Any(y => y.ProductId == product.ProductId))
                                .Count();

                                if (numberOfDaily != 0)
                                {
                                    if (colorNum == 0)
                                    {
                                        table.Cell().RowSpan((uint)numberOfDaily).Element(CellStyle).AlignCenter().AlignMiddle()
                                        .Text(product.Product.Name + " / Can produce: " + product.CanProduce)
                                        .FontSize(7).FontColor(Colors.BlueGrey.Medium);

                                    
                                        foreach (var dailyProduction in item.DailyProductions)
                                        {
                                            colorNum = 1;
                                            table.Cell().Element(CellStyle).AlignCenter().AlignMiddle()
                                            .Text(dailyProduction.CreationTime.ToString("dd/MM/yyyy")
                                            + " - Produced: "
                                            + dailyProduction.DailyProductionDetails.FirstOrDefault(z => z.ProductId == product.ProductId).Quantity)
                                            .FontSize(7).FontColor(Colors.BlueGrey.Medium);
                                        }
                                    }
                                    else
                                    {
                                        table.Cell().RowSpan((uint)numberOfDaily).Element(CellStyle).AlignCenter().AlignMiddle()
                                        .Text(product.Product.Name + " / Can produce: " + product.CanProduce)
                                        .FontSize(7).FontColor(Colors.LightBlue.Accent4);

                                        foreach (var dailyProduction in item.DailyProductions)
                                        {
                                            colorNum = 0;
                                            table.Cell().Element(CellStyle).AlignCenter().AlignMiddle()
                                            .Text(dailyProduction.CreationTime.ToString("dd/MM/yyyy")
                                            + " - Produced: "
                                            + dailyProduction.DailyProductionDetails.FirstOrDefault(z => z.ProductId == product.ProductId).Quantity)
                                            .FontSize(7).FontColor(Colors.LightBlue.Accent4);

                                        }
                                    }
                                }
                                else
                                {
                                    table.Cell().Element(CellStyle).AlignCenter().AlignMiddle()
                                    .Text(product.Product.Name + " / Can produce: " + product.CanProduce)
                                    .FontSize(7).FontColor(Colors.BlueGrey.Medium);

                                    foreach (var dailyProduction in item.DailyProductions)
                                    {
                                        table.Cell().Element(CellStyle).AlignCenter().AlignMiddle().Text("-")
                                        .FontSize(7).FontColor(Colors.BlueGrey.Medium);
                                    }
                                }
                            }
                        }
                        IContainer CellStyle(IContainer container1) => container1.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                    }

                });

                 page.Footer().AlignCenter().Text(text =>
                 {
                     text.CurrentPageNumber();
                     text.Span(" / ");
                     text.TotalPages();
                 });
             });
        }
    }
}
