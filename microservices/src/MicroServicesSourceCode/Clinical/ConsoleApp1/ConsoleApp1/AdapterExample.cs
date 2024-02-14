using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
   
    public interface IExport
    {
        void Export();
    }

    public class TextExport : IExport
    {
        public void Export()
        {
            throw new NotImplementedException();
        }
    }
    public class ExcelExport : IExport
    {
        public void Export()
        {
            // excel export
        }
    }
    public class WordExport : IExport
    {
        public void Export()
        {
            // excel export
        }
    }
    public class AdapterPdfExport : IExport
    {
        public void Export()
        {
            PdfExport t = new PdfExport();
            t.Save();
        }
    }
    public class PdfExport
    {
        public void Save()
        {

        }
    }

    public static class FactoryExport
    {
        public static IExport Create(int i)
        {
            if(i == 1){
                return new ExcelExport();
            }
            if (i == 2)
            {
                return new WordExport();
            }
            return new TextExport();
        }
    }
}
