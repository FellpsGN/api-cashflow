using System.Reflection;
using PdfSharp.Fonts;
using MigraDoc.DocumentObjectModel;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts;

public class ExpensesReportFontResolver : IFontResolver
{
    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
    {
        return new FontResolverInfo(familyName);
    }
    
    public byte[]? GetFont(string fileName)
    {
        var stream = ReadFontFile(fileName);
        if (stream is null) stream = ReadFontFile(FontHelper.DEFAULT_FONT);
        
        var length = (int)stream!.Length;
        var data = new byte[length];

        stream.Read(buffer: data, offset: 0, count: length);

        return data;
    }
    
    private Stream? ReadFontFile(string fileName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        return assembly.GetManifestResourceStream($"CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts.{fileName}.ttf"); 
    }
}