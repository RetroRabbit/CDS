using DevExpress.XtraReports.Extensions;
using DevExpress.XtraReports.Native.Templates;
using DevExpress.XtraReports.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Client.Desktop.Reporting.Report.Templates
{
    public class CustomTemplateExtension : ReportTemplateExtension
    {
        public override IEnumerable<DevExpress.XtraReports.Templates.Template> GetTemplates()
        {
            var archive = new TemplateArchiveManager();
            string path = Path.Combine(System.Windows.Forms.Application.StartupPath, "/Report/Templates");
            var files = Directory.GetFiles(path);

            var templates = new List<Template>(files.Length);

            foreach (string file in files)
                using (Stream stream = new MemoryStream(File.ReadAllBytes(file)))
                    templates.Add(Template.CreateTemplateFromArchive(stream));

            return templates;
        }
    }
}
