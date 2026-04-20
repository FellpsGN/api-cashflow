using PdfSharp.Fonts;
using MigraDoc.DocumentObjectModel;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts;

public class ExpensesReportFontResolver : IFontResolver
{
    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
    {
        new Font
        {
            Name = FontHelper.RALEWAY_REGULAR
        };
        
        return new FontResolverInfo(familyName);
    }

    public byte[]? GetFont(string faceName)
    {
        throw new NotImplementedException();
    }
}