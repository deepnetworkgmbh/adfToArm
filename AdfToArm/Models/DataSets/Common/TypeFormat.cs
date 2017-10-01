using Newtonsoft.Json;

namespace AdfToArm.Models.DataSets.Common
{
    [JsonObject]
    public class FormatType
    {
        [JsonProperty("format", Required = Required.Always)]
        public FormatTypes Format { get; set; }

        /// <summary>
        /// The character used to separate columns in a file. 
        /// You can consider to use a rare unprintable char that may not likely exists in your data. 
        /// For example, specify "\u0001", which represents Start of Heading (SOH).
        /// 
        /// Only one character is allowed. The default value is comma (',').
        /// </summary>
        [JsonProperty("columnDelimiter", Required = Required.AllowNull)]
        public string ColumnDelimiter { get; set; }

        /// <summary>
        /// The character used to separate rows in a file.
        /// 
        /// Only one character is allowed. 
        /// The default value is any of the following values on read: ["\r\n", "\r", "\n"] and "\r\n" on write.
        /// </summary>
        [JsonProperty("rowDelimiter", Required = Required.AllowNull)]
        public string RowDelimiter { get; set; }

        /// <summary>
        /// The special character used to escape a column delimiter in the content of input file. 
        /// You cannot specify both escapeChar and quoteChar for a table.
        /// 
        /// Only one character is allowed. No default value. 
        /// <example>if you have comma (',') as the column delimiter but you want to have the comma character in the text (example: "Hello, world"), you can define ‘$’ as the escape character and use string "Hello$, world" in the source.</example>
        /// </summary>
        [JsonProperty("escapeChar", Required = Required.AllowNull)]
        public string EscapeChar { get; set; }

        /// <summary>
        /// The character used to quote a string value. 
        /// The column and row delimiters inside the quote characters would be treated as part of the string value. 
        /// This property is applicable to both input and output datasets.
        /// 
        /// You cannot specify both escapeChar and quoteChar for a table.
        /// 
        /// Only one character is allowed. No default value. 
        /// <example>if you have comma (',') as the column delimiter but you want to have comma character in the text (example: ), you can define " (double quote) as the quote character and use the string "Hello, world" in the source.</example>
        /// </summary>
        [JsonProperty("quoteChar", Required = Required.AllowNull)]
        public string QuoteChar { get; set; }

        /// <summary>
        /// One or more characters used to represent a null value.
        /// 
        /// One or more characters. The default values are "\N" and "NULL" on read and "\N" on write.
        /// </summary>
        [JsonProperty("nullValue", Required = Required.AllowNull)]
        public string NullValue { get; set; }

        /// <summary>
        /// Specify the encoding name.
        /// 
        /// A valid encoding name. see <see cref="Encoding.EncodingName"/> Property. 
        /// <example>windows-1250 or shift_jis</example>
        /// The default value is UTF-8.
        /// </summary>
        [JsonProperty("encodingName", Required = Required.AllowNull)]
        public string EncodingName { get; set; }

        /// <summary>
        /// Specifies whether to consider the first row as a header. 
        /// For an input dataset, Data Factory reads first row as a header. 
        /// For an output dataset, Data Factory writes first row as a header. 
        /// 
        /// Default value is false
        /// </summary>
        [JsonProperty("firstRowAsHeader", Required = Required.AllowNull)]
        public bool? FirstRowAsHeader { get; set; }

        /// <summary>
        /// Indicates the number of rows to skip when reading data from input files. 
        /// If both skipLineCount and firstRowAsHeader are specified, the lines are skipped first and then the header information is read from the input file. 
        /// </summary>
        [JsonProperty("skipLineCount", Required = Required.AllowNull)]
        public int? SkipLineCount { get; set; }

        /// <summary>
        /// Specifies whether to treat null or empty string as a null value when reading data from an input file.
        /// 
        /// Default value is True
        /// </summary>
        [JsonProperty("treatEmptyAsNull", Required = Required.AllowNull)]
        public bool? TreatEmptyAsNull { get; set; }
    }
}
