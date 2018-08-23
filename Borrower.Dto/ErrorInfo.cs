using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;

namespace Borrower.Dto
{
    [DataContract]
    public class ErrorInfo
    {
        [DataMember(EmitDefaultValue = false)]
        public int Status { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string DeveloperMessage { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string UserMessage { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int ErrorCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string MoreInfo { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            AppendValue(sb, x => x.Status);
            AppendValue(sb, x => x.DeveloperMessage);
            AppendValue(sb, x => x.UserMessage);
            AppendValue(sb, x => x.ErrorCode);
            AppendValue(sb, x => x.MoreInfo);
            return sb.ToString();
        }

        private void AppendValue<T>(StringBuilder sb, Expression<Func<ErrorInfo, T>> property)
        {
            var compile = property.Compile();
            var name = property.Name;
            if (property.Body is MemberExpression memberExpression)
            {
                name = memberExpression.Member.Name;
            }
            var value = compile.Invoke(this);
            if (Equals(value, default(T)))
            {
                return;
            }

            if (sb.Length > 0)
            {
                sb.AppendLine();
            }
            sb.Append($"{name}: {value}");
        }
    }
}