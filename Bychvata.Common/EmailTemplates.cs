using System.Text;

namespace Bychvata.Common
{
    public static class EmailTemplates
    {
        public static string ConfirmReservationTemplate()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<h3>Здравейте, направихте успешна резервация в Бунгала Бъчвата, очакваме Ви с нетърпение!</h3>");

            return sb.ToString();
        }
    }
}