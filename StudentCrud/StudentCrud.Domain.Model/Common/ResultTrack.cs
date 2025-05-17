using System;

namespace StudentCrud.Domain.Model.Common
{
    public class ResultTrack
    {
        public int ResultId { get; set; }
        public string Message { get; set; }
        public Exception Source { get; set; }
        public bool HasError { get; set; }
        public bool HasSQLError { get; set; }
        public object Output { get; set; }
    }
}
