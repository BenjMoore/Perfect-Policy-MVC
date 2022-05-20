
using ChartJSCore.Models;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfectPolicyFrontEnd.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PerfectPolicyFrontEnd.Controllers
{ 
    public class ReportController : Controller
    {

        private readonly string reportController = "Report";

        HttpClient _client;
        public ReportController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }
/// <summary>
/// Returns a chart and enable export of data
/// </summary>
/// <returns></returns>
        public IActionResult QuizQuestionCount()
        {
            var response = _client.GetAsync("Report/QuizQuestionCountReport").Result;

            List<QuizQuestionCount> quizQuestionCount = response.Content.ReadAsAsync<List<QuizQuestionCount>>().Result;

            // define the chart object itself
            Chart chart = new Chart();


            //Serialise the report data and save in a session
            var jsonData = JsonSerializer.Serialize(quizQuestionCount);
            HttpContext.Session.SetString("ReportData", jsonData);

            // define the type of chart
            chart.Type = Enums.ChartType.Bar;

            ChartJSCore.Models.Data data = new ChartJSCore.Models.Data();
            data.Labels = quizQuestionCount.Select(c => c.QuizTitle).ToList();

            BarDataset barData = new BarDataset()
            {
                Label = "Questions per quiz",
                Data = quizQuestionCount.Select(c => (double?)c.QuestionCount).ToList()
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(barData);

            chart.Data = data;

            ViewData["chart"] = chart;

            return View();
        }

        public IActionResult ExportData()
        {
            //Serialise the report data and save in the session
            var jsonData = HttpContext.Session.GetString("ReportData");
            var reportData = JsonSerializer.Deserialize<List<QuizQuestionCount>>(jsonData);

            //Create an empty memory stream
            var stream = new MemoryStream();

            //Generate to csv data
            using (var writeFile = new StreamWriter(stream, leaveOpen: true))
            {
                var csv = new CsvWriter(writeFile, CultureInfo.CurrentCulture, leaveOpen: true);

                // Write the csv data to the memory stream
                csv.WriteRecords(reportData);
            }

            //Reset stream position (Beacause the stream needs to go back to the start to see what has been read instead of reading backwards.
            stream.Position = 0;

            //Return the memory stream as a file
            return File(stream, "application/octet-stream", $"ReportData_{DateTime.Now.ToString("ddMMMyy_HHmmss")}.csv");
                //application/octet-stream lets the browser know this is a file to download and then the browser does not interact with it any further

            //Serialisation is boxing it all up and Deserialisation is the unboxing of the info.
        }
    }
}